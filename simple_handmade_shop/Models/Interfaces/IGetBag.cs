namespace simple_handmade_shop.Models.Interfaces
{
    public interface IGetBag
    {
        IEnumerable<Bag> GetAllBags();
        void AddBag(int id);
        void RemoveBag(int id);

        void UpdateBag(int id, int quantity);
    }
}
