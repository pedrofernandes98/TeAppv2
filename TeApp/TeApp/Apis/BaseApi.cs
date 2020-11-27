using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TeApp.Excepetions;
using TeApp.Models;

namespace TeApp.Apis
{
    public abstract class BaseApi
    {
        private readonly HttpClient _httpClient;
        protected readonly Uri _baseAddress;

        protected BaseApi(HttpClient httpClient, string baseAddress)
        {
            _httpClient = httpClient;
            _baseAddress = new Uri(baseAddress);
        }

        public BaseApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected async Task<T> SendAsync<T>(HttpRequestMessage request)
        {
            var response = await _httpClient.SendAsync(request);
            string responseContent = await ReadResponse(response);

            var objResponse = JsonSerializer.Deserialize<T>(responseContent);
            return objResponse;
        }

        protected async Task<T> PostAsync<T>(string url, object obj)
        {
            var requestMessage = GetDefaultRequest(HttpMethod.Post, url);
            var body = SerializeObject(obj);

            requestMessage.Content = new StringContent(body, Encoding.UTF8, "application/json");

            return await SendAsync<T>(requestMessage);
        }

        protected async Task<T> PutAsync<T>(string url, object obj)
        {
            var requestMessage = GetDefaultRequest(HttpMethod.Put, url);
            var body = SerializeObject(obj);

            requestMessage.Content = new StringContent(body, Encoding.UTF8, "application/json");

            return await SendAsync<T>(requestMessage);
        }

        protected async Task<T> GetAsync<T>(string url)
        {
            var requestMessage = GetDefaultRequest(HttpMethod.Get, url);

            return await SendAsync<T>(requestMessage);
        }

        protected HttpRequestMessage GetDefaultRequest(HttpMethod method, string url)
        {
            var request = new HttpRequestMessage(method, url);

            return request;
        }

        protected async Task<string> ReadResponse(HttpResponseMessage response)
        {
            var responseContent = await response.Content.ReadAsStringAsync() ?? string.Empty;

            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                var errors = JsonSerializer.Deserialize<List<ErrorModel>>(responseContent);
                throw new HttpResponseException(response.StatusCode, $"{response.ReasonPhrase}: {responseContent}", response.RequestMessage.RequestUri.ToString(), e.Message, errors);
            }

            return responseContent;
        }

        protected string SerializeObject(object obj)
        {
            return obj == null ? string.Empty : JsonSerializer.Serialize(obj, new JsonSerializerOptions { IgnoreNullValues = true });
        }
    }
}
