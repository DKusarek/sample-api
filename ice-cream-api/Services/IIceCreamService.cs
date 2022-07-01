using hp_api.Models;

namespace hp_api.Services
{
    public interface IIceCreamService
    {
        void AddMore(IceCream iceCream);
        IceCream Create(IceCream iceCream);
        List<string> GetAllFlavors();
        void GetPortion(string name, int portions = 1);
    }
}