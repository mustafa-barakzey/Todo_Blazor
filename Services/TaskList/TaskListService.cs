using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Text;
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

        public async Task AddTaskAsync(long listId,string taskTitle)
        {
            var result = await _httpClient.PostAsync($"Task/Add", new StringContent(
            JsonConvert.SerializeObject(new { listId,title=taskTitle}),
            Encoding.UTF8,
            "application/json"));

            if (result.StatusCode != HttpStatusCode.Created)
                throw new Exception(await result.Content.ReadAsStringAsync());
            return;
        }
    }
}
