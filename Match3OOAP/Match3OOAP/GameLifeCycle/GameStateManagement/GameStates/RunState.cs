
using Match3OOAP.GameLogic.Statistics;
using Match3OOAP.Helpers;

namespace Match3OOAP.GameLifeCycle.GameStateManagement.GameStates
{
    public class RunState : GameState
    {
        private readonly IScore _score;
        private readonly IMoveHistory _moveHistory;

        // Предусловие: счёт и история ходов не null.
        // Постусловие: игровая логика и поле готово к показу.
        public RunState(IScore score, IMoveHistory moveHistory)
        {
            score.AssertNotNull();
            moveHistory.AssertNotNull();
            
            _score = score;
            _moveHistory = moveHistory;
        }

        public sealed override string Name => nameof(RunState);
        
        // Постусловие:
        // - игровое поле отображено;
        // - игровая логика запущена;
        public sealed override void SetState()
        {
            throw new System.NotImplementedException();
        }

        // Постусловие:
        // - игровая логика остановлена;
        // - игровая поле скрыто;
        public sealed override void ResetState()
        {
            throw new System.NotImplementedException();
        }
    }
}