using Match3OOAP.GameLogic.BonusSystem;
using Match3OOAP.GameLogic.GameGrid;
using Match3OOAP.GameLogic.GameMove.StepCommands;
using Match3OOAP.GameLogic.GameMove.UserCommands;

namespace Match3OOAP.GameLogic.GameMove
{
    public interface IMoveStrategyFactory
    {
        MoveStrategy CreateSwapMove(Coordinate firstCoordinate, Coordinate secondCoordinate, IStepFactory stepFactory);
        
        MoveStrategy CreateApplyBonusesMove(BonusId bonusId, IStepFactory stepFactory);
    }
}