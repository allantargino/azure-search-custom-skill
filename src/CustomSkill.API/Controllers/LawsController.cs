using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomSkill.API.Models;
using CustomSkill.API.Processors;
using Microsoft.AspNetCore.Mvc;

namespace CustomSkill.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LawsController : ControllerBase
    {
        // POST api/values
        [HttpPost]
        public Output Post([FromBody] Input input)
        {
            var processor = new LawsProcessor();

            var result = processor.Process(input);

            return result;
        }
    }
}
