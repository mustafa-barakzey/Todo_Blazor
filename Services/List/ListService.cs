using Todo_Blazor.Services.List.ViewModel;
using Todo_Blazor.Services.Shared;

namespace Todo_Blazor.Services.List
{
    public class ListService : BaseService
    {

        public ListService(HttpClient httpClient) : base(httpClient, "List")
        {
        }

        public async Task<GetListResult> GetAsync() => await Get<GetListResult>();
    }
}
