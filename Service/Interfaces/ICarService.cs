using MongoWithHangfire.Entity;

namespace MongoWithHangfire.Service.Interfaces;

public interface ICarService
{
    Task Create(CarModel car);
    Task<List<CarModel>> Get(string markName , string modelName);
}