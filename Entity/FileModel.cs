using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoWithHangfire.Entity;

public class FileModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string FileName { get; set; }
    public string Path { get; set; }
    public DateTime DateCreated { get; set; }

}
