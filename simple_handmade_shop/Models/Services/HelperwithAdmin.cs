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

        public void RemoveProductList(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
        
        public Product EditProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                return product;
            }
            return null;
        }
        public void EditProduct(Product product)
        {
            Product oneProduct= _context.Products.Find(product.Id);
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
