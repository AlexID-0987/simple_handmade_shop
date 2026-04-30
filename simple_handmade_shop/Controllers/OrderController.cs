using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using simple_handmade_shop.Data;
using simple_handmade_shop.Models;
using simple_handmade_shop.Models.Interfaces;
using simple_handmade_shop.Models.Orderproducts;
using System.Net.Mail;
using System.Security.Claims;

namespace simple_handmade_shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IGetOrder _getOrder;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly SendEmailService _sendEmailService;
        private readonly IConfiguration _configuration;
        private readonly IGenerateDocument _generateDocument;
        public OrderController(IGetOrder getOrder, ApplicationDbContext applicationDbContext, SendEmailService sendEmailService, IConfiguration configuration, IGenerateDocument generateDocument)
        {
            _getOrder = getOrder;
            _applicationDbContext = applicationDbContext;
            _sendEmailService = sendEmailService;
            _configuration = configuration;
            _generateDocument = generateDocument;
        }
        public IActionResult Index()
        {
            IEnumerable<Bag> orders = _getOrder.GetOrders();
            ChecoutViewModel viewModel = new ChecoutViewModel
            {
                OrderItems = orders,
                TotalAmount = orders.Sum(o => o.Price * o.Quantity)
            };
            
            if(User.Identity.IsAuthenticated)
            {
                viewModel.CustomerEmail = User.FindFirstValue(ClaimTypes.Email) ?? string.Empty;
                
            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task <IActionResult> Index(ChecoutViewModel viewModel)
        {
            
            IEnumerable<Bag> orders = _getOrder.GetOrders();
            if (orders == null || !orders.Any())
            {
                ModelState.AddModelError(string.Empty, "Your cart is empty. Please add items to your cart before checking out.");
                return View(viewModel);
            }
            if (ModelState.IsValid)
            {

                Order order = new Order
                {
                    UserId = User.Identity.IsAuthenticated ? User.Identity.Name : null,
                    CustomerName = viewModel.CustomerName,
                    CustomerEmail = User.Identity.IsAuthenticated ? User.FindFirstValue(ClaimTypes.Email) : viewModel.CustomerEmail,
                    OrderDate = DateTime.Now,
                    TotalAmount = orders.Sum(r => r.Price * r.Quantity),
                    Quantity = orders.Sum(o => o.Quantity),
                    PhoneNumber = viewModel.CustomerPhone,
                    OrderItems = orders.Select(o => new OrderItem
                    {
                        ProductId = o.Id,
                        Quantity = o.Quantity,
                        UnitPrice = o.Price
                    }).ToList()
                };
                _applicationDbContext.Orders.Add(order);
                _applicationDbContext.OrderItems.AddRange(order.OrderItems);
                _applicationDbContext.SaveChanges();
                
                
                await _sendEmailService.SendOrderToOwner(order, _configuration);
                return RedirectToAction("Success");
            }
            
            return View(viewModel);
            
            
                

        }
        public IActionResult Success()
        {
            return View();
        }
    }
}
