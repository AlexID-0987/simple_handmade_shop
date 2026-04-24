namespace simple_handmade_shop.Models.Orderproducts
{
    public class ChecoutViewModel
    {
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string CustomerPhone { get; set; }= string.Empty;
        public IEnumerable<Bag> OrderItems { get; set; } = new List<Bag>();
        public decimal TotalAmount { get; set; }
    }
}
