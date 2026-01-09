
using Match3OOAP.Gui;
using Match3OOAP.Gui.StartGameScreen;
using Match3OOAP.InputHandle;

namespace Match3OOAP.GameLifeCycle.GameStateManagement.GameStates
{
    public class ReadyState : GameState
    {
        private IGuiPresenter _guiPresenter;
        
        public sealed override string Name => nameof(ReadyState);

        public ReadyState()
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

        protected virtual IGuiPresenter GetReadyStatePresenter() => new StartGamePresenter(new StartGameView());
    }
}