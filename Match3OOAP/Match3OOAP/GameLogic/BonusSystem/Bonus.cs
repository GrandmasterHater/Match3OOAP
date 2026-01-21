using System;
using Match3OOAP.GameLogic.Core;
using Match3OOAP.GameLogic.GameGrid;
using Match3OOAP.Helpers;

namespace Match3OOAP.GameLogic.BonusSystem
{
    public abstract class Bonus
    {
        protected Combination? CurrentCombination { get; private set; }
        
        #region Запросы
        
        public abstract bool IsAutoApplyAvailable();

        public abstract bool IsBonusAvailable();

        #endregion
        
        #region Команды

        public void SetCombination(Combination combination)
        {
            combination.AssertNotNull();

            CurrentCombination = combination;
        }
        
        // Постусловие: эффект бонуса применён.
        public abstract void Apply(IGrid grid);

        #endregion
    }
}