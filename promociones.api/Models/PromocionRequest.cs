using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace promociones.api.Models
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class PromocionRequest
    {
        [JsonPropertyName("mediosDePago")]
        public IEnumerable<string> MediosDePago { get; set; }

        [JsonPropertyName("bancos")]
        public IEnumerable<string> Bancos { get; set; }

        [JsonPropertyName("categoriasProductos")]
        public IEnumerable<string> CategoriasProductos { get; set; }

        [JsonPropertyName("maximaCantidadDeCuotas")]
        public int? MaximaCantidadDeCuotas { get; set; }

        [JsonPropertyName("valorInteresCuotas")]
        public decimal? ValorInteresCuotas { get; set; }

        [JsonPropertyName("porcentajeDeDescuento")]
        public decimal? PorcentajeDeDescuento { get; set; }

        [JsonPropertyName("fechaInicio")]
        public string FechaInicio { get; set; }

        [JsonPropertyName("fechaFin")]
        public string FechaFin { get; set; }

        [JsonPropertyName("activo")]
        public bool Activo { get; set; }

        [JsonPropertyName("fechaCreacion")]
        public DateTime FechaCreacion { get; set; }

        [JsonPropertyName("fechaModificacion")]
        public DateTime FechaModificacion { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }
    }


}
