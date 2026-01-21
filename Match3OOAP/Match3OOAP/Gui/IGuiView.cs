using System;
using Match3OOAP.InputHandle;

namespace Match3OOAP.Gui
{
    public interface IGuiView
    {
        bool IsVisible { get; }

        void Show();

        void Hide();

        void Redraw();
    }
}