using System.Linq;
using MongoDB.Driver;
using System.Configuration;
using Nitrogen.App_data;

namespace Nitrogen.Mongo
{
    internal class MongoRepository
    {
        private string dataBaseHost = ConfigurationManager.AppSettings["MongoServer"].ToString();
        private string dataBaseName = ConfigurationManager.AppSettings["MongoDbName"].ToString();

        private MongoDatabase GetDatabase(string name, string fromHost)
        {
            var mongoClient = new MongoClient(fromHost);
            var server = mongoClient.GetServer();
            return server.GetDatabase(name);
        }

        public IQueryable<Nitrogen.Mongo.Models.Place> GetAllPlaces()
        {
            var db = this.GetDatabase(this.dataBaseName, this.dataBaseHost);
            var places = db.GetCollection<Nitrogen.Mongo.Models.Place>("Places");
            IQueryable<Nitrogen.Mongo.Models.Place> allPlaces = places.FindAll().Select(x => new Nitrogen.Mongo.Models.Place()
            {
                Name = x.Name,
                Address = x.Address
            }).AsQueryable();
            return allPlaces;
        }

        public IQueryable<Product> GetAllProducts()
        {
            var db = this.GetDatabase(this.dataBaseName, this.dataBaseHost);
            var products = db.GetCollection<Nitrogen.Mongo.Models.Product>("Products");
            IQueryable<Product> allProducts = products.FindAll().Select(x => new Product()
            {
                Name = x.Name               
            }).AsQueryable();

            return allProducts;
        }
    }
}
