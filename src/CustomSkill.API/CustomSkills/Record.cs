using System.Collections.Generic;

namespace CustomSkill.API.CustomSkills
{
    public class Record<T>
    {
        public string RecordId { get; set; }
        public T Data { get; set; }
    }
}
