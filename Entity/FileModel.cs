using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoWithHangfire.Entity;

public class FileModel
{
    [BsonElement("_id")] public ObjectId Id { get; } = ObjectId.GenerateNewId();

    [BsonElement("Georgian")]
    [BsonRepresentation(BsonType.String)]
    public string? NameGeo { get; set; }

    [BsonElement("English")]
    [BsonRepresentation(BsonType.String)]
    public string? NameEng { get; set; }
}