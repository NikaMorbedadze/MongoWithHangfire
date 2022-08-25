using Microsoft.AspNetCore.Mvc;
using MongoWithHangfire.Entity;
using MongoWithHangfire.Service.Interfaces;

namespace MongoWithHangfire.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly ICarService _carService;

    public CarsController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet]
    public async Task<List<CarModel>> Get(string markName, string modelName)
    {
        return await _carService.Get(markName, modelName);
    }

    [HttpPost]
    public async Task Create(CarModel file)
    {
        await _carService.Create(file);
    }
}