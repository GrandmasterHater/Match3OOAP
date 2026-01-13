using Match3OOAP.GameLogic.BonusSystem;

namespace Match3OOAP.GameLogic.GameMove.StepCommands
{
    public class ApplyAutoBonusesStep : Step
    {
        public ApplyAutoBonusesStep()
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

        public AutoApplicableBonus[] GetAppliedBonuses()
        {
            throw new System.NotImplementedException();
        }
    }
}