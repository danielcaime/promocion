using promociones.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace promociones.api.Helpers
{
    public class PromocionHelper
    {
        internal static bool Validate(Promocion promocion)
        {
            bool resp = false;
            if (promocion.MaximaCantidadDeCuotas == null && promocion.PorcentajeDeDescuento == null)
                throw new Exception("Revise los descuentos y/o las cuotas");

            if (promocion.ValorInteresCuotas != null && promocion.MaximaCantidadDeCuotas > 0)
            {
                if(!(promocion.MaximaCantidadDeCuotas != null && promocion.MaximaCantidadDeCuotas > 0))
                    throw new Exception("Falta cantidad de cuotas");
            }
            resp = true;
            return resp;
        }
    }
}
