using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoWithHangfire.Data;
using MongoWithHangfire.Entity;
using MongoWithHangfire.Service.Interfaces;

namespace MongoWithHangfire.Service;

public class FileService : IFileService
{
    private readonly IMongoCollection<FileModel> _files;
    public FileService(IOptions<MongoDbSettings> options)
    {
        var mongoClient = new MongoClient(options.Value.ConnectionString);
        _files = mongoClient.GetDatabase(options.Value.DatabaseName)
            .GetCollection<FileModel>(options.Value.CollectionName);
    }

    public async Task<List<FileModel>> Get() =>
        await _files.Find(_ => true).ToListAsync();

    public async Task<FileModel> GetById(string id) =>
        await _files.Find(f => f.Id == id).FirstOrDefaultAsync();

    public async Task Create(FileModel file) =>
        await _files.InsertOneAsync(file);

    public async Task Delete(string id) =>
        await _files.DeleteManyAsync(f => f.Id == id);

    public async Task Update(string id, FileModel file) =>
        await _files.ReplaceOneAsync(f => f.Id == id, file);

}
