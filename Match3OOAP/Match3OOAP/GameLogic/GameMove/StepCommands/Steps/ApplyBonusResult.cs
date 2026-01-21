using Match3OOAP.GameLogic.BonusSystem;
using Match3OOAP.Helpers;

namespace Match3OOAP.GameLogic.GameMove.StepCommands
{
    public struct ApplyBonusResult
    {
        public BonusId BonusId { get; }
        
        public bool IsApplied { get; }
        
        public string Info { get; }
        
        public ApplyBonusResult(bool isApplied, string info, BonusId bonusId)
        {
            info.AssertNotNull();
            bonusId.AssertNotNull();
            
            BonusId = bonusId;
            IsApplied = isApplied;
            Info = info;
        }
    }
}