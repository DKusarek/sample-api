using FastEndpoints;
using hp_api.Contracts.Requests;
using hp_api.Contracts.Responces;
using hp_api.Mapper;
using hp_api.Services;
using Microsoft.AspNetCore.Authorization;

namespace hp_api.Endpoints
{
    [HttpPost("add-more"), AllowAnonymous]
    public class AddMoreIceCreamEndpoint: Endpoint<IceCreamRequest, AddMoreIceCreamResponse, AddMoreToReponseMapper>
    {
        private readonly IIceCreamService _iceCreamService;
        public AddMoreIceCreamEndpoint(IIceCreamService iceCreamService)
        {
            _iceCreamService = iceCreamService;
        }

        public override async Task HandleAsync(IceCreamRequest req, CancellationToken ct)
        {
            var response = _iceCreamService.AddMore(Map.ToEntity(req));
            await SendAsync(Map.FromEntity(response), cancellation: ct);
        }
    }
}
