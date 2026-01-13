using System;
using Match3OOAP.Gui;

namespace Match3OOAP.InputHandle
{
    public abstract class GuiPresenter<TView> : IPresentable where TView : class, IGuiView
    {
        protected TView View { get; }

        #region Конструктор

        protected GuiPresenter(TView infoView)
        {
            View = infoView ?? throw new ArgumentNullException(nameof(infoView));
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

        public abstract void UpdateViewImmedaitely();

        #endregion
        
        protected virtual void OnActivate() { }
        
        protected virtual void OnDeactivate() { }
        
        protected virtual void OnUserInput(string inputString) { }
    }
}