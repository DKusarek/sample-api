using FastEndpoints;
using hp_api.Contracts.Requests;
using hp_api.Contracts.Responces;
using hp_api.Mapper;
using hp_api.Services;
using Microsoft.AspNetCore.Authorization;

namespace hp_api.Endpoints
{
    [HttpPost("add-new"), AllowAnonymous] // TODO add authorization
    public class AddNewIceCreamEndpoint: Endpoint<IceCreamRequest, AddNewIceCreamResponse, AddNewToResponseMapper>
    {
        private readonly IIceCreamService _iceCreamService;
        public AddNewIceCreamEndpoint(IIceCreamService iceCreamService)
        {
            _iceCreamService = iceCreamService;
        }

        public override async Task HandleAsync(IceCreamRequest req, CancellationToken ct)
        {
            var response = _iceCreamService.Create(Map.ToEntity(req));
            await SendAsync(Map.FromEntity(response), cancellation: ct);
        }
    }
}
