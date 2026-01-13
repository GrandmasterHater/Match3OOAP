using Match3OOAP.GameLogic.BonusSystem;
using Match3OOAP.GameLogic.GameMove.StepCommands;
using Match3OOAP.GameLogic.GameMove.UserCommands;
using Match3OOAP.Helpers;

namespace Match3OOAP.GameLogic.GameMove.Move
{
    public class BonusApplyStrategy : MoveStrategy
    {
        private BonusId _bonusId;
        
        public BonusApplyStrategy(BonusId bonusId, IStepFactory stepFactory) : base(stepFactory)
        {
            bonusId.AssertNotNull();

            _bonusId = bonusId;
        }

        protected override MoveResult ExecuteMove(IStepFactory stepFactory)
        {
            throw new System.NotImplementedException();
        }
    }
}