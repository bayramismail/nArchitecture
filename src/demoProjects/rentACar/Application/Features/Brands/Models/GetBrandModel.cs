using Core.Persistence.Paging;

namespace Application
{
    public class GetBrandListModel:BasePageableModel
    {
        public IList<GetBrandListDto> Items { get; set; }
    }
}