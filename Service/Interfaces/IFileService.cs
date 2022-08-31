using MongoDB.Bson;
using MongoWithHangfire.Entity;

namespace MongoWithHangfire.Service.Interfaces;

public interface IFileService
{
    Task<List<FileModel>> Get();
    Task<FileModel> GetById(ObjectId id);
    Task Create(FileModel file);
    Task CreateMany(string filePath);
    Task Update(ObjectId id, FileModel file);
    Task Delete(ObjectId id);
}