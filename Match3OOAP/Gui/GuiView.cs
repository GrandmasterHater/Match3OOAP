using System;
using Match3OOAP.InputHandle;

namespace Match3OOAP.Gui
{
    public abstract class GuiView
    {
        public bool IsVisible { get; }
        
        public event Action<string> OnGetUserInput;

        public GuiView(AsyncInputListener inputListener)
        {
            
        }
        
        public void Show() { }
        
        public void Hide() { }
    }
}