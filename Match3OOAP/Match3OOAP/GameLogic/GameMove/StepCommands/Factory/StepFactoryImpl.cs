using Match3OOAP.GameLogic.Core;

namespace Match3OOAP.GameLogic.GameMove.StepCommands
{
    public class StepFactoryImpl : IStepFactory
    {
        public Step CreateApplyAutoBonusesStep()
        {
            throw new System.NotImplementedException();
        }

        public Step CreateCheckNextMoveAvailableStep()
        {
            throw new System.NotImplementedException();
        }

        public Step CreateCheckSwapPossibleStep(Coordinate firstCoordinate, Coordinate secondCoordinate)
        {
            throw new System.NotImplementedException();
        }

        public Step CreateFindBonusesStep(Combination combination)
        {
            throw new System.NotImplementedException();
        }

        public Step CreateFindCombinationBySwapStep(Coordinate firstCoordinate, Coordinate secondCoordinate)
        {
            throw new System.NotImplementedException();
        }

        public Step CreateFinishGameStep()
        {
            throw new System.NotImplementedException();
        }

        public Step CreateGenerateNewElementsStep()
        {
            throw new System.NotImplementedException();
        }

        public Step CreateMoveDownElementsStep()
        {
            throw new System.NotImplementedException();
        }

        public Step CreateRemoveCombinationFromGridStep(Combination combination)
        {
            throw new System.NotImplementedException();
        }

        public Step CreateUpdateScoreStep(Combination combination)
        {
            throw new System.NotImplementedException();
        }
    }
}