using Basket.Models.Requests;
using Basket.Services.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Basket.Controllers
{
    [ApiController]
    [Authorize(Policy = AuthPolicy.AllowClientPolicy)]
    [Route(ComponentDefaults.DefaultRoute)]
    public class BasketBffController : Controller
    {
        private readonly ILogger<BasketBffController> _logger;
        private readonly IBasketService _basketService;

        public BasketBffController(
            ILogger<BasketBffController> logger, IBasketService basketService)
        {
            _logger = logger;
            _basketService = basketService;
        }

        [HttpPost]
        public async Task Add(AddRequest addRequest)
        {
            _logger.LogInformation("Start add");
            var userId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
            await _basketService.AddAsync(addRequest.CatalogItem, addRequest.CountItems, userId!);
            Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Start get");
            var userId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
            _logger.LogInformation($"userId: {userId}");
            var response = await _basketService.GetAsync(userId!);
            _logger.LogInformation($"response get: {response}");
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(RemoveRequest request)
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
            await _basketService.RemoveAsync(request.CatalogItem, userId!);
            return Ok();
        }
    }
}
