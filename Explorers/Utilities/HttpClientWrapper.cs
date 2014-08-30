using System;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace WowDotNetAPI.Utilities
{
    public class HttpClientWrapper
    {
        private readonly HttpClient _httpClient;

        public HttpClientWrapper(string host)
        {
            _httpClient = new HttpClient {BaseAddress = new Uri(host)};
        }
        
        
    }
}
