namespace hp_api.Contracts.Requests
{
    public class GetIceCreamRequest
    {
        public string Name { get; set; } = default!;
        public int? Portions { get; set; }
    }
}
