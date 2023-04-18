using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.IO;
using SocketLabsModule.Common.Models;

namespace SocketLabsModule.Common.Services
{
    public class RestProvider : IDisposable, IRestProvider
    {
        private readonly HttpClient _httpClient;
        private readonly RecyclableMemoryStreamManager _streamManager;
        private readonly JsonSerializerOptions _serializerOptions;

        public RestProvider(string bearerToken)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");
            _streamManager = new RecyclableMemoryStreamManager();
            _serializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        }

        public Task<string> PostAsync(string url, object item) =>
            SendAsync<string>(url, HttpMethod.Post, item);

        public Task<T> PostAsync<T>(string url, object item) where T : class =>
            SendAsync<T>(url, HttpMethod.Post, item);

        public async Task<T> SendAsync<T>(string url, HttpMethod httpMethod, object item) where T : class
        {
            var request = new HttpRequestMessage(httpMethod, url);
            using (var ms = _streamManager.GetStream())
            {
                await JsonSerializer.SerializeAsync(ms, item);
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
            return await GetResponseAsync<T>(request);
        }

        public async Task<T> GetAsync<T>(string url) where T : class
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            return await GetResponseAsync<T>(request);
        }

        private async Task<T> GetResponseAsync<T>(HttpRequestMessage request) where T : class
        {
            var httpResponse = await _httpClient.SendAsync(request);
            if (httpResponse.IsSuccessStatusCode)
            {
                T response = null;

                if (typeof(T) == typeof(string))
                {
                    response = (await httpResponse.Content.ReadAsStringAsync()) as T;
                }
                else
                {
                    var foo = httpResponse.Content.ReadAsStringAsync();
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
            {
                return JsonSerializer.Deserialize<T>(responseContent, _serializerOptions);
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

        public async Task<T> PutAsync<T>(string url, object item) where T : class
        {
            return await SendAsync<T>(url, HttpMethod.Put, item);
        }

        #endregion IDisposable Support
    }
}