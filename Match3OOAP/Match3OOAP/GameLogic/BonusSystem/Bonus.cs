using System;
using Match3OOAP.GameLogic.Core;

namespace Match3OOAP.GameLogic.BonusSystem
{
    public abstract class Bonus
    {
        #region Запросы

        public abstract bool IsBonusAvailable(Combination combination);

        #endregion
        
        #region Команды
        
        // Постусловие: эффект бонуса применён.
        public void Apply() { }

        #endregion
    }
}