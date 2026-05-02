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
        
    }
}
