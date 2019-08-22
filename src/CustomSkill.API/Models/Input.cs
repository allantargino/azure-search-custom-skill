using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomSkill.API.Models
{
    public class Input
    {
        public IEnumerable<InputRecord<InputData>> Values { get; set; }
    }
}
