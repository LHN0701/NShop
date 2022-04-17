using NShop.ViewModels.Catalog.ProductImages;
using NShop.ViewModels.Catalog.Products;
using NShop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NShop.AdminApp.Services
{
    public interface IProductApiClient
    {
        Task<PagedResult<ProductVm>> GetPagings(GetManageProductPagingRequest request);

        Task<bool> CreateProduct(ProductCreateRequest request);

        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);

        Task<ProductVm> GetById(int Id, string languageId);

        Task<List<ProductImageViewModel>> GetListImages(int productId);

        Task<ApiResult<bool>> DeleteProduct(int productId);

        Task<bool> UpdateProduct(ProductUpdateRequest request);
    }
}