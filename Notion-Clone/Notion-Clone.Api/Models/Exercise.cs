using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbModels;

public class Exercise
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    //public string Kind { get; set; } 
    public string Body { get; set; }
}
