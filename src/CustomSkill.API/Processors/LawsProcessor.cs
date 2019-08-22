using System.Collections.Generic;
using CustomSkill.API.Models;

namespace CustomSkill.API.Processors
{
    public class LawsProcessor
    {
        public Output Process(Input input)
        {
            var outputValues = ProcessInputRecords(input.Values);

            var output = CreateOutput(outputValues);

            return output;
        }

        private IEnumerable<OutputRecord<OutputData>> ProcessInputRecords(IEnumerable<InputRecord<InputData>> inputRecords)
        {
            foreach (var inputRecord in inputRecords)
            {
                var outputData = ProcessInputRecordData(inputRecord.Data);
                var outputRecord = CreateOutputRecord(inputRecord, outputData);

                yield return outputRecord;
            }
        }

        private OutputData ProcessInputRecordData(InputData inputData)
        {
            var outputResult = IsRecordFinishedAndHasWonTrial(inputData);

            var outputData = new OutputData()
            {
                Result = outputResult
            };

            return outputData;
        }

        private bool IsRecordFinishedAndHasWonTrial(InputData inputData)
        {
            return inputData.Finished == true && inputData.Success == true;
        }

        private OutputRecord<OutputData> CreateOutputRecord(InputRecord<InputData> inputRecord, OutputData outputData)
        {
            return new OutputRecord<OutputData>()
            {
                RecordId = inputRecord.RecordId,
                Data = outputData
            };
        }


        private Output CreateOutput(IEnumerable<OutputRecord<OutputData>> outputValues)
        {
            return new Output()
            {
                Values = outputValues
            };
        }
    }

}
