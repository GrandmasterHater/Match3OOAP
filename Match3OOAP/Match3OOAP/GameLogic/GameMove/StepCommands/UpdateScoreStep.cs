using Match3OOAP.GameLogic.Core;

namespace Match3OOAP.GameLogic.GameMove.StepCommands
{
    public class UpdateScoreStep : Step
    {
        public UpdateScoreStep(Combination combination) { }
        
        public override void Execute()
        {
            throw new System.NotImplementedException();
        }

        public override void ReadResult(IStepReader readerVisitor)
        {
            readerVisitor.Read(this);
        }

        public int GetScoreChange()
        {
            throw new System.NotImplementedException();
        }
    }
}