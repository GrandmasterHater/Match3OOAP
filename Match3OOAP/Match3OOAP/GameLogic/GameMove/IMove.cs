using System;
using Match3OOAP.GameLogic.BonusSystem;
using Match3OOAP.GameLogic.GameGrid;
using Match3OOAP.GameLogic.GameMove.Moves;

namespace Match3OOAP.GameLogic.GameMove
{
    public interface IMove
    {
        event Action OnMoveCompletedEvent;
        
        void Swap(Coordinate firstCoordinate, Coordinate secondCoordinate);

        void ApplyBonus(BonusId bonusId);

        MoveResult? GetLastMoveResult();

        bool IsNextMoveAvailable();
    }
}