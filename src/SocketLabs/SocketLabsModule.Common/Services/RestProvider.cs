using Microsoft.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SocketLabsModule.Common.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SocketLabsModule.Common.Services
{
    public class RestProvider : IDisposable, IRestProvider
    {
        private static DefaultContractResolver _resolver = new DefaultContractResolver()
        {
            NamingStrategy = new CamelCaseNamingStrategy()
        };
        private readonly string _bearerToken;
        private readonly HttpClient _httpClient;
        private readonly RecyclableMemoryStreamManager _streamManager;
        private readonly JsonSerializer _serializer;

        public RestProvider(string bearerToken)
        {
            _bearerToken = bearerToken;
            _httpClient = new HttpClient();
            _streamManager = new RecyclableMemoryStreamManager();
            _serializer = new JsonSerializer() { ContractResolver = _resolver };
        }

        public Task<string> PostAsync(string url, object item) =>
            SendAsync<string>(url, HttpMethod.Post, item);

        public Task<T> PostAsync<T>(string url, object item) where T : class =>
            SendAsync<T>(url, HttpMethod.Post, item);

        public async Task<T> SendAsync<T>(string url, HttpMethod httpMethod, object item) where T : class
        {
            //_logger.LogInformation($"Posting to REST endpoint: {url}");

            string reqJson = JsonConvert.SerializeObject(item);
            var request = new HttpRequestMessage(httpMethod, url);
            request.Headers.Add("Authorization", $"Bearer {_bearerToken}");

            using (var ms = _streamManager.GetStream())
            using (var sw = new StreamWriter(ms))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                _serializer.Serialize(writer, item);
                await writer.FlushAsync();
                ms.Position = 0;
                var content = new StreamContent(ms);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                request.Content = content;

                return await GetResponseAsync<T>(request);
            }
        }

        public async Task<T> DeleteAsync<T>(string url) where T : class
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            request.Headers.Add("Authorization", $"Bearer {_bearerToken}");
            return await GetResponseAsync<T>(request);
        }

        public async Task<T> GetAsync<T>(string url) where T : class
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Authorization", $"Bearer {_bearerToken}");
            return await GetResponseAsync<T>(request);
        }

        private async Task<T> GetResponseAsync<T>(HttpRequestMessage request) where T : class
        {
            var httpResponse = await _httpClient.SendAsync(request);

            //_logger.LogInformation($"Status Code: {httpResponse.StatusCode} Reason: {httpResponse.ReasonPhrase}");

            if (httpResponse.IsSuccessStatusCode)
            {
                T response = null;

                if (typeof(T) == typeof(string))
                {
                    response = (await httpResponse.Content.ReadAsStringAsync()) as T;
                }
                else
                {
                    response = await DeserializeAsync<T>(httpResponse);
                }
                return response;
            }
            else
            {
                var apiErrors = await DeserializeAsync<IEnumerable<ApiError>>(httpResponse);
                throw new ManagementApiException("Error calling ManagementApi", apiErrors);
            }
        }

        private async Task<T> DeserializeAsync<T>(HttpResponseMessage httpResponse) where T : class
        {
            using (var responseContent = await httpResponse.Content.ReadAsStreamAsync())
            using (var sr = new StreamReader(responseContent))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                return _serializer.Deserialize<T>(reader);
            }
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _httpClient.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }

        #endregion IDisposable Support
    }
}