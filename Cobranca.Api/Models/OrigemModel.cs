using System.Text.Json.Serialization;

namespace Cobranca.Api.Models
{
    public class OrigemModel
    {
        [JsonPropertyName("EmpresaId")]
        public int EmpresaId { get; set; }

        [JsonPropertyName("TipoOrigem")]
        public string TipoOrigem { get; set; }

        [JsonPropertyName("IdExterno")]
        public string IdExterno { get; set; }

        [JsonPropertyName("RamoId")]
        public int? RamoId { get; set; }

        [JsonPropertyName("Titulo")]
        public string Titulo { get; set; }

        [JsonPropertyName("Descricao")]
        public string Descricao { get; set; }

        [JsonPropertyName("DataEvento")]
        public DateTime? DataEvento { get; set; }

        [JsonPropertyName("Metadata")]
        public object Metadata { get; set; } = new { }; // obrigatório para não dar erro

        [JsonPropertyName("Tipo")]
        public string? Tipo { get; set; }

        [JsonPropertyName("NomeRazao")]
        public string? NomeRazao { get; set; }

        [JsonPropertyName("CpfCnpj")]
        public string? CpfCnpj { get; set; }

        [JsonPropertyName("DataNascimento")]
        public DateTime? DataNascimento { get; set; }

        [JsonPropertyName("RG_IE")]
        public string? RG_IE { get; set; }

        [JsonPropertyName("Tel1")]
        public string? Tel1 { get; set; }

        [JsonPropertyName("Tel2")]
        public string? Tel2 { get; set; }

        [JsonPropertyName("Email")]
        public string? Email { get; set; }

        [JsonPropertyName("EndLogradouro")]
        public string? EndLogradouro { get; set; }

        [JsonPropertyName("EndNumero")]
        public string? EndNumero { get; set; }

        [JsonPropertyName("EndComplemento")]
        public string? EndComplemento { get; set; }

        [JsonPropertyName("EndBairro")]
        public string? EndBairro { get; set; }

        [JsonPropertyName("EndCidade")]
        public string? EndCidade { get; set; }

        [JsonPropertyName("EndUF")]
        public string? EndUF { get; set; }

        [JsonPropertyName("EndCEP")]
        public string? EndCEP { get; set; }

        [JsonPropertyName("Anexo")]
        public List<Anexo>? Anexo { get; set; }
    }

    public class Anexo
    {
        [JsonPropertyName("Nome")]
        public string Nome { get; set; }

        [JsonPropertyName("TipoDocumento")]
        public string TipoDocumento { get; set; }

        [JsonPropertyName("HashArquivo")]
        public string HashArquivo { get; set; }

        [JsonPropertyName("Url")]
        public string Url { get; set; }
    }
}
