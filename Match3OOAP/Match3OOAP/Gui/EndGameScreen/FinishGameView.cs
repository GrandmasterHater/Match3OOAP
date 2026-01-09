using System;
using Match3OOAP.InputHandle;

namespace Match3OOAP.Gui.EndGameScreen
{
    public class FinishGameView : IGuiView
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