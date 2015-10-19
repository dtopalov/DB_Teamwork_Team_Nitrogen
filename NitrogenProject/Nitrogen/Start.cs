namespace Nitrogen
{
    using System;
    using System.Linq;

    using MongoDB.Bson;
    using MongoDB.Driver.Builders;
    using Mongo;

    using Nitrogen.Mongo.Models;

    class Start
    {
        static void Main()
        {
            var db = MongoDbOperations.GetDatabase(MongoDbOperations.DatabaseName, MongoDbOperations.DatabaseHost);

            var logs = db.GetCollection<Place>("Places");

            //logs.Insert(new Place
            //{
            //    Id = ObjectId.GenerateNewId().ToString(),
            //    Name = "The Hole",
            //    Address = "1 Vitosha Blvd."
            //});

            //logs.Insert(new Place
            //{
            //    Id = ObjectId.GenerateNewId().ToString(),
            //    Name = "Shiny Place",
            //    Address = "2 Vitosha Blvd."
            //});

            //logs.Insert(new Place
            //{
            //    Id = ObjectId.GenerateNewId().ToString(),
            //    Name = "Space Bar",
            //    Address = "3 Vitosha Blvd."
            //});

            //var update = Update.Set("Text", "Changed Text at " + DateTime.Now);


            //var query = Query.And(
            //    Query.LT("LogDate", DateTime.Now.AddSeconds(-1))
            //    );

            //logs.Update(query, update);

            //var testLogs = logs.FindAll().Select(l => l.Name);

            //foreach (var log in testLogs)
            //{
            //    Console.WriteLine(log);
            //}
        }
    }
}
