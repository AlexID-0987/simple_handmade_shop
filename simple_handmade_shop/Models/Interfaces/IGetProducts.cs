using simple_handmade_shop.Data;


namespace simple_handmade_shop.Models.Interfaces
{
    public interface IGetProducts
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> Details(int id);
    }
}
