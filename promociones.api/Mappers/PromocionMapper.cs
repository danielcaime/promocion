using AutoMapper;
using promociones.api.Models;
using promociones.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace promociones.api.Mappers
{
    public class PromocionMapper : Profile
    {
        public PromocionMapper()
        {
            CreateMap<Promocion, PromocionRequest>()
                .ReverseMap();
        }
    }
}
