using Microsoft.AspNetCore.Mvc;
using MongoWithHangfire.Entity;
using MongoWithHangfire.Service.Interfaces;

namespace MongoWithHangfire.Controllers;

[Route("api/[controller]"), ApiController]
public class CarsController : ControllerBase
{
    private readonly ICarService _carService;
    private readonly HttpClient _httpClient;

    public CarsController(ICarService carService, HttpClient httpClient)
    {
        _carService = carService;
        _httpClient = httpClient;

    }

    [HttpGet]
    public async Task<List<CarModel>> Get(string markName, string modelName) => await _carService.Get(markName, modelName);

    [HttpPost]
    public async Task Create(CarModel file) => await _carService.Create(file);
}