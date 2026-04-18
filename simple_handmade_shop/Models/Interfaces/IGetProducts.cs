using simple_handmade_shop.Data;


namespace simple_handmade_shop.Models.Interfaces
{
    public interface IGetProducts
    {
        IEnumerable<Product> GetAllProducts();
        Product Details(int id);
    }
}
