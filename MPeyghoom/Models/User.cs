using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MPeyghoom.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public required string Id { get; set; } 

    [BsonElement("phoneNumber")]
    public long PhoneNumber { get; set; } 
}