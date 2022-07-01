using hp_api.Contracts.Responces;
using FastEndpoints;

namespace hp_api.Mapper
{
    public static class GetAllFlavorsMapper
    {
        public static GetAllFlavorsResponse ToGetAllFlavorsResponse(List<string> flavors)
        {
            return new GetAllFlavorsResponse { Flavors = flavors };
        }
    }
}
