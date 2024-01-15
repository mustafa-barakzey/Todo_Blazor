namespace Todo_Blazor.Services.TaskList.ViewModels
{
    public class GetTaskResult
    {
        public List<TaskData> Tasks { get; set; }
    }

    public class TaskData
    {
        public double TaskId { get; set; }
        public string Title { get; set; }
    }
}
