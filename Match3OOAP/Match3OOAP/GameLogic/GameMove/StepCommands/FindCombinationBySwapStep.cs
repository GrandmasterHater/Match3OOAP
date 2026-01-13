using Match3OOAP.GameLogic.Core;
using Match3OOAP.GameLogic.GameGrid;

namespace Match3OOAP.GameLogic.GameMove.StepCommands
{
    public class FindCombinationBySwapStep : Step
    {
        public bool HasCombination { get; }

        public FindCombinationBySwapStep(IGrid grid, Coordinate firstCoordinate, Coordinate secondCoordinate)
        {
            
        }
        
        public override void Execute()
        {
            throw new System.NotImplementedException();
        }

        public override void ReadResult(IStepReader readerVisitor)
        {
            readerVisitor.Read(this);
        }

        public Combination GetCombination()
        {
            throw new System.NotImplementedException();
        }
    }
}