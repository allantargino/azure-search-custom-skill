using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomSkill.API.CustomSkills
{
    public interface IProcessor<TInputData, TOutputData>
    {
        TOutputData Process(TInputData input);
    }
}
