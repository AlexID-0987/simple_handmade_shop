using simple_handmade_shop.Data;
using simple_handmade_shop.Models.Interfaces;



namespace simple_handmade_shop.Models.Services
{
    public class HelperWithProducts: IGetProducts
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public HelperWithProducts(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IEnumerable<Product> GetAllProducts()
        {
           
            var products = _applicationDbContext.Products.ToList();
            return products;
        }
    }
}
 