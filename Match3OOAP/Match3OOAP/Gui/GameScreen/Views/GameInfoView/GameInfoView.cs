using System;

namespace Match3OOAP.Gui.GameScreen
{
    public class GameInfoView : IGameInfoView
    {
        private string _infoText = string.Empty;
        
        public bool IsVisible { get; private set; }
        
        public void Show()
        {
            DrawInfo();
            IsVisible = true;
        }

        public void Hide()
        {
            IsVisible = false;
        }

        public void Redraw()
        {
            DrawInfo();
        }

        public void SetInfo(string infoText)
        {
            _infoText = infoText;
        }
        
        private void DrawInfo()
        {
            if (!string.IsNullOrEmpty(_infoText))
            {
                Console.WriteLine(_infoText);
            }
        }
    }
}