using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoWithHangfire.Entity;
using MongoWithHangfire.Service;
using MongoWithHangfire.Service.Interfaces;

namespace MongoWithHangfire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _service;

        public FileController(IFileService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<FileModel>> Get()
        {
            return await _service.Get();
        }

        [HttpPost]
        public async Task Create([FromQuery] FileModel file)
        {
            await _service.Create(file);
        }
    }
}