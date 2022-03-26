using NShop.ViewModels.Catalog.Products;
using NShop.ViewModels.Catalog.Products.Public;
using NShop.ViewModels.Common;
using System.Threading.Tasks;

namespace NShop.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetProductPagingRequest request);
    }
}
