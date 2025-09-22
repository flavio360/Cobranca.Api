using System.Text.Json.Serialization;

namespace Cobranca.Api.Models
{
    public class OrigemRequest
    {
        [JsonPropertyName("origem")]
        public List<OrigemModel> Origem { get; set; }
    }
}
