using System.Collections.Generic;
using CustomSkill.API.CustomSkills;

namespace CustomSkill.API.Laws
{
    public class LawsProcessor
    {
        public Output<LawOutputData> Process(Input<LawInputData> input)
        {
            var outputValues = ProcessInputRecords(input.Values);

            var output = CreateOutput(outputValues);

            return output;
        }

        private IEnumerable<OutputRecord<LawOutputData>> ProcessInputRecords(IEnumerable<InputRecord<LawInputData>> inputRecords)
        {
            foreach (var inputRecord in inputRecords)
            {
                var outputData = ProcessInputRecordData(inputRecord.Data);
                var outputRecord = CreateOutputRecord(inputRecord, outputData);

                yield return outputRecord;
            }
        }

        private LawOutputData ProcessInputRecordData(LawInputData inputData)
        {
            var outputResult = IsRecordFinishedAndHasWonTrial(inputData);

            var outputData = new LawOutputData()
            {
                Result = outputResult
            };

            return outputData;
        }

        private bool IsRecordFinishedAndHasWonTrial(LawInputData inputData)
        {
            return inputData.Finished == true && inputData.Success == true;
        }

        private OutputRecord<LawOutputData> CreateOutputRecord(InputRecord<LawInputData> inputRecord, LawOutputData outputData)
        {
            return new OutputRecord<LawOutputData>()
            {
                RecordId = inputRecord.RecordId,
                Data = outputData
            };
        }

        private Output<LawOutputData> CreateOutput(IEnumerable<OutputRecord<LawOutputData>> outputValues)
        {
            return new Output<LawOutputData>()
            {
                Values = outputValues
            };
        }
    }

}
