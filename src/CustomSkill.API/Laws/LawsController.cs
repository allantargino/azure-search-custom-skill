using System.Linq;
using CustomSkill.API.CustomSkills;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomSkill.API.Laws
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
        public Output<LawOutputData> Post([FromBody] Input<LawInputData> input)
        {
            logger.LogInformation("Laws received: {Count}", input.Values.Count());

            var lawsProcessor = new LawsProcessor();
            var lawsMapper = new InputOutputMapper<LawInputData, LawOutputData>(lawsProcessor);

            var output = lawsMapper.Map(input);

            return output;
        }
    }
}
