
using Match3OOAP.Gui.EndGameScreen;
using Match3OOAP.InputHandle;

namespace Match3OOAP.GameLifeCycle.GameStateManagement.GameStates
{
    public class FinishedState : GameState
    {
        private IGuiPresenter _guiPresenter;
        
        public sealed override string Name => nameof(FinishedState);

        public FinishedState()
        {
            _guiPresenter = GetReadyStatePresenter();
        }
        
        public sealed override void SetState()
        {
            _guiPresenter.Activate();
        }

        public sealed override void ResetState()
        {
            _guiPresenter.Deactivate();
        }
        
        protected virtual IGuiPresenter GetReadyStatePresenter() => new FinishGamePresenter(new FinishGameView());
    }
}