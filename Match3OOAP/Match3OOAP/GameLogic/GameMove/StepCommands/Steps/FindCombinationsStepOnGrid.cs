using System.Collections.Generic;
using Match3OOAP.GameLogic.Core;
using Match3OOAP.GameLogic.GameGrid;

namespace Match3OOAP.GameLogic.GameMove.StepCommands
{
    public class FindCombinationsStepOnGrid : FindCombinationsStep
    {
        public FindCombinationsStepOnGrid(IGrid grid) : base(grid) { }
        
        protected override List<Combination> OnExecute(IGrid grid)
        {
            List<Combination> combinations = new List<Combination>();
            Size size = grid.GetSize();
            
            for (int row = Coordinate.MIN_ROW; row <= size.Rows; row++)
            {
                for (int column = Coordinate.MIN_COLUMN; column <= size.Columns; column++)
                {
                    Coordinate coordinate = new Coordinate(size, row, column);
                    Combination combination = FindCombination(coordinate, grid.GetElement(coordinate));

                    if (combination.IsValid())
                        combinations.Add(combination);
                }
            }

            return combinations;
        }
    }
}