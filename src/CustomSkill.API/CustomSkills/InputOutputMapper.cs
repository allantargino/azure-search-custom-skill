﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomSkill.API.CustomSkills
{
    public class InputOutputMapper<TInputData, TOutputData>
    {
        private readonly IProcessor<TInputData, TOutputData> processor;

        public InputOutputMapper(IProcessor<TInputData, TOutputData> processor)
        {
            this.processor = processor;
        }

        public Output<TOutputData> Map(Input<TInputData> input)
        {
            var outputValues = ProcessInputRecords(input.Values);

            var output = new Output<TOutputData>(outputValues);

            return output;
        }

        private IEnumerable<OutputRecord<TOutputData>> ProcessInputRecords(IEnumerable<InputRecord<TInputData>> inputRecords)
        {
            foreach (var inputRecord in inputRecords)
            {
                OutputRecord<TOutputData> outputRecord = ProcessInputRecord(inputRecord);

                yield return outputRecord;
            }
        }

        private OutputRecord<TOutputData> ProcessInputRecord(InputRecord<TInputData> inputRecord)
        {
            OutputRecord<TOutputData> outputRecord;

            try
            {
                var outputData = processor.Process(inputRecord.Data);
                outputRecord = OutputRecord<TOutputData>.CreateOutputRecord(inputRecord.RecordId, outputData);
            }
            catch (Exception ex)
            {
                outputRecord = OutputRecord<TOutputData>.CreateOutputRecordWithError(inputRecord.RecordId, ex);
            }

            return outputRecord;
        }

    }
}
