using FastEndpoints;
using hp_api.Contracts.Requests;
using hp_api.Contracts.Responces;
using hp_api.Models;

namespace hp_api.Mapper
{
    public class GetIceCreamMapper: Mapper<GetIceCreamRequest, GetIceCreamResponse, IceCream>
    {
        public override IceCream ToEntity(GetIceCreamRequest request)
        {
            return new IceCream(request.Name, request.Portions ?? 1);
        }

        public override GetIceCreamResponse FromEntity(IceCream iceCream)
        {
            return new GetIceCreamResponse
            {
                Message = $"{iceCream.Portions} portions of the {iceCream.Name} ice cream."
            };
        }
    }
}
