using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomSkill.API.CustomSkills
{
    public class Output<TOutputData>
    {
        public IEnumerable<OutputRecord<TOutputData>> Values { get; set; }
    }
}
