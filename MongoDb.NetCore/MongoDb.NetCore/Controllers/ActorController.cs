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

        [HttpGet("{id}")]
        public async Task<ActionResult> GetActor(int id)
        {
            var result = await _sampleService.GetActor(id);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
