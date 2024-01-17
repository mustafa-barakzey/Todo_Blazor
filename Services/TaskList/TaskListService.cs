using Todo_Blazor.Services.Shared;
using Todo_Blazor.Services.TaskList.ViewModels;

namespace Todo_Blazor.Services.TaskList
{
    public class TaskListService : BaseService
    {
        public TaskListService(HttpClient httpClient) : base(httpClient, "Task") { }

        public async Task<GetTaskResult> GetTasksAsync(long listId) => await Get<GetTaskResult>($"Get?ListId={listId}");

        public async Task AddTaskAsync(AddTaskDTO dto) => await Add<AddTaskDTO>(dto);
    }
}
