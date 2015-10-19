namespace Nitrogen.Mongo
{
    using System;

    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Driver;

    public class MongoDbOperations
    {
        public const string DatabaseHost = "mongodb://127.0.0.1";
        public const string DatabaseName = "Nitrogen";

        public static MongoDatabase GetDatabase(string name, string fromHost)
        {
            var mongoClient = new MongoClient(fromHost);
            var server = mongoClient.GetServer();
            return server.GetDatabase(name);
        }

    }
}
