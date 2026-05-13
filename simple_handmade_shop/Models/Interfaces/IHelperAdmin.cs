namespace simple_handmade_shop.Models.Interfaces
{
    public interface IHelperAdmin
    {
        IEnumerable<Product> IGetProducts();

        void AddProductList(Product product);

        Task RemoveProductList(int id);
        Task<Product> EditProduct (int id);
        Task EditProduct (Product product);

    }
}
