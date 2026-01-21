using System.Collections.Generic;
using Match3OOAP.GameLogic.BonusSystem;
using Match3OOAP.GameLogic.Core;
using Match3OOAP.GameLogic.GameGrid;

namespace Match3OOAP.GameLogic.GameMove.StepCommands
{
    public interface IStepFactory
    {
        ApplyAutoBonusesStep CreateApplyAutoBonusesStep();
        
        CheckNextMoveAvailableStep CreateCheckNextMoveAvailableStep();

        CheckSwapPossibleStep CreateCheckSwapPossibleStep(Coordinate firstCoordinate, Coordinate secondCoordinate);
        
        FindBonusesStep CreateFindBonusesStep(IReadOnlyList<Combination> combination);
        
        FindCombinationsStep CreateFindCombinationsStepByCoordinates(IReadOnlyList<Coordinate> coordinates);
        
        FindCombinationsStep CreateFindCombinationsOnGrid();
        
        FindCombinationsStep CreateFindCombinationsBySwapStep(Coordinate firstCoordinate, Coordinate secondCoordinate);
        
        GenerateNewElementsStep CreateGenerateNewElementsStep();
        
        MoveDownElementsStep CreateMoveDownElementsStep();
        
        RemoveCombinationFromGridStep CreateRemoveCombinationFromGridStep(IReadOnlyList<Combination> combination);
        
        UpdateScoreStep CreateUpdateScoreStep(IReadOnlyList<Combination> combinations);
        
        ApplySwapStep CreateApplySwapStep(Coordinate firstCoordinate, Coordinate secondCoordinate);
        
        ApplyManualBonusStep CreateApplyManualBonusStep(BonusId bonusId);
    }
}