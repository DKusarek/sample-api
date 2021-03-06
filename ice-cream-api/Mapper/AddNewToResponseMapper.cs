using FastEndpoints;
using hp_api.Contracts.Requests;
using hp_api.Contracts.Responces;
using hp_api.Models;

namespace hp_api.Mapper
{
    public class AddNewToResponseMapper : Mapper<IceCreamRequest, AddNewIceCreamResponse, IceCream>
    {
        public override IceCream ToEntity(IceCreamRequest request)
        {
            var iceCream = new IceCream(request.Name);
            iceCream.CalculatePortionsFromWeight(request.Weight);
            return iceCream;
        }

        public override AddNewIceCreamResponse FromEntity(IceCream e)
        {
            return new AddNewIceCreamResponse
            {
                Message = $"Successfully created '{e.Name}' ice cream. Number of portions {e.Portions}"
            };
        }
    }
}
