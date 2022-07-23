using Infrastructure.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Requests;
using MVC.Services.Interfaces;
using MVC.ViewModels;
using MVC.ViewModels.Admin;

namespace MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminCatalogService _adminCatalogService;

        public AdminController(IAdminCatalogService adminCatalogService)
        {
            _adminCatalogService = adminCatalogService;
        }

        public IActionResult AdminPage()
        {
            return View();
        }

        public async Task<IActionResult> ItemListPage()
        {
            var model = new ItemListPageViewModel
            {
                Items = await _adminCatalogService.GetItems()
            };

            return View(model);
        }

        public async Task<IActionResult> ItemUpdatePage(int id)
        {
            var item = await _adminCatalogService.GetItem(id);
            var pictureFileName = item.PictureUrl.Split('/').LastOrDefault();
            var model = new ItemUpdatePageViewModel
            {
                Item = item,
                Materials = await _adminCatalogService.GetMaterialSelectList(),
                Sources = await _adminCatalogService.GetSourceSelectList(),
                PictureFileName = pictureFileName
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ItemUpdate(MvcItemUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Ok("Model isn`t validate");
            }

            await _adminCatalogService.UpdateItem(new UpdateItemRequest
            {
                Id = request.Id,
                Name = request.Name,
                Price = request.Price,
                Weight = request.Weight,
                Size = request.Size,
                CatalogMaterialId = request.MaterialApplied,
                CatalogSourceId = request.SourceApplied,
                AvailableStock = request.AvailableStock,
                PictureFileName = request.PictureFileName
            });

            return Redirect("~/");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveItem(int id)
        {
            if (!ModelState.IsValid)
            {
                return Ok("Model isn`t validate");
            }

            await _adminCatalogService.RemoveItem(new RemoveRequest { Id = id });
            return Redirect("~/");
        }

        public async Task<IActionResult> AddItemPage()
        {
            var model = new AddItemPageViewModel
            {
                Materials = await _adminCatalogService.GetMaterialSelectList(),
                Sources = await _adminCatalogService.GetSourceSelectList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(AddItemRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Ok("Model isn`t validate");
            }

            await _adminCatalogService.AddItem(request);
            return Redirect("~/");
        }

        public async Task<IActionResult> MaterialListPage()
        {
            var model = new MaterialListPageViewModel
            {
                Materials = await _adminCatalogService.GetMaterials()
            };

            return View(model);
        }

        public async Task<IActionResult> MaterialUpdatePage(int id)
        {
            var model = new MaterialUpdatePageViewModel
            {
                Material = await _adminCatalogService.GetMaterial(id)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> MaterialUpdate(UpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Ok("Model isn`t validate");
            }

            await _adminCatalogService.UpdateMaterial(request);

            return Redirect("~/");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveMaterial(int id)
        {
            await _adminCatalogService.RemoveMaterial(new RemoveRequest { Id = id });
            return Redirect("~/");
        }

        public IActionResult AddMaterialPage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMaterial(AddRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Ok("Model isn`t validate");
            }

            await _adminCatalogService.AddMaterial(request);
            return Redirect("~/");
        }

        public async Task<IActionResult> SourceListPage()
        {
            var model = new SourceListPageViewModel
            {
                Sources = await _adminCatalogService.GetSources()
            };

            return View(model);
        }

        public async Task<IActionResult> SourceUpdatePage(int id)
        {
            var model = new SourceUpdatePageViewModel
            {
                Source = await _adminCatalogService.GetSource(id)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SourceUpdate(UpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Ok("Model isn`t validate");
            }

            await _adminCatalogService.UpdateSource(request);

            return Redirect("~/");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveSource(int id)
        {
            if (!ModelState.IsValid)
            {
                return Ok("Model isn`t validate");
            }

            await _adminCatalogService.RemoveSource(new RemoveRequest { Id = id });
            return Redirect("~/");
        }

        public IActionResult AddSourcePage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSource(AddRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Ok("Model isn`t validate");
            }

            await _adminCatalogService.AddSource(request);
            return Redirect("~/");
        }
    }
}
