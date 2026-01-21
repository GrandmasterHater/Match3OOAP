using System.Collections.Generic;
using Match3OOAP.GameLogic.Core;
using Match3OOAP.GameLogic.GameGrid;
using Match3OOAP.Helpers;

namespace Match3OOAP.GameLogic.GameMove.StepCommands
{
    public class MoveDownElementsStep : IStep
    {
        private readonly IGrid _grid;
        private IReadOnlyList<MoveDownElement> _movedCoordinates;

        public MoveDownElementsStep(IGrid grid)
        {
            grid.AssertNotNull();

            _grid = grid;
            _movedCoordinates = new List<MoveDownElement>();
        }
        
        public void Execute()
        {
            _movedCoordinates = _grid.MoveDownElements();
        }

        public void ReadResult(IStepReader readerVisitor)
        {
            readerVisitor.Read(this);
        }

        public IReadOnlyList<MoveDownElement> GetMovedCoordinates() => _movedCoordinates;
    }
}