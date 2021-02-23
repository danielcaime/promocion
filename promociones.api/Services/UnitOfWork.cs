using promociones.api.Interfaces;
using promociones.data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace promociones.api.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMongoContext _context;
        public UnitOfWork(IMongoContext context)
        {
            _context = context;
        }

        public IPromocionRepository Promociones { get; private set; }

        public async Task<bool> Commit()
        {
            var changeAmount = _context.SaveChanges();

            return changeAmount > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
