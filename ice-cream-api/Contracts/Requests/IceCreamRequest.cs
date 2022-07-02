using hp_api.Models;

namespace hp_api.Contracts.Requests
{
    public class IceCreamRequest
    {
        public string Name { get; set; } = default!;
        public double Weight { get; set; } = default!;
    }
}
