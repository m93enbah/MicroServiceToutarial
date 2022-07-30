using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        private IConfiguration Configuration { get; set; }
        public CatalogContext(IConfiguration configuration) 
        {
            Configuration = configuration;

            var client = new MongoClient(Configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(Configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            Products = database.GetCollection<Product>(Configuration.GetValue<string>("DatabaseSettings:CollectionName"));



            CatalogContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
}
