using System.Collections.Generic;
using Match3OOAP.GameLogic.Core;
using Match3OOAP.GameLogic.GameGrid;
using Match3OOAP.Helpers;

namespace Match3OOAP.GameLogic.GameMove.StepCommands
{
    public class GenerateNewElementsStep : IStep
    {
        private readonly IGrid _grid;
        private IReadOnlyList<FilledPlace> _filledPlaces;

        public GenerateNewElementsStep(IGrid grid)
        {
            grid.AssertNotNull();
            
            _grid = grid;
        }
        
        public void Execute()
        {
            _filledPlaces = _grid.FillEmptyPlaces();
        }

        public void ReadResult(IStepReader readerVisitor)
        {
            readerVisitor.Read(this);
        }

        public IReadOnlyList<FilledPlace> GetNewElements() => _filledPlaces;
    }
}