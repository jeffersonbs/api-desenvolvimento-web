namespace api_desenvolvimento_web.Models
{
    public class RespostaModel
    {
        public bool Success { get; set; } = true;
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
}
