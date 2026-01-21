using System.Collections.Generic;

namespace Match3OOAP.GameLogic.BonusSystem
{
    public class BonusContainer<T> : HashSet<T>, IBonusContainer<T> where T : Bonus
    {
        
    }
}