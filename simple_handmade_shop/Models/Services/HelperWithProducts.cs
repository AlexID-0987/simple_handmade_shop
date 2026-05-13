using Microsoft.EntityFrameworkCore;
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
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _applicationDbContext.Products
            .AsNoTracking()
            .ToListAsync();
        }
        public async Task<Product?> Details(int id)
        {
            return await _applicationDbContext.Products
                .Include(p => p.ProductImages)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
 