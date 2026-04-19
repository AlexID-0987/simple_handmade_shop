using simple_handmade_shop.Data;
using simple_handmade_shop.Models.Interfaces;
using System.Text.Json;

namespace simple_handmade_shop.Models.Services
{
    public class HelperWithBags : IGetBag
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private const string _bagSessionKey = "BagItems";
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HelperWithBags(ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _applicationDbContext = applicationDbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        private IEnumerable<Bag> GetBagsFromSession()
        {
            string session = _httpContextAccessor.HttpContext?.Session.GetString(_bagSessionKey);

            if (string.IsNullOrEmpty(session))
            {
                return new List<Bag>();
            }
            return JsonSerializer.Deserialize<List<Bag>>(session) ?? new List<Bag>();
        }
        private void SaveBagsToSession(IEnumerable<Bag> bags)
        {
            string session = JsonSerializer.Serialize(bags);
            _httpContextAccessor.HttpContext?.Session.SetString(_bagSessionKey, session);
        }
        public IEnumerable<Bag> GetAllBags()
        {
            return GetBagsFromSession();
        }
        public void AddBag(int id, string name, decimal price)
        {
            List<Bag> bags = GetBagsFromSession().ToList();
            Bag? existingBag = bags.FirstOrDefault(b => b.Id == id);

            if (existingBag != null)
            {
                existingBag.Quantity++;
            }
            else
            {

                bags.Add(new Bag { Id = id, Name = name, Price = price, Quantity = 1 });

            }
            SaveBagsToSession(bags);
        }
        public void RemoveBag(int id)
        {
            List<Bag> bags = GetBagsFromSession().ToList();
            Bag? bagToRemove = bags.FirstOrDefault(b => b.Id == id);
            if (bagToRemove != null)
            {
                bags.Remove(bagToRemove);
                SaveBagsToSession(bags);
            }
        }
        public void UpdateBag(int id, int quantity)
        {
            List<Bag> bags = GetBagsFromSession().ToList();
            Bag? bagToUpdate = bags.FirstOrDefault(b => b.Id == id);
            if (bagToUpdate != null)
            {
                bagToUpdate.Quantity = quantity;
                SaveBagsToSession(bags);
            }
        }
    }
}
