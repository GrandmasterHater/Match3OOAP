using System.Collections.Generic;
using Match3OOAP.GameLogic.Core;
using Match3OOAP.GameLogic.GameGrid;
using Match3OOAP.Helpers;

namespace Match3OOAP.GameLogic.GameMove.StepCommands
{
    public class FindCombinationsStepByCoordinates : FindCombinationsStep
    {
        private readonly IReadOnlyList<Coordinate> _coordinates;

        public FindCombinationsStepByCoordinates(IGrid grid, IReadOnlyList<Coordinate> coordinates) : base(grid)
        {
            coordinates.AssertNotNull();

            _coordinates = coordinates;
        }

        protected override List<Combination> OnExecute(IGrid grid)
        {
            List<Combination> combinations = new List<Combination>();
                
            foreach (Coordinate coordinate in _coordinates)
            {
                Combination combination = FindCombination(coordinate, grid.GetElement(coordinate));

                if (combination.IsValid())
                    combinations.Add(combination);
            }

            return combinations;
        }
    }
}