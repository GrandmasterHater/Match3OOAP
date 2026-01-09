using System;
using Match3OOAP.GameLogic.BonusSystem;
using Match3OOAP.GameLogic.Core;
using Match3OOAP.GameLogic.GameGrid;
using Match3OOAP.GameLogic.MoveHandlers;

namespace Match3OOAP.GameLogic.GameMove
{
    public class Move
    {
        public event Action<MoveResult> OnMoveCompleted;
        
        #region Конструктор

        public Move(Grid grid, BonusContainer<ManualApplicableBonus> bonusContainer) { }

        #endregion
        

        #region Команды
        
        public void Swap(Coordinate firstCoordinate, Coordinate secondCoordinate) { }
        
        // Предусловия: id бонуса не null.
        public void ApplyBonus(BonusId bonusId) { }

        #endregion


        #region Запросы

        public bool IsMovePossible() => throw new NotImplementedException();

        #endregion
    }
}