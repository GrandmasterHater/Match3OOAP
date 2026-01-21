using System.Collections.Generic;
using Match3OOAP.GameLogic.Core;
using Match3OOAP.GameLogic.GameGrid;
using Match3OOAP.Helpers;

namespace Match3OOAP.GameLogic.GameMove.StepCommands
{
    public class FindCombinationsBySwapStep : FindCombinationsStep
    {
        private readonly Coordinate _firstCoordinate;
        private readonly Coordinate _secondCoordinate;
            
        public FindCombinationsBySwapStep(IGrid grid, Coordinate firstCoordinate, Coordinate secondCoordinate) : base(grid)
        {
            _firstCoordinate = firstCoordinate;
            _secondCoordinate = secondCoordinate;
        }
            
        protected override List<Combination> OnExecute(IGrid grid)
        {
            List<Combination> combinations = new List<Combination>();
            grid.SwapElements(_firstCoordinate, _secondCoordinate);

            try
            {
                Combination combination = FindCombination(_firstCoordinate, grid.GetElement(_firstCoordinate));

                if (combination.IsValid())
                    combinations.Add(combination);
                
                combination = FindCombination(_secondCoordinate, grid.GetElement(_secondCoordinate));

                if (combination.IsValid())
                    combinations.Add(combination);
            }
            finally
            {
                grid.SwapElements(_firstCoordinate, _secondCoordinate);
            }
            
            return combinations;
        }

        public override void ReadResult(IStepReader readerVisitor)
        {
            readerVisitor.Read(this);
        }
    }
}