using System;
using Match3OOAP.GameLogic.Statistics;
using Match3OOAP.Helpers;
using Match3OOAP.InputHandle;

namespace Match3OOAP.Gui.GameScreen
{
    public class GameScorePresenter : GuiPresenter<GameScoreView>, IGameScorePresenter
    {
        private readonly IScore _score;
        private int _currentScore;

        public GameScorePresenter(IScore score, GameScoreView view) : base(view)
        {
            score.AssertNotNull();

            _score = score;
            _currentScore = 0;
        }

        protected override void OnActivate()
        {
            _currentScore = _score.GetScore();
            SetScoreToView(_currentScore);
        }

        public void DrawChange(int scoreChange)
        {
            SetScoreChangeToView(_currentScore, scoreChange);
            View.Redraw();
        }

        public override void UpdateData()
        {
            _currentScore = _score.GetScore();
        }

        public override void UpdateViewImmedaitely()
        {
            SetScoreToView(_currentScore);
            View.Redraw();
        }

        private void SetScoreToView(int score)
        {
            View.SetScoreText($"\n Score: {score}");
        }

        private void SetScoreChangeToView(int score, int scoreChange)
        {
            string changeSymbol = GetScoreChangeSymbol(scoreChange);
            
            View.SetScoreText($"\n Score: {score} ({changeSymbol}{scoreChange})");
        }

        private string GetScoreChangeSymbol(int scoreChange)
        {
            string changeSymbol = string.Empty;
            int sign = Math.Sign(scoreChange);
            
            if (sign > 0)
                changeSymbol = "+";
            else if (sign < 0)
                changeSymbol = "-";
            
            return changeSymbol; 
        }
    }
}