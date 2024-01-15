using System.Net.Http.Json;
using Todo_Blazor.Services.List.ViewModel;
using Todo_Blazor.ViewModel;

namespace Todo_Blazor.Services.List
{
    public class ListService
    {
        private readonly HttpClient _httpClient;

        public ListService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetListResult> GetAsync()
        {
            var result= await _httpClient.GetFromJsonAsync<OperationResult<GetListResult>>("List/Get");


            return result?.Data ?? new();
        }
    }
}
