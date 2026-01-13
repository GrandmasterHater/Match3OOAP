using Match3OOAP.GameLifeCycle.GameStateManagement.GameStates;
using Match3OOAP.GameLogic.Statistics;
using Match3OOAP.Helpers;
using Match3OOAP.InputHandle;

namespace Match3OOAP.GameLifeCycle.GameStateManagement.GameStateFactory
{
    public class GameStateFactory : IGameStateFactory
    {
        private readonly IScore _score;
        private readonly IMoveHistory _moveHistory;
        
        public GameStateFactory(IScore score, IMoveHistory moveHistory)
        {
            score.AssertNotNull();
            moveHistory.AssertNotNull();
            
            _score = score;
            _moveHistory = moveHistory;
        }
        
        public GameState GetReadyState()
        {
            return new ReadyState();
        }

        public GameState GetRunState()
        {
            return new RunState(_score, _moveHistory);
        }

        public GameState GetFinishedState()
        {
            return new FinishedState(_score, _moveHistory);
        }

        public GameState GetClosedState()
        {
            return new ClosedState();
        }
    }
}