using System.Collections.Generic;
using Match3OOAP.GameLogic.BonusSystem.AutoBonus;
using Match3OOAP.GameLogic.BonusSystem.ManualBonus;
using Match3OOAP.GameLogic.GameGrid;
using Match3OOAP.Helpers;

namespace Match3OOAP.GameLogic.BonusSystem
{
    public class BonusFactoryImpl : IBonusFactory
    {
        public IReadOnlyList<ManualApplicableBonus> CreateManualBonuses()
        {
            return new List<ManualApplicableBonus>
            {
                new RegenerateGridBonus()
            };
        }

        public IReadOnlyList<AutoApplicableBonus> CreateAutoBonuses()
        {
            return new List<AutoApplicableBonus>
            {
                new RemoveLineBonus()
            };
        }
    }
}