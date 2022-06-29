using Hangfire;
using Microsoft.AspNetCore.Mvc;
using MongoWithHangfire.Service.Interfaces;

namespace MongoWithHangfire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangFireController : ControllerBase
    {
        private readonly IFileService _service;
        private readonly IJobService _jobService;
        public HangFireController(IJobService jobService , IFileService service)
        {
            _jobService = jobService;
            _service = service;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Welcome()
        {
             //RecurringJob.AddOrUpdate(() => Console.WriteLine("Hello"), "*/2 * * * *");
            return Ok( "done");

        }


    }
}
