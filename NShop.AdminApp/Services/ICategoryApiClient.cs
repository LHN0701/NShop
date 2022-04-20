using NShop.ViewModels.Catalog.Categories;
using NShop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NShop.AdminApp.Services
{
    public interface ICategoryApiClient
    {
        Task<List<CategoryVm>> GetAll(string languageId);
    }
}