using Microsoft.AspNetCore.Mvc;
using simple_handmade_shop.Models.Interfaces;
using simple_handmade_shop.Models.Services;

namespace simple_handmade_shop.Controllers
{
    public class PayController : Controller
    {
        private readonly IPayment _helperPayment;

        public PayController(IPayment helperPayment)
        {
            _helperPayment = helperPayment;
        }

        public IActionResult ActionPay(int id)
        {

            
            var (data, signature) = _helperPayment.ActionPay(id, Request.Scheme + "://" + Request.Host + Request.PathBase);
            ViewBag.PaymentData = data;
            ViewBag.PaymentSignature = signature;
            return View();
        }
        public IActionResult Success()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Callback(string data, string signature)
        {
            var result = _helperPayment.DecodeResponse(data);

            

            return Ok();
        }
    }

}
