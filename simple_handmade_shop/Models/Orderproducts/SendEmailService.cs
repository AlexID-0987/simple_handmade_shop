using ClosedXML.Excel;
using Microsoft.AspNetCore.Identity.UI.Services;
using simple_handmade_shop.Data;
using simple_handmade_shop.Models.Interfaces;
using System.Net;
using System.Net.Mail;

namespace simple_handmade_shop.Models.Orderproducts
{
    public class SendEmailService
    {
        private readonly ApplicationDbContext _context;
        private readonly IGenerateDocument _generateDocument;

        public SendEmailService(ApplicationDbContext context, IGenerateDocument generateDocument)
        {
            _context = context;
            _generateDocument = generateDocument;
        }

        public async Task SendOrderToOwner(Order order, IConfiguration configuration)
        {
            var fromEmail = configuration["Smtp:Email"];
            var fromPassword = configuration["Smtp:Password"];

            var fromAddress = new MailAddress(fromEmail, "Alex Forest");
            var toAddress = new MailAddress(fromEmail, "Customer");

            var subject = "New Order Received";

            // ✅ спочатку формуємо body
            var body = $"You have received a new order from {order.CustomerName} ({order.CustomerEmail}).\n" +
                       $"Total Amount: {order.TotalAmount:C}\n" +
                       $"Quantity: {order.Quantity}\n" +
                       $"Order Date: {order.OrderDate}\n\n" +
                       $"Order Phone: {order.PhoneNumber}\n\n" +
                       "Order Details:\n";
            var products = _context.Products.ToList();

            foreach (var item in order.OrderItems)
            {
                var product = products.FirstOrDefault(p => p.Id == item.ProductId);

                body += $"- {product?.Name ?? "Unknown"} " +
                        $"(Quantity: {item.Quantity}, Price: {item.UnitPrice:C})\n";
            }
            

            // ✅ створюємо Excel
            var excelByte = _generateDocument.SendDoc(order, _context);
            var stream = new MemoryStream(excelByte);
            var attachment = new Attachment(stream, "order.xlsx",
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

            // ✅ один MailMessage
            var mailMessage = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            };

            mailMessage.Attachments.Add(attachment);

            // ✅ один SMTP
            var smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(fromEmail, fromPassword),
                EnableSsl = true
            };

            // ✅ один send
            await smtp.SendMailAsync(mailMessage);
        }
        
    }
}
