
using Match3OOAP.GameLogic.Statistics;
using Match3OOAP.Gui;
using Match3OOAP.Gui.StartGameScreen;
using Match3OOAP.InputHandle;

namespace Match3OOAP.GameLifeCycle.GameStateManagement.GameStates
{
    public class ReadyState : GameState
    {
        private IPresentable _guiPresenter;
        
        public sealed override string Name => nameof(ReadyState);

        // Постусловие: экран стартового меню готов к показу.
        public ReadyState()
        {
            _guiPresenter = GetReadyStatePresenter();
        }

        // Постусловие: экран стартового меню активен.
        public sealed override void SetState()
        {
            _guiPresenter.Activate();
        }

        // Постусловие: экран стартового отключен.
        public sealed override void ResetState()
        {
            _guiPresenter.Deactivate();
        }

        protected virtual IPresentable GetReadyStatePresenter() => new StartGamePresenter(new StartGameView());
    }
}