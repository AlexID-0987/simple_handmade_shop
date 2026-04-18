using Microsoft.AspNetCore.Mvc;
using simple_handmade_shop.Models.Interfaces;

namespace simple_handmade_shop.Controllers
{
    public class BagController : Controller
    {
        private readonly IGetBag _getBag;
        public BagController(IGetBag getBag)
        {
            _getBag = getBag;
        }
        public IActionResult Index()
        {
            var bags = _getBag.GetAllBags();
            return View(bags);
        }
        public IActionResult Add(int id, string name, decimal price)
        {
            _getBag.AddBag(id, name, price);
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int id)
        {
            _getBag.RemoveBag(id);
            return RedirectToAction("Index");
        }
    }
}
