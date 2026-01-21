using System.Collections.Generic;

namespace Match3OOAP.GameLogic.BonusSystem
{
    public interface IBonusFactory
    {
        IReadOnlyList<ManualApplicableBonus> CreateManualBonuses();
        
        IReadOnlyList<AutoApplicableBonus> CreateAutoBonuses();
    }
}