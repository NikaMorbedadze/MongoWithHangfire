using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoWithHangfire.Entity;

namespace MongoWithHangfire.Data;

public class MongoDbSettings
{
    public string ConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
    public string CollectionName { get; set; } = string.Empty;


}
