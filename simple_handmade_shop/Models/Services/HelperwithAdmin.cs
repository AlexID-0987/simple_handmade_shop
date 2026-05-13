using simple_handmade_shop.Data;
using simple_handmade_shop.Models.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace simple_handmade_shop.Models.Services
{
    public class HelperwithAdmin:IHelperAdmin
    {
        private readonly ApplicationDbContext _context;

        public HelperwithAdmin(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddProductList(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            
        }

        public IEnumerable<Product> IGetProducts()
        {
            return _context.Products.ToList();
        }

        public async Task RemoveProductList(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Product> EditProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                return product;
            }
            return null;
        }
        public async Task EditProduct(Product product)
        {
            Product oneProduct= await _context.Products.FindAsync(product.Id);
                if (oneProduct != null)
                {
                    oneProduct.Name = product.Name;
                    oneProduct.Description = product.Description;
                    oneProduct.Price = product.Price;
                     if (!string.IsNullOrEmpty(product.ImageUrl))
                     {
                           oneProduct.ImageUrl = product.ImageUrl;
                     }

                }

            _context.SaveChanges();
           

        }

    }
}
