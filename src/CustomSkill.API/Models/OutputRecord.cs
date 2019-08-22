using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomSkill.API.Models
{
    public class OutputRecord<T> : Record<T>
    {
        public List<Failure> Errors { get; set; }
        public List<Failure> Warnings { get; set; }
    }
}
