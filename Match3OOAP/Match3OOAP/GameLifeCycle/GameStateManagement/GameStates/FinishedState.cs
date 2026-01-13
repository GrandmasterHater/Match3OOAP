
using Match3OOAP.GameLogic.Statistics;
using Match3OOAP.Gui.EndGameScreen;
using Match3OOAP.Helpers;
using Match3OOAP.InputHandle;

namespace Match3OOAP.GameLifeCycle.GameStateManagement.GameStates
{
    public class FinishedState : GameState
    {
        private IPresentable _guiPresenter;
        private readonly IScore _score;
        private readonly IMoveHistory _moveHistory;

        public sealed override string Name => nameof(FinishedState);

        //Предусловие: счёт и история ходов не null.
        //Постусловие: состояние готово к показу экрана завершения игры.
        public FinishedState(IScore score, IMoveHistory moveHistory)
        {
            score.AssertNotNull();
            moveHistory.AssertNotNull();
            
            _score = score;
            _moveHistory = moveHistory;
            _guiPresenter = GetReadyStatePresenter();
        }

        // Постусловие: активирован презентер показа экрана завершения игры.
        public sealed override void SetState()
        {
            _guiPresenter.Activate();
        }

        // Постусловие: деактивирован презентер показа экрана завершения игры.
        public sealed override void ResetState()
        {
            _guiPresenter.Deactivate();
        }
        
        protected virtual IPresentable GetReadyStatePresenter() => new FinishGamePresenter(_score, _moveHistory, new FinishGameView());
    }
}