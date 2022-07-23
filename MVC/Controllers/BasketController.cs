using Infrastructure.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Requests;
using MVC.Services.Interfaces;
using MVC.ViewModels;

namespace MVC.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        private readonly ICatalogService _catalogService;
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService, ICatalogService catalogService)
        {
            _basketService = basketService;
            _catalogService = catalogService;
        }

        public async Task<IActionResult> Add(int catalogItemId, int countItems)
        {
            var catalogItem = await _catalogService.GetItem(catalogItemId);
            await _basketService.AddBasket(catalogItem, countItems);

            return Redirect("~/");
        }

        public async Task<IActionResult> Remove(int catalogItemId)
        {
            var item = await _catalogService.GetItem(catalogItemId);

            await _basketService.RemoveBasket(item);

            return Redirect("~/");
        }

        public async Task<IActionResult> Get()
        {
            var model = await _basketService.GetBasket();

            return View(model);
        }
    }
}
