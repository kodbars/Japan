using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class TokenResponse
    {
        [JsonPropertyName("correlationId")]
        public string CorrelationId { get; set; }
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
