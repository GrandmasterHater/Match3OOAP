using System;
using Match3OOAP.InputHandle;

namespace Match3OOAP.Gui.StartGameScreen
{
    public class StartGameView : IGuiView
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