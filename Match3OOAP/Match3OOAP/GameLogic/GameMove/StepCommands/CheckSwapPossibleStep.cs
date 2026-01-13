using Match3OOAP.GameLogic.Core;
using Match3OOAP.GameLogic.GameGrid;

namespace Match3OOAP.GameLogic.GameMove.StepCommands
{
    public class CheckSwapPossibleStep : Step
    {
        public bool IsSwapPossible { get; private set; }
        public string NotPossibleMessage { get; private set; }
        
        public CheckSwapPossibleStep(IGrid grid, Coordinate firstCoordinate, Coordinate secondCoordinate)
        {
            
        }
        
        public override void Execute()
        {
            
        }

        public override void ReadResult(IStepReader readerVisitor)
        {
            readerVisitor.Read(this);
        }
    }
}