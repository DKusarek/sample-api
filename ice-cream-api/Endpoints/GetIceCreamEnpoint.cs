using FastEndpoints;
using hp_api.Contracts.Requests;
using hp_api.Contracts.Responces;
using hp_api.Mapper;
using hp_api.Models;
using hp_api.Services;
using Microsoft.AspNetCore.Authorization;

namespace hp_api.Endpoints
{
    [HttpGet("get-ice-cream"), AllowAnonymous]
    public class GetIceCreamEnpoint: Endpoint<GetIceCreamRequest, GetIceCreamResponse, GetIceCreamMapper>
    {
        private readonly IIceCreamService _iceCreamService;

        public GetIceCreamEnpoint(IIceCreamService iceCreamService)
        {
            _iceCreamService = iceCreamService;
        }

        public override async Task HandleAsync(GetIceCreamRequest req, CancellationToken ct)
        {
            var response = _iceCreamService.GetPortion(Map.ToEntity(req));
            await SendAsync(Map.FromEntity(response), cancellation: ct);
        }
    }
}
