using System;
using Match3OOAP.InputHandle;

namespace Match3OOAP.Gui
{
    public interface IGuiView
    {
        bool IsVisible { get; }
        
        event Action<string> OnGetUserInput;

        void Show();

        void Hide();
    }
}