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
        public Product Details(int id)
        {
            var product = _applicationDbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            return product;
        }
    }
}
 