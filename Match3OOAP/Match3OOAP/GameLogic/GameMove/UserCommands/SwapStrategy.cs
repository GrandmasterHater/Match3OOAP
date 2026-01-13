using System;
using Match3OOAP.GameLogic.Core;
using Match3OOAP.GameLogic.GameGrid;
using Match3OOAP.GameLogic.GameMove.StepCommands;
using Match3OOAP.GameLogic.GameMove.UserCommands;
using Match3OOAP.Helpers;

namespace Match3OOAP.GameLogic.GameMove.Move
{
    public class SwapStrategy : MoveStrategy
    {
        private readonly IGrid _grid;
        private readonly Coordinate _firstCoordinate;
        private readonly Coordinate _secondCoordinate;

        public SwapStrategy(IGrid grid, Coordinate firstCoordinate, Coordinate secondCoordinate, IStepFactory stepFactory) : base(stepFactory)
        {
            grid.AssertNotNull();
            
            _grid = grid ;
            _firstCoordinate = firstCoordinate; 
            _secondCoordinate = secondCoordinate;
        }

        protected override MoveResult ExecuteMove(IStepFactory stepFactory)
        {
            throw new System.NotImplementedException();
        }
    }
}