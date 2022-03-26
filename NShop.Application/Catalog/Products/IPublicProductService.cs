using NShop.ViewModels.Catalog.Products;
using NShop.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NShop.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetPublicProductPagingRequest request);
        Task<List<ProductViewModel>> GetAll();
    }
}
