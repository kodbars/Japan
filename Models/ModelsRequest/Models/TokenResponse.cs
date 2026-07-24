using System.Text.Json.Serialization;

namespace Models_DB_and_Request.ModelsRequest.Models
{
    public class TokenResponse
    {
        [JsonPropertyName("correlationId")]
        public string CorrelationId { get; set; }
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
