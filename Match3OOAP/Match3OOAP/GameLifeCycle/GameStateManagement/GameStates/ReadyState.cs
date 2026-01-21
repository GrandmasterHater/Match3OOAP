
using Match3OOAP.GameLogic.Statistics;
using Match3OOAP.Gui;
using Match3OOAP.Gui.StartGameScreen;
using Match3OOAP.Helpers;
using Match3OOAP.InputHandle;

namespace Match3OOAP.GameLifeCycle.GameStateManagement.GameStates
{
    public class ReadyState : GameState
    {
        private readonly GameController _gameController;
        private readonly IPresentable _guiPresenter;
        
        public override GameStatus GameStatus => GameStatus.ReadyToGame;

        // Постусловие: экран стартового меню готов к показу.
        public ReadyState(GameController gameController)
        {
            gameController.AssertNotNull();
            
            _gameController = gameController;
            _guiPresenter = GetReadyStatePresenter();
        }

        // Постусловие: экран стартового меню активен.
        protected override void OnSetState()
        {
            _guiPresenter.Activate();
        }

        // Постусловие: экран стартового отключен.
        protected override void OnResetState()
        {
            _guiPresenter.Deactivate();
        }

        protected virtual IPresentable GetReadyStatePresenter()
        {
            return new ReadyGamePresenter(_gameController, ConsoleAsyncInputListener.Instance, new ReadyGameView());
        }
    }
}