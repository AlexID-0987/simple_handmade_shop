using Microsoft.AspNetCore.Mvc;
using simple_handmade_shop.Models.Interfaces;

namespace simple_handmade_shop.Controllers
{
    public class BagController : Controller
    {
        private readonly IGetBag _getBag;
        private decimal _totalPrice;
        private int _totalQuantity;
        public BagController(IGetBag getBag)
        {
            _getBag = getBag;
        }
        public IActionResult Index()
        {
            var bags = _getBag.GetAllBags();
            _totalPrice = bags.Sum(b => b.Price * b.Quantity);
            _totalQuantity = bags.Sum(b => b.Quantity);
            ViewBag.TotalPrice = _totalPrice;
            ViewBag.TotalQuantity = _totalQuantity;
            return View(bags);
        }
        public IActionResult Add(int id)
        {
            _getBag.AddBag(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(int id)
        {
            _getBag.RemoveBag(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateQuantity(int id, int quantity)
        {
            _getBag.UpdateBag(id, quantity);
            return RedirectToAction("Index");
        }

    }
}
