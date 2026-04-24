using simple_handmade_shop.Models.Interfaces;

namespace simple_handmade_shop.Models.Services
{
    public class OrderChoice: IGetOrder
    {
        private readonly IGetBag _getOrders;

        public OrderChoice(IGetBag getOrders)
        {
            _getOrders = getOrders;
        }
        public IEnumerable<Bag> GetOrders()
        {
            IEnumerable<Bag> bags = _getOrders.GetAllBags();
            if (bags == null || !bags.Any())
            {
                return Enumerable.Empty<Bag>();
            }
            return bags;
        }
    }
}
