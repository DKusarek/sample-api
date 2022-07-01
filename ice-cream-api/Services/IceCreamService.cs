using FluentValidation;
using FluentValidation.Results;
using hp_api.Data;
using hp_api.Models;

namespace hp_api.Services
{
    public class IceCreamService : IIceCreamService
    {
        private List<IceCream> _iceCreams = IceCreamsData.ICECREAMS;

        public IceCreamService()
        {
        }

        public List<string> GetAllFlavors()
        {
            return _iceCreams.Where(x => x.Portions > 0).Select(x => x.Name).ToList();
        }

        public void GetPortion(string name, int portions = 1)
        {
            var iceCream = GetIceCreamFromStock(name);
            SubtractPortion(iceCream, portions);
        }

        public IceCream Create(IceCream iceCream)
        {
            if (_iceCreams.Find(x => x.Name == iceCream.Name) != null)
            {
                var message = $"A ice cream with that name  {iceCream.Name} already exists";
                ThrowValidationError(message);
            }
            _iceCreams.Add(iceCream);
            return iceCream;
        }

        public void AddMore(IceCream iceCream)
        {
            var iceCreamInStock = GetIceCreamFromStock(iceCream.Name);
            iceCreamInStock.Portions += iceCream.Portions;
        }

        private IceCream GetIceCreamFromStock(string name)
        {
            var iceCreamInStock = _iceCreams.Find(x => x.Name == name);
            if (iceCreamInStock == null)
            {
                var message = $"A ice cream with that name {name} does not exists";
                ThrowValidationError(message);
            }
            return iceCreamInStock!;
        }

        private void SubtractPortion(IceCream iceCream, int portions)
        {
            if (iceCream.Portions < portions)
            {
                var message = $"Lack of ice creams. Cannot get {portions} portions";
                ThrowValidationError(message);
            }
            iceCream.Portions -= portions;
        }

        private void ThrowValidationError(string message)
        {
            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(IceCream), message)
            });
        }
    }
}
