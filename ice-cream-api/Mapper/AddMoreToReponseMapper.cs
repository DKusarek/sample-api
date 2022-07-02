using FastEndpoints;
using hp_api.Contracts.Requests;
using hp_api.Contracts.Responces;
using hp_api.Models;

namespace hp_api.Mapper
{
    public class AddMoreToReponseMapper: Mapper<IceCreamRequest, AddMoreIceCreamResponse, IceCream>
    {

        public override IceCream ToEntity(IceCreamRequest request)
        {
            var iceCream = new IceCream(request.Name);
            iceCream.CalculatePortionsFromWeight(request.Weight);
            return iceCream;
        }

        public override AddMoreIceCreamResponse FromEntity(IceCream iceCream)
        {
            return new AddMoreIceCreamResponse
            {
                Message = $"Ice cream '{iceCream.Name}' added. Current number of portions: {iceCream.Portions}."
            };
        }
    }
}
