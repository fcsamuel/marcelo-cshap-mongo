using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationVeiculo.Models;

namespace WebApplicationVeiculo.Context
{
    public class MongoDBContext
    {
        private IMongoDatabase _database { get; set; }

        public MongoDBContext()
        {
            MongoClientSettings clientSettings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://localhost:27017")); // Cria conexão com o DB
            var mongoClient = new MongoClient(clientSettings);// Start do client
            _database = mongoClient.GetDatabase("veiculo");// Inicia a database
        }

        public IMongoCollection<Veiculo> Veiculos 
        {
            get
            {
                return _database.GetCollection<Veiculo>("veiculo");
            }
        }
    }
}
