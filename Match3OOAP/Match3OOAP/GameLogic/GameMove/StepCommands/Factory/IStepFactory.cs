using Match3OOAP.GameLogic.Core;

namespace Match3OOAP.GameLogic.GameMove.StepCommands
{
    public interface IStepFactory
    {
        Step CreateApplyAutoBonusesStep();
        
        Step CreateCheckNextMoveAvailableStep();
        
        Step CreateCheckSwapPossibleStep(Coordinate firstCoordinate, Coordinate secondCoordinate);
        
        Step CreateFindBonusesStep(Combination combination);
        
        Step CreateFindCombinationBySwapStep(Coordinate firstCoordinate, Coordinate secondCoordinate);
        
        Step CreateFinishGameStep();
        
        Step CreateGenerateNewElementsStep();
        
        Step CreateMoveDownElementsStep();
        
        Step CreateRemoveCombinationFromGridStep(Combination combination);
        
        Step CreateUpdateScoreStep(Combination combination);
    }
}