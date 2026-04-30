using simple_handmade_shop.Data;
using simple_handmade_shop.Models.Orderproducts;

namespace simple_handmade_shop.Models.Interfaces
{
    public interface IGenerateDocument
    {
        byte[] SendDoc(Order ordered, ApplicationDbContext applicationDbContext);
    }
}
