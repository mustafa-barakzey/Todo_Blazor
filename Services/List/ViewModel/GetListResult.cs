namespace Todo_Blazor.Services.List.ViewModel
{
    public class GetListResult
    {
        public List<ListData> List { get; set; }
    }

    public class ListData
    {
        public long Id { get; set; }
        public string Title { get; set; }
    }
}
