using Match3OOAP.GameLogic.BonusSystem;
using Match3OOAP.GameLogic.Core;

namespace Match3OOAP.GameLogic.GameMove
{
    public interface IMoveFactory
    {
        void CreateSwapMove(Coordinate firstCoordinate, Coordinate secondCoordinate);
        
        void CreateApplyBonusesMove(BonusId bonusId);
    }
}