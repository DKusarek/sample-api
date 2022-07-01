using hp_api.Models;

namespace hp_api.Contracts.Requests
{
    public class AddNewIceCreamRequest
    {
        public string Name { get; set; } = default!;
        public double Weight { get; set; } = default!;
    }
}
