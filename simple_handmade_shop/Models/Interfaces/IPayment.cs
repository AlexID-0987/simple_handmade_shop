

namespace simple_handmade_shop.Models.Interfaces
{
    public interface IPayment
    {
        (string data, string signature) ActionPay(int orderId, string baseUrl);
         dynamic DecodeResponse(string data);
    }
}
