using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Services;
using StackExchange.Profiling;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly IMyService _myService;

        public SampleController(IMyService myService)
        {
            _myService = myService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Start profiling for a specific action
            using (MiniProfiler.Current.Step("Fetch Data"))
            {
                var data = await _myService.GetUsersAsync();
                return Ok(data);
            }
        }
    }
}
