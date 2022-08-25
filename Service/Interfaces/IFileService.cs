using MongoWithHangfire.Entity;

namespace MongoWithHangfire.Service.Interfaces;

public interface IFileService
{
    Task<List<FileModel>> Get();
    Task<FileModel> GetById(string id);
    Task Create(FileModel file);
    Task Update(string id, FileModel file);
    Task Delete(string id);

}