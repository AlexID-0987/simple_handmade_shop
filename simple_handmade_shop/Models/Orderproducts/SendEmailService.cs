using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;

namespace simple_handmade_shop.Models.Orderproducts
{
    public class SendEmailService
    {
        
        public async Task SendOrderToOwner(Order order, IConfiguration configuration)
        {
            var fromAddress = new MailAddress(configuration["Smtp:Email"], "Alex Forest");
            var toAddress = new MailAddress(configuration["Smtp:Email"], "Customer");

            var fromPassword = configuration["Smtp:Password"];

            var subject = "New Order Received";
            var body = $"You have received a new order from {order.CustomerName} ({order.CustomerEmail}).\n" +
                       $"Total Amount: {order.TotalAmount:C}\n" +
                       $"Quantity: {order.Quantity}\n" +
                       $"Order Date: {order.OrderDate}\n\n" +
                       $"Order Phone: {order.PhoneNumber}\n\n" +
                       "Order Details:\n";
            foreach (var item in order.OrderItems)
            {
                body += $"- {item.ProductId} (Quantity: {item.Quantity}, Price: {item.UnitPrice:C})\n";
            }
            var smtp = new SmtpClient
            {


                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(fromAddress.Address, fromPassword)
            };
            
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
            
        }
    }
}
