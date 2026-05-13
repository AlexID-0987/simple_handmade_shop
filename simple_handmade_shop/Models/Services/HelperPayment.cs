using Newtonsoft.Json;
using simple_handmade_shop.Data;
using simple_handmade_shop.Models.Interfaces;
using simple_handmade_shop.Models.Orderproducts;
using simple_handmade_shop.Models.Payment;
using System.Security.Cryptography;
using System.Text;

namespace simple_handmade_shop.Models.Services
{
    public class HelperPayment:IPayment
    {
        private IConfiguration _configuration { get; set; }
        private readonly ApplicationDbContext _dbContext;

        public HelperPayment(IConfiguration configuration, ApplicationDbContext dbContext)
        {

            _configuration = configuration;
            _dbContext = dbContext;
        }
        public (string data, string signature) ActionPay(int id, string baseUrl)
        {
            Order order = _dbContext.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                throw new Exception($"Order with id {id} not found");
            }
            var json = JsonConvert.SerializeObject(new
            {
                public_key = _configuration["Payment:PublicKey"],
                version = "3",
                action = "pay",
                amount = Convert.ToDecimal(order.TotalAmount).ToString(System.Globalization.CultureInfo.InvariantCulture),
                currency = "UAH",
                description = $"Order #{order.Id}",
                order_id = order.Id.ToString(),
                sandbox = 1,
                result_url = $"{baseUrl}/payment/success",
                server_url = $"{baseUrl}/payment/callback"
            });

            var data = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));

            var signature = Convert.ToBase64String(
                SHA1.Create().ComputeHash(
                    Encoding.UTF8.GetBytes(_configuration["Payment:PrivateKey"] + data + _configuration["Payment:PrivateKey"])
                ));

            return (data, signature);
        }
        public dynamic DecodeResponse(string data)
        {
            var json = Encoding.UTF8.GetString(Convert.FromBase64String(data));
            return JsonConvert.DeserializeObject(json);
        }

    }
}
