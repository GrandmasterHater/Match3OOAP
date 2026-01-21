using System.Collections.Generic;

namespace Match3OOAP.GameLogic.BonusSystem
{
    public interface IBonusContainer<TBonus> : ISet<TBonus> where TBonus : Bonus { }
}