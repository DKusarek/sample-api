namespace hp_api.Contracts.Responces
{
    public class ValidationFailureResponse
    {
        public List<string> Errors { get; set; } = new();
    }
}
