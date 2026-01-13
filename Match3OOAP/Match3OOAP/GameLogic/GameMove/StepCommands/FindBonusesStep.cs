using System.Collections.Generic;
using Match3OOAP.GameLogic.BonusSystem;
using Match3OOAP.GameLogic.Core;

namespace Match3OOAP.GameLogic.GameMove.StepCommands
{
    public class FindBonusesStep : Step
    {
        public FindBonusesStep(Combination combination)
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

        public IEnumerable<Bonus> GetBonuses()
        {
            throw new System.NotImplementedException();   
        }
    }
}