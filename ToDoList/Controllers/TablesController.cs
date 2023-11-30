using Microsoft.AspNetCore.Mvc;

namespace ToDoLists.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TablesController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<TablesController> _logger;

        public TablesController(ILogger<TablesController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTables")]
        public IEnumerable<string> Get()
        {
            return Summaries;
        }
    }
}