using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using NShop.AdminApp.Services;
using NShop.Utilities.Constants;
using NShop.ViewModels.Catalog.Products;
using NShop.ViewModels.Common;
using System.Linq;
using System.Threading.Tasks;

namespace NShop.AdminApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly IConfiguration _configuration;
        private readonly ICategoryApiClient _categoryApiClient;

        public ProductController(IProductApiClient productApiClient, IConfiguration configuration, ICategoryApiClient categoryApiClient)
        {
            _productApiClient = productApiClient;
            _configuration = configuration;
            _categoryApiClient = categoryApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int? categoryId, int pageIndex = 1, int pageSize = 10)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var request = new GetManageProductPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                LanguageId = languageId,
                CategoryId = categoryId
            };
            var data = await _productApiClient.GetPagings(request);
            ViewBag.Keyword = keyword;

            var categories = await _categoryApiClient.GetAll(languageId);
            ViewBag.Categories = categories.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = categoryId.HasValue && categoryId.Value == x.Id
            });
            if (TempData["result"] != null)
            {
                ViewBag.Successmsg = TempData["result"];
            }
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View();
            var result = await _productApiClient.CreateProduct(request);
            if (result)
            {
                TempData["result"] = "Add product success";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Add product fail");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> CategoryAssign(int id)
        {
            var roleAssignRequest = await CategoryAssignRequest(id);
            return View(roleAssignRequest);
        }

        [HttpPost]
        public async Task<IActionResult> CategoryAssign(CategoryAssignRequest request)
        {
            if (!ModelState.IsValid)
                return View();
            var result = await _productApiClient.CategoryAssign(request.Id, request);

            if (result.IsSuccessed)
            {
                TempData["result"] = "Update category success";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", result.Message);
            var roleAssignRequest = await CategoryAssignRequest(request.Id);

            return View(roleAssignRequest);
        }

        private async Task<CategoryAssignRequest> CategoryAssignRequest(int id)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var productObj = await _productApiClient.GetById(id, languageId);
            var categories = await _categoryApiClient.GetAll(languageId);
            var categoryAssignRequest = new CategoryAssignRequest();
            foreach (var category in categories)
            {
                categoryAssignRequest.Categories.Add(new SelectItem()
                {
                    Id = category.Id.ToString(),
                    Name = category.Name,
                    Selected = productObj.Categories.Contains(category.Name)
                });
            }
            return categoryAssignRequest;
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var languageid = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var result = await _productApiClient.GetById(id, languageid);
            return View(result);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            return View(new ProductDeleteRequest()
            {
                Id = Id,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();
            var result = await _productApiClient.DeleteProduct(request.Id);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Delete product success";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", result.Message);
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var product = await _productApiClient.GetById(id, languageId);
            var editVm = new ProductUpdateRequest()
            {
                Id = product.Id,
                Description = product.Description,
                Details = product.Details,
                Name = product.Name,
                SeoAlias = product.SeoAlias,
                SeoDescription = product.SeoDescription,
                SeoTitle = product.SeoTitle
            };
            return View(editVm);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit([FromForm] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();
            var result = await _productApiClient.UpdateProduct(request);
            if (result)
            {
                TempData["result"] = "Update product success";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Update product fail");
            return View(request);
        }
    }
}