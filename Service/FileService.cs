using System.Runtime.CompilerServices;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
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

    public async Task<FileModel> GetById(ObjectId id) =>
        await _files.Find(f => f.Id == id).FirstOrDefaultAsync();

    public async Task Create(FileModel file) =>
        await _files.InsertOneAsync(file);

    public async Task CreateMany(string filePath)
    {
        //var filePath = @"C:\Users\n.morbedadze\Desktop\1March.txt";
        var file = await File.ReadAllLinesAsync(filePath).ConfigureAwait(false);
       
        var list = new List<FileModel?>();


        foreach (var line in file)
        {
            var fileModel = new FileModel();
            if (line.Contains("./"))
            {
                fileModel.NameEng = line.Split("./").FirstOrDefault();
                fileModel.NameGeo = line.Split("./").LastOrDefault();
                list.Add(fileModel);
            }

            if (!line.Contains("./"))
            {
                fileModel.NameEng = line.Split("/").FirstOrDefault();
                fileModel.NameGeo = line.Split("/").LastOrDefault();
                list.Add(fileModel);
            }
        }
        await _files.InsertManyAsync(list!);
    }

    public async Task Delete(ObjectId id) =>
        await _files.DeleteManyAsync(f => f.Id == id);


    public async Task Update(ObjectId id, FileModel file) =>
        await _files.ReplaceOneAsync(f => f.Id == id, file);
}