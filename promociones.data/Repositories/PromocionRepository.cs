using Microsoft.Extensions.Options;
using promociones.data.Configurations;
using promociones.data.Interfaces;
using promociones.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace promociones.data.Repositories
{
    public class PromocionRepository : BaseRepository<Promocion>, IPromocionRepository
    {
        public PromocionRepository(IMongoContext context) : base(context)
        {

        }
    }
}
