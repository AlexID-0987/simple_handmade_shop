using Microsoft.AspNetCore.Mvc;

namespace simple_handmade_shop.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
