namespace Match3OOAP.GameLogic.GameMove.StepCommands
{
    public interface IStepReader
    {
        void Read(ApplyAutoBonusesStep checkSwapPossibleStep);
        void Read(CheckSwapPossibleStep checkSwapPossibleStep);
        void Read(FindBonusesStep checkSwapPossibleStep);
        void Read(CheckNextMoveAvailableStep checkSwapPossibleStep);
        void Read(FindCombinationBySwapStep checkSwapPossibleStep);
        void Read(FinishGameStep checkSwapPossibleStep);
        void Read(GenerateNewElementsStep checkSwapPossibleStep);
        void Read(MoveDownElementsStep checkSwapPossibleStep);
        void Read(UpdateScoreStep checkSwapPossibleStep);
        void Read(RemoveCombinationFromGridStep checkSwapPossibleStep);
    }
}