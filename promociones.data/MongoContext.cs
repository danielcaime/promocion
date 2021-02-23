using MongoDB.Bson;
using MongoDB.Driver;
using promociones.data.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using promociones.data.Interfaces;
using MongoDB.Bson.Serialization.Conventions;
using Microsoft.Extensions.Options;

namespace promociones.data
{
    public class MongoContext : IMongoContext
    {
        private IMongoDatabase Database { get; set; }
        private readonly List<Func<Task>> _commands;
        private readonly PromotionConfiguration _settings;
        public MongoContext(IOptions<PromotionConfiguration> settings)
        {
            _settings = settings.Value;
            // Set Guid to CSharp style (with dash -)
            BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;

            // Every command will be stored and it'll be processed at SaveChanges
            _commands = new List<Func<Task>>();

            RegisterConventions();

            // Configure mongo (You can inject the config, just to simplify)
            var mongoClient = new MongoClient(_settings.ConnectionString);//configuration.GetSection("MongoSettings").GetSection("Connection").Value);

            Database = mongoClient.GetDatabase(_settings.DatabaseName);
        }

        private void RegisterConventions()
        {
            var pack = new ConventionPack{
                new IgnoreExtraElementsConvention(true),
                new IgnoreIfDefaultConvention(true)
            };

            ConventionRegistry.Register("My Solution Conventions", pack, t => true);
        }

        //public int SaveChanges()
        //{
        //    var qtd = _commands.Count;
        //    foreach (var command in _commands)
        //    {
        //        command();
        //    }

        //    _commands.Clear();
        //    return qtd;
        //}

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return Database.GetCollection<T>(name);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Task AddCommand(Func<Task> func)
        {
            _commands.Add(func);
            return Task.CompletedTask;
        }

        void IMongoContext.AddCommand(Func<Task> func)
        {
            throw new NotImplementedException();
        }

        int IMongoContext.SaveChanges()
        {
            var qtd = _commands.Count;
            foreach (var command in _commands)
            {
                command();
            }

            _commands.Clear();
            return qtd;
        }
    }
}
