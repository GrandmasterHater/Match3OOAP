using Match3OOAP.GameLifeCycle.GameStateManagement;

namespace Match3OOAP.GameLogic.GameMove.StepCommands
{
    public class FinishGameStep : Step
    {
        public FinishGameStep(GameController gameController)
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
    }
}