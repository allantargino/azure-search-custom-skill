using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomSkill.API.CustomSkills
{
    public class Input<TInputData>
    {
        public IEnumerable<InputRecord<TInputData>> Values { get; set; }
    }
}
