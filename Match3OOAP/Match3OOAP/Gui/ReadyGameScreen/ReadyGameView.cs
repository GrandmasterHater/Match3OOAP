using System;
using System.Text;
using Match3OOAP.InputHandle;

namespace Match3OOAP.Gui.StartGameScreen
{
    public class ReadyGameView : IReadyGameView
    {
        private string _infoText;
        private string _dialogText;
        
        public bool IsVisible { get; }
        
        public void Show()
        {
            DrawText();
        }

        public void Hide()
        {
            Console.Clear();
        }

        public void Redraw()
        {
            DrawText();
        }

        public void SetInfoText(string text) => _infoText = text;

        public void SetDialogText(string text) => _dialogText = text;

        private void DrawText()
        {
            Console.Clear();
            Console.WriteLine(_infoText);
            Console.WriteLine();
            Console.WriteLine(_dialogText);
        }
    }
}