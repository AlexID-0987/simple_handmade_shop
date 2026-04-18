using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using simple_handmade_shop.Data;
using simple_handmade_shop.Models;
using simple_handmade_shop.Models.Interfaces;
using simple_handmade_shop.Models.Services;

namespace simple_handmade_shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGetProducts _getProducts;
        

        public HomeController(ILogger<HomeController> logger, IGetProducts getProducts)
        {
            
            _logger = logger;
            _getProducts = getProducts;
            
            
        }

        public IActionResult Index()
        {
            if(!_getProducts.GetAllProducts().Any())
            {
                return NotFound("No products found");
            }
            return View(_getProducts.GetAllProducts());
        }
        public IActionResult Details(int id)
        {
            try
            {
                var product = _getProducts.Details(id);
                return View(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting product details for id {Id}", id);
                return NotFound("Product not found");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
