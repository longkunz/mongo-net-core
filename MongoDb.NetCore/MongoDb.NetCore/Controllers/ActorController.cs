using Microsoft.AspNetCore.Mvc;
using MongoDb.NetCore.Services;

namespace MongoDb.NetCore.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ActorController(ISampleService sampleService) : ControllerBase
    {
        private readonly ISampleService _sampleService = sampleService;

        [HttpGet]
        public async Task<ActionResult> MigrateData()
        {
            await _sampleService.MigrateData();
            return Ok();
        }
    }
}
