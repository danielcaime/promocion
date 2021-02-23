using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using promociones.data.Configurations;
using promociones.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace promociones.data.Services
{
    public class PromocionService
    {
        private readonly IMongoCollection<Promocion> _promocion;
        private readonly PromotionConfiguration _settings;

        public PromocionService(IOptions<PromotionConfiguration> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _promocion = database.GetCollection<Promocion>(_settings.PromotionCollectionName);
        }

        public async Task<List<Promocion>> GetAllAsync()
        {
            return await _promocion.Find(c => true).ToListAsync();
        }

        public async Task<Promocion> GetByIdAsync(string id)
        {
            return await _promocion.Find<Promocion>(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Promocion> CreateAsync(Promocion promocion)
        {
            promocion.FechaCreacion = DateTime.Now;
            promocion.Activo = true;
            await _promocion.InsertOneAsync(promocion);
            return promocion;
        }

        public async Task UpdateAsync(string id, Promocion promocion)
        {
            promocion.FechaModificacion = DateTime.Now;
            
            await _promocion.ReplaceOneAsync(c => c.Id == id, promocion);
        }

        public async Task DeleteAsync(string id)
        {
            await _promocion.DeleteOneAsync(c => c.Id == id);
        }
    }
}
