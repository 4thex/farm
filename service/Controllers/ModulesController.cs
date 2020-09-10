using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace service.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ModulesController : ControllerBase
    {
        private ILogger<ModulesController> Logger { get; }

        public ModulesController(ILogger<ModulesController> logger)
        {
            Logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string assembly, string version, string culture, string token)
        {
            return null;
        }
    }
}
