using System.Collections.Generic;

namespace Match3OOAP.GameLogic.BonusSystem
{
    public class BonusContainer<TBonus> : HashSet<TBonus> where TBonus : Bonus
    {
        
    }
}