using hp_api.Models;

namespace hp_api.Services
{
    public interface IIceCreamService
    {
        IceCream AddMore(IceCream iceCream);
        IceCream Create(IceCream iceCream);
        List<string> GetAllFlavors();
        IceCream GetPortion(IceCream iceCream);
    }
}