namespace Nitrogen.Mongo.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Place
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}
