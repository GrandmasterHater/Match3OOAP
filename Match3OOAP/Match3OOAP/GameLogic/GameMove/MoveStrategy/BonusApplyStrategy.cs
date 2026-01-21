using Match3OOAP.GameLogic.BonusSystem;
using Match3OOAP.GameLogic.GameMove.Moves;
using Match3OOAP.GameLogic.GameMove.StepCommands;
using Match3OOAP.GameLogic.GameMove.UserCommands;
using Match3OOAP.Helpers;

namespace Match3OOAP.GameLogic.GameMove.Move
{
    public class BonusApplyStrategy : MoveStrategy
    {
        private readonly BonusId _bonusId;
        
        public BonusApplyStrategy(BonusId bonusId, IStepFactory stepFactory) : base(stepFactory)
        {
            bonusId.AssertNotNull();

            _bonusId = bonusId;
        }

        protected override MoveResult ExecuteMove(IStepFactory stepFactory)
        {
            MoveResult moveResult = new MoveResult();

            ApplyManualBonusStep applyManualBonus = ApplyManualBonus(stepFactory, moveResult);

            var bonusApplyResult = applyManualBonus.GetApplyBonusResult();
            
            if (!bonusApplyResult.IsApplied)
                return moveResult; 

            FindCombinationsStep findCombinationsInGrid = FindCombinationsOnGrid(stepFactory, moveResult);
            
            FindBonuses(findCombinationsInGrid.GetCombinations(), stepFactory, moveResult);
            
            ApplyAutoBonuses(stepFactory, moveResult);
            
            RemoveCombinationsFromGrid(findCombinationsInGrid.GetCombinations(), stepFactory, moveResult);

            MoveDownElements(stepFactory, moveResult);
            
            GenerationCycle(stepFactory, moveResult);
            
            return moveResult; 
        }
        
        private ApplyManualBonusStep ApplyManualBonus(IStepFactory stepFactory, MoveResult moveResult)
        {
            ApplyManualBonusStep applyAutoBonusesStep = stepFactory.CreateApplyManualBonusStep(_bonusId);
            moveResult.AddLast(applyAutoBonusesStep);
            applyAutoBonusesStep.Execute();

            return applyAutoBonusesStep;
        }
    }
}