using Core.Persistence.Paging;

namespace Application
{
    public class BrandListModel:BasePageableModel
    {
        public IList<GetBrandListDto> Items { get; set; }
    }
}