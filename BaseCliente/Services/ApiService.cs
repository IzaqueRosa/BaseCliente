using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BaseCliente.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiBaseUrl"]);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public HttpClient GetHttpClient()
        {
            return _httpClient;
        }
    }
}