using Match3OOAP.GameLogic.GameGrid;

namespace Match3OOAP.GameLogic.GameMove.StepCommands
{
    public class CheckNextMoveAvailableStep : Step
    {
        public CheckNextMoveAvailableStep(IGrid grid) { } 
        
        public override void Execute()
        {
            throw new System.NotImplementedException();
        }

        public override void ReadResult(IStepReader readerVisitor)
        {
            readerVisitor.Read(this);
        }

        public bool IsNextMoveAvailable()
        {
            throw new System.NotImplementedException();
        }
    }
}