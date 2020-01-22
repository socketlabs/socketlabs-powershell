using System.Net.Http;
using System.Threading.Tasks;

namespace SocketLabsModule.Common.Services
{
    public interface IRestProvider
    {
        Task<T> DeleteAsync<T>(string url) where T : class;
        void Dispose();
        Task<T> GetAsync<T>(string url) where T : class;
        Task<string> PostAsync(string url, object item);
        Task<T> PostAsync<T>(string url, object item) where T : class;
        Task<T> SendAsync<T>(string url, HttpMethod httpMethod, object item) where T : class;
    }
}