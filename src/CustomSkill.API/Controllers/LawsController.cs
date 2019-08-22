using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomSkill.API.Models;
using CustomSkill.API.Processors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomSkill.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LawsController : ControllerBase
    {
        private readonly ILogger logger;

        public LawsController(ILogger<LawsController> logger)
        {
            this.logger = logger;
        }

        // POST api/values
        [HttpPost]
        public Output Post([FromBody] Input input)
        {
            logger.LogInformation("Input values received: {Count}", input.Values.Count());

            var processor = new LawsProcessor();

            var result = processor.Process(input);

            return result;
        }
    }
}
