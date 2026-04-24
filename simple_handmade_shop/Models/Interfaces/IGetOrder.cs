namespace simple_handmade_shop.Models.Interfaces
{
    public interface IGetOrder
    {
        IEnumerable<Bag> GetOrders();
         
    }
}
