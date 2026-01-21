using System;
using Match3OOAP.InputHandle;

namespace Match3OOAP.Gui.GameScreen
{
    public class GameScoreView : IGameScoreView
    {
        private string _scoreText;
        public bool IsVisible { get; private set; }
        public void Show()
        {
            DrawScore();
            IsVisible = true;
        }

        public void Hide()
        {
            IsVisible = false;
        }

        public void Redraw()
        {
            DrawScore();
        }

        public void SetScoreText(string scoreText)
        {
            _scoreText = scoreText;
        }
        
        private void DrawScore()
        {
            Console.WriteLine(_scoreText);
        }
    }
}