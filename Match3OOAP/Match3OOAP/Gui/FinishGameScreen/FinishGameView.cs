using System;

namespace Match3OOAP.Gui.FinishGameScreen
{
    public class FinishGameView : IFinishGameView
    {
        private string _scoreText;
        private string _moveCountText;
        private string _dialogText;
        
        public bool IsVisible { get; private set; }

        public void Show()
        {
            DrawText();
            IsVisible = true;
        }

        public void Hide()
        {
            Console.Clear();
            IsVisible = false;
        }

        public void Redraw()
        {
            DrawText();
        }

        private void DrawText()
        {
            Console.Clear();
            Console.WriteLine($"{_moveCountText}\n\n{_scoreText}\n\n{_dialogText}");
        }

        public void SetScore(int score) =>
            _scoreText = $"Total score: {score}";
        

        public void SetMoveCount(int moveCount) => 
            _moveCountText = $"You made {moveCount} moves.";

        public void SetDialogText(string text) =>
            _dialogText = text;
    }
}