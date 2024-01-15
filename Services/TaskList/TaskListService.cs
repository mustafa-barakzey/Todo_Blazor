using System.Net.Http.Json;
using Todo_Blazor.Services.TaskList.ViewModels;
using Todo_Blazor.ViewModel;

namespace Todo_Blazor.Services.TaskList
{
    public class TaskListService
    {
        private readonly HttpClient _httpClient;

        public TaskListService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetTaskResult> GetTasksAsync(long listId)
        {
            var result = await _httpClient.GetFromJsonAsync<OperationResult<GetTaskResult>>($"Task/Get?ListId={listId}");

            return result?.Data ?? new();
        }
    }
}
