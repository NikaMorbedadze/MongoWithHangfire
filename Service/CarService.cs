using System.Runtime.InteropServices.ComTypes;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoWithHangfire.Data;
using MongoWithHangfire.Entity;
using MongoWithHangfire.Service.Interfaces;

namespace MongoWithHangfire.Service;

public class CarService : ICarService
{
    private readonly IMongoCollection<CarModel> _cars;

    public CarService(IOptions<MongoDbSettings> options)
    {
        var mongoClient = new MongoClient(options.Value.ConnectionString);
        _cars = mongoClient.GetDatabase(options.Value.DatabaseName)
            .GetCollection<CarModel>(options.Value.CollectionName);
    }


    public async Task Create(CarModel file) =>
        await _cars.InsertOneAsync(file);


    public async Task<List<CarModel>> Get(string markName, string modelName) =>
        await _cars.Find(x => x.Mark.ToLower() == markName.ToLower() && x.Model.ToLower() == modelName.ToLower())
            .ToListAsync();
}