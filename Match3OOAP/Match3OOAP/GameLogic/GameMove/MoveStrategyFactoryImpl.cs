using Match3OOAP.GameLogic.BonusSystem;
using Match3OOAP.GameLogic.Core;
using Match3OOAP.GameLogic.GameGrid;
using Match3OOAP.GameLogic.GameMove.Move;
using Match3OOAP.GameLogic.GameMove.StepCommands;
using Match3OOAP.GameLogic.GameMove.UserCommands;
using Match3OOAP.Helpers;

namespace Match3OOAP.GameLogic.GameMove
{
    public class MoveStrategyFactoryImpl : IMoveStrategyFactory
    {
        private readonly IGrid _grid;

        public MoveStrategyFactoryImpl(IGrid grid)
        {
            grid.AssertNotNull();
            
            _grid = grid;
        }
        
        public MoveStrategy CreateSwapMove(Coordinate firstCoordinate, Coordinate secondCoordinate, IStepFactory stepFactory)
        {
            return new SwapStrategy(_grid, firstCoordinate, secondCoordinate, stepFactory);
        }

        public MoveStrategy CreateApplyBonusesMove(BonusId bonusId, IStepFactory stepFactory)
        {
            return new BonusApplyStrategy(bonusId, stepFactory);
        }
    }
}