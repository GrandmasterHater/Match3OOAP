using System;

namespace Match3OOAP.GameLogic.BonusSystem
{
    public abstract class Bonus
    {
        #region Конструктор

        // Предусловие: value > 0
        // Постусловие: Bonus создан в состоянии неиспользован
        public Bonus(int type) { }

        #endregion

        #region Команды

        // Предусловие: бонус не использован
        // Постусловие: бонус помечен как использованный, эффект применён
        public void Apply() { }

        #endregion

        #region Запросы

        public int GetBonusType() => throw new NotImplementedException();

        public bool IsUsed() => throw new NotImplementedException();

        #endregion
    }
}