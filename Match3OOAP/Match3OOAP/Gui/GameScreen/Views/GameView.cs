using System;

namespace Match3OOAP.Gui.GameScreen
{
    public class GameView : IGuiView
    {
        public bool IsVisible { get; }
        
        public event Action<string> OnGetUserInput;
        public void Show()
        {
            throw new NotImplementedException();
        }

        public void Hide()
        {
            throw new NotImplementedException();
        }
    }
}