using System;
using Match3OOAP.GameLifeCycle.GameStateManagement;
using Match3OOAP.Helpers;
using Match3OOAP.InputHandle;

namespace Match3OOAP.Gui.StartGameScreen
{
    public class ReadyGamePresenter : GuiPresenter<IReadyGameView>
    {
        private readonly string _infoText = "Match 3 by guschins_95";
        private readonly string _dialogText = "To start the game, enter 'S', to exit, enter 'E'";
        
        private readonly GameController _gameController;
        private readonly IConsoleAsyncInputListener _inputListener;
        
        public ReadyGamePresenter(GameController controller, IConsoleAsyncInputListener inputListener, IReadyGameView view) : base(view)
        {
            controller.AssertNotNull();
            inputListener.AssertNotNull();
            
            _gameController = controller;
            _inputListener = inputListener;
        }

        protected override void OnActivate()
        {
            View.SetInfoText(_infoText);
            View.SetDialogText(_dialogText);
            View.Show();
            
            _inputListener.OnUserInputReceived += OnUserInputReceived;
        }

        protected override void OnDeactivate()
        {
            _inputListener.OnUserInputReceived -= OnUserInputReceived;
            View.Hide();
        }

        public override void UpdateData() { }

        public override void UpdateViewImmedaitely()
        {
            View.SetInfoText(_infoText);
            View.SetDialogText(_dialogText);
            View.Redraw();
        }
        
        private void OnUserInputReceived(string rawText)
        {
            if (string.Equals(rawText, "S", StringComparison.OrdinalIgnoreCase)) 
                _gameController.StartGame();
            
            if (string.Equals(rawText, "E", StringComparison.OrdinalIgnoreCase)) 
                _gameController.CloseGame();
        }
    }
    
    
}