using System;
using System.Collections.Generic;
using Match3OOAP.GameLogic.BonusSystem;
using Match3OOAP.GameLogic.Core;

namespace Match3OOAP.GameLogic
{
    public class GameLogicFacade
    {
        public void UseBonus(Bonus bonus) => throw new NotImplementedException(); 
        
        public void Move(uint row1, uint column1, uint row2, uint column2) => throw new NotImplementedException();
        
        public Bonus GetAvailableBonus() => throw new NotImplementedException(); 
        
        public int GetScore() => throw new NotImplementedException();
        
        public LinkedList<string> GetHistory() => throw new NotImplementedException();
        
        public Grid GetGrid() => throw new NotImplementedException();
    }
}