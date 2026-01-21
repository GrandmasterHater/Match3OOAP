using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Match3OOAP.GameLogic.Core;
using Match3OOAP.GameLogic.GameGrid;
using Match3OOAP.Helpers;

namespace Match3OOAP.GameLogic.GameMove.StepCommands
{
    public class RemoveCombinationFromGridStep : IStep
    {
        private readonly IGrid _grid;
        private readonly IReadOnlyList<Combination> _combinations;
        private List<Coordinate> _removedCoordinates;

        public RemoveCombinationFromGridStep(IGrid grid, IReadOnlyList<Combination> combinations)
        {
            grid.AssertNotNull();
            combinations.AssertNotNull();
            combinations.AssertItemsNotNull();
            
            _grid = grid;
            _combinations = combinations;

            _removedCoordinates = new List<Coordinate>();
        }
        
        public void Execute()
        {
            _removedCoordinates = _combinations.SelectMany(
                combination => combination.GetCoordinates(), 
                (c, coordinates) => coordinates)
                .ToList();

            foreach (Coordinate coordinate in _removedCoordinates)
            {
                _grid.RemoveElement(coordinate);
            }
        }

        public void ReadResult(IStepReader readerVisitor)
        {
            readerVisitor.Read(this);
        }

        public IReadOnlyList<Coordinate> RemovedCoordinates() => _removedCoordinates;
    }
}