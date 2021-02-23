using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace promociones.data.Models
{
    public class Promocion : BaseModel
    {
        public IEnumerable<string> MediosDePago { get; private set; }
        public IEnumerable<string> Bancos { get; private set; }
        public IEnumerable<string> CategoriasProductos { get; private set; }
        public int? MaximaCantidadDeCuotas { get; private set; }
        public decimal? ValorInteresCuotas { get; private set; }
        public decimal? PorcentajeDeDescuento { get; private set; }

        [BsonDateTimeOptions]
        public DateTime? FechaInicio { get; private set; }
        [BsonDateTimeOptions]
        public DateTime? FechaFin { get; private set; }
        public bool Activo { get; set; }
        [BsonDateTimeOptions]
        public DateTime FechaCreacion { get; set; }
        [BsonDateTimeOptions]
        public DateTime? FechaModificacion { get; set; }
    }
}
