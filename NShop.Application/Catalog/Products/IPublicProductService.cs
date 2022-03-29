using NShop.ViewModels.Catalog.Products;
using NShop.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NShop.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(string languageId, GetPublicProductPagingRequest request);
    }
}
