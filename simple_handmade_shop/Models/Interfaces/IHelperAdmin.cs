namespace simple_handmade_shop.Models.Interfaces
{
    public interface IHelperAdmin
    {
        IEnumerable<Product> IGetProducts();

        void AddProductList(Product product);

        void RemoveProductList(int id);


    }
}
