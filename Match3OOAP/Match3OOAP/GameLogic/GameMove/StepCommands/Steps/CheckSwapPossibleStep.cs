using Match3OOAP.GameLogic.Core;
using Match3OOAP.GameLogic.GameGrid;
using Match3OOAP.Helpers;

namespace Match3OOAP.GameLogic.GameMove.StepCommands
{
    public class CheckSwapPossibleStep : IStep
    {
        private readonly IGrid _grid;
        private readonly Coordinate _firstCoordinate;
        private readonly Coordinate _secondCoordinate;

        public bool IsSwapPossible { get; private set; }
        public string AvailabilityInfo { get; private set; }
        
        public CheckSwapPossibleStep(IGrid grid, Coordinate firstCoordinate, Coordinate secondCoordinate)
        {
            grid.AssertNotNull();

            _grid = grid;
            _firstCoordinate = firstCoordinate;
            _secondCoordinate = secondCoordinate;
        }
        
        public void Execute()
        {
            SwapAvailabilityResult swapAvailabilityResult = _grid.IsSwapPossible(_firstCoordinate, _secondCoordinate);

            IsSwapPossible = swapAvailabilityResult.IsSwapPossible;
            AvailabilityInfo = swapAvailabilityResult.AvailabilityInfo;
        }

        public void ReadResult(IStepReader readerVisitor)
        {
            readerVisitor.Read(this);
        }
    }
}