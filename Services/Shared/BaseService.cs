using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using Todo_Blazor.ViewModel;

namespace Todo_Blazor.Services.Shared
{
    public abstract class BaseService
    {
        protected readonly HttpClient _httpClient;
        private string _baseUrl;

        protected BaseService(HttpClient httpClient, string baseUrl)
        {
            _httpClient = httpClient;
            _baseUrl = baseUrl;
        }

        public async Task<T> Get<T>(string? methodName = "Get")
        {
            var result = new OperationResult<T>();
            try
            {
                result = await _httpClient.GetFromJsonAsync<OperationResult<T>>($"{_baseUrl}/{methodName}");
            }
            catch (Exception)
            {
                throw;
            }

            return result.Data;
        }

        public async Task Add<T>(T body, string? methodName = "Add")
        {
            var result = await _httpClient.PostAsync($"{_baseUrl}/{methodName}",new StringContent(JsonConvert.SerializeObject(body),
           Encoding.UTF8,
           "application/json"));

            if (result.StatusCode != HttpStatusCode.Created)
                throw new Exception(await result.Content.ReadAsStringAsync());
        }
    }
}
