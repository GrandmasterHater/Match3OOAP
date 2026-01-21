using System;
using Match3OOAP.GameLifeCycle.GameStateManagement;
using Match3OOAP.GameLogic.Statistics;
using Match3OOAP.Helpers;
using Match3OOAP.InputHandle;

namespace Match3OOAP.Gui.FinishGameScreen
{
    public class FinishGamePresenter : GuiPresenter<FinishGameView>
    {
        private readonly string _dialogText = "Press 'R' to start a new game or 'E' to exit.";
        
        private readonly IScore _score;
        private readonly IMoveHistory _moveHistory;
        private readonly GameController _gameController;
        private readonly IConsoleAsyncInputListener _inputListener; 
        
        public FinishGamePresenter(
            IScore score, 
            IMoveHistory moveHistory, 
            IConsoleAsyncInputListener inputListener,
            GameController gameController, 
            FinishGameView view) 
            : base(view)
        {
            score.AssertNotNull();
            moveHistory.AssertNotNull();
            gameController.AssertNotNull();
            inputListener.AssertNotNull();
            
            _score = score;
            _moveHistory = moveHistory;
            _gameController = gameController;
            _inputListener = inputListener;
        }

        protected override void OnActivate()
        {
            View.SetMoveCount(_moveHistory.Count);
            View.SetScore(_score.GetScore());
            View.SetDialogText(_dialogText);
            _inputListener.OnUserInputReceived += OnUserInputReceived;
        }
        
        protected override void OnDeactivate()
        {
            _inputListener.OnUserInputReceived -= OnUserInputReceived;
        }

        private void OnUserInputReceived(string rawText)
        {
            if (string.Equals(rawText, "R", StringComparison.OrdinalIgnoreCase)) 
                _gameController.StartGame();
            
            if (string.Equals(rawText, "E", StringComparison.OrdinalIgnoreCase)) 
                _gameController.CloseGame();
        }

        public override void UpdateData() { }

        public override void UpdateViewImmedaitely()
        {
            View.SetMoveCount(_moveHistory.Count);
            View.SetScore(_score.GetScore());
            View.Redraw();
        }
    }
}