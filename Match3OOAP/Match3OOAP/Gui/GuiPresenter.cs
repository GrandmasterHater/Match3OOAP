using System;
using Match3OOAP.Gui;

namespace Match3OOAP.InputHandle
{
    public abstract class GuiPresenter<TView> : IGuiPresenter where TView : class, IGuiView
    {
        protected TView View { get; }

        #region Конструктор

        protected GuiPresenter(TView view)
        {
            View = view ?? throw new ArgumentNullException(nameof(view));
        }

        #endregion
        
        
        #region Команды

        public void Activate()
        {
            try
            {
                OnActivate();
            }
            catch (Exception e)
            {
                // todo: преобразовать в статус
            }

            View.OnGetUserInput += OnUserInput; 
            View.Show();
        }

        public void Deactivate()
        {
            View.Hide();
            View.OnGetUserInput -= OnUserInput; 
            
            try
            {
                OnDeactivate();
            }
            catch (Exception e)
            {
                // todo: преобразовать в статус
            }
        }

        #endregion
        
        protected virtual void OnActivate() { }
        
        protected virtual void OnDeactivate() { }
        
        protected virtual void OnUserInput(string inputString) { }
    }
}