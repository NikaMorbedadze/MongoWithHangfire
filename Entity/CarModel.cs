using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoWithHangfire.Entity;

public class CarModel
{
    [BsonId, BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Mark { get; set; }
    public string Model { get; set; }
    public string FrameType { get; set; }
}