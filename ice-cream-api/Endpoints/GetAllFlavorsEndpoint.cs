using FastEndpoints;
using hp_api.Contracts.Responces;
using hp_api.Mapper;
using hp_api.Services;
using Microsoft.AspNetCore.Authorization;

namespace hp_api.Endpoints
{
    [HttpGet("flavors"), AllowAnonymous]
    public class GetAllFlavorsEndpoint: EndpointWithoutRequest<GetAllFlavorsResponse>
    {
        private readonly IIceCreamService _iceCreamService;
        public GetAllFlavorsEndpoint(IIceCreamService iceCreamService)
        {
            _iceCreamService = iceCreamService;
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var flavors = _iceCreamService.GetAllFlavors();
            var flavorsResponse = GetAllFlavorsMapper.ToGetAllFlavorsResponse(flavors);
            await SendOkAsync(flavorsResponse, ct);
        }
    }
}
