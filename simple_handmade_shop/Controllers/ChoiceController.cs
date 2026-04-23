using Microsoft.AspNetCore.Mvc;

namespace simple_handmade_shop.Controllers
{
    public class ChoiceController : Controller
    {
        public IActionResult Choice()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View(); // сторінка з вибором
            }

            return RedirectToAction("Index","Order");
        }
    }
    
}

