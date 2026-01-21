namespace Match3OOAP.GameLogic.GameMove.StepCommands
{
    public interface IStepReader
    {
        void Read(ApplyAutoBonusesStep applyAutoBonusesStep);
        void Read(CheckSwapPossibleStep checkSwapPossibleStep);
        void Read(FindBonusesStep findBonusesStep);
        void Read(FindCombinationsStep findCombinationsStep);
        void Read(GenerateNewElementsStep generateNewElementsStep);
        void Read(MoveDownElementsStep moveDownElementsStep);
        void Read(UpdateScoreStep updateScoreStep);
        void Read(RemoveCombinationFromGridStep removeCombinationFromGridStep);
        void Read(ApplySwapStep applySwapStep);
        void Read(FindCombinationsBySwapStep findCombinationsBySwapStep);
        void Read(CheckNextMoveAvailableStep removeCombinationFromGridStep);
        void Read(ApplyManualBonusStep removeCombinationFromGridStep);
    }
}