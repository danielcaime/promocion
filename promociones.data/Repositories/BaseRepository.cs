using Microsoft.Extensions.Options;
using MongoDB.Driver;
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
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseModel
    {
        protected readonly IMongoContext _context;
        private readonly IMongoCollection<T> _collection;

        //public BaseRepository(IOptions<PromotionConfiguration> settings)
        //{
        //    _settings = settings.Value;
        //    var client = new MongoClient(_settings.ConnectionString);
        //    var database = client.GetDatabase(_settings.DatabaseName);
        //    _promocion = database.GetCollection<T>(_settings.PromotionCollectionName);
        //}

        public BaseRepository(IMongoContext context)
        {
            _context = context;
            _collection = _context.GetCollection<T>(typeof(T).Name);
        }
        public async Task<T> Add(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public Task<T> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> Get(Guid id)
        {
            var data = await _collection.FindAsync(Builders<T>.Filter.Eq("_id", id));
            return data.SingleOrDefault();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            var all = await _collection.FindAsync(Builders<T>.Filter.Empty);
            return all.ToList();
        }

        public Task<T> Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Task<T> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        async Task<List<T>> IRepository<T>.GetAll()
        {
            var all = await _collection.FindAsync(Builders<T>.Filter.Empty);
            return await all.ToListAsync();
        }
    }
}
