using Match3OOAP.GameLogic.GameGrid;
using Match3OOAP.Helpers;

namespace Match3OOAP.GameLogic.GameMove.StepCommands
{
    public class ApplySwapStep : IStep
    {
        private readonly IGrid _grid;
        
        public Coordinate FirstCoordinate { get; }
        public Coordinate SecondCoordinate { get; }
        public bool IsSuccess { get; private set; }

        public ApplySwapStep(IGrid grid, Coordinate firstCoordinate, Coordinate secondCoordinate)
        {
            grid.AssertNotNull();

            _grid = grid;
            FirstCoordinate = firstCoordinate;
            SecondCoordinate = secondCoordinate;
        }
        
        public void Execute()
        {
            SwapAvailabilityResult swapAvailabilityResult = _grid.IsSwapPossible(FirstCoordinate, SecondCoordinate);

            if (swapAvailabilityResult.IsSwapPossible)
            {
                _grid.SwapElements(FirstCoordinate, SecondCoordinate);
                IsSuccess = true;
            }
        }

        public void ReadResult(IStepReader readerVisitor)
        {
            readerVisitor.Read(this);
        }
    }
}