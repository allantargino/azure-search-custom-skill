using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomSkill.API.CustomSkills
{
    public class OutputRecord<TOutputData> : Record<TOutputData>
    {
        public IEnumerable<Failure> Errors { get; set; }
        public IEnumerable<Failure> Warnings { get; set; }


        public static OutputRecord<TOutputData> CreateOutputRecord(String recordId, TOutputData outputData)
        {
            return new OutputRecord<TOutputData>()
            {
                RecordId = recordId,
                Data = outputData
            };
        }

        public static OutputRecord<TOutputData> CreateOutputRecordWithError(String recordId, Exception ex)
        {
            return new OutputRecord<TOutputData>()
            {
                RecordId = recordId,
                Errors = new List<Failure>()
                {
                    new Failure()
                    {
                        Message = ex.Message
                    }
                }
            };
        }
    }
}
