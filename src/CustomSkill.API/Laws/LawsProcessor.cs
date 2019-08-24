using System.Collections.Generic;
using CustomSkill.API.CustomSkills;

namespace CustomSkill.API.Laws
{
    public class LawsProcessor : IProcessor<LawInputData, LawOutputData>
    {
        public LawOutputData Process(LawInputData input)
        {
            var outputResult = IsRecordFinishedAndHasWonTrial(input);

            LawOutputData outputData = CreateOutputDataFromResult(outputResult);

            return outputData;
        }

        private bool IsRecordFinishedAndHasWonTrial(LawInputData inputData)
        {
            return inputData.Finished && inputData.Success;
        }

        private LawOutputData CreateOutputDataFromResult(bool outputResult)
        {
            return new LawOutputData()
            {
                Result = outputResult
            };
        }
    }

}
