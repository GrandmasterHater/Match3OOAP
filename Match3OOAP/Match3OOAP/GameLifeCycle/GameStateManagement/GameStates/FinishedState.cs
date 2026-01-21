
using Match3OOAP.GameLogic.Statistics;
using Match3OOAP.Gui.FinishGameScreen;
using Match3OOAP.Helpers;
using Match3OOAP.InputHandle;

namespace Match3OOAP.GameLifeCycle.GameStateManagement.GameStates
{
    public class FinishedState : GameState
    {
        private readonly GameController _gameController;
        private readonly IPresentable _guiPresenter;
        private readonly IScore _score;
        private readonly IMoveHistory _moveHistory;

        public override GameStatus GameStatus => GameStatus.FinishedGame;

        //Предусловие: счёт и история ходов не null.
        //Постусловие: состояние готово к показу экрана завершения игры.
        public FinishedState(IScore score, IMoveHistory moveHistory, GameController gameController)
        {
            score.AssertNotNull();
            moveHistory.AssertNotNull();
            gameController.AssertNotNull();
            
            _score = score;
            _moveHistory = moveHistory;
            _gameController = gameController;
            _guiPresenter = GetReadyStatePresenter();
        }

        // Постусловие: активирован презентер показа экрана завершения игры.
        protected override void OnSetState()
        {
            _guiPresenter.Activate();
        }

        // Постусловие: деактивирован презентер показа экрана завершения игры.
        protected override void OnResetState()
        {
            _guiPresenter.Deactivate();
        }
        
        protected virtual IPresentable GetReadyStatePresenter() => new FinishGamePresenter(_score, _moveHistory, ConsoleAsyncInputListener.Instance, _gameController, new FinishGameView());
    }
}