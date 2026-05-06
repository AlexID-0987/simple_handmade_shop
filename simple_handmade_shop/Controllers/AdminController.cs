using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using simple_handmade_shop.Data;
using simple_handmade_shop.Models;
using simple_handmade_shop.Models.Interfaces;

namespace simple_handmade_shop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IHelperAdmin _helperAdmin;
        private readonly IDashboard _dashboard;

        public AdminController(IHelperAdmin helperAdmin, IDashboard dashboard)
        {
            _helperAdmin = helperAdmin;
            _dashboard = dashboard;
        }
        public async Task<IActionResult> Products()
        {
            var products = _helperAdmin.IGetProducts();
            await Task.CompletedTask;
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _helperAdmin.AddProductList(product);
                return RedirectToAction(nameof(Products));
            }
            return View(product);
        }
        public IActionResult Delete(int id)
        {
            _helperAdmin.RemoveProductList(id);
            return RedirectToAction(nameof(Products));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _helperAdmin.EditProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _helperAdmin.EditProduct(product);
                return RedirectToAction(nameof(Products));
            }
            return View(product);
        }
        public IActionResult Dashboard()
        {
            var dashboard = _dashboard.GetUsers();
            return View(dashboard);
        }
    }
}
