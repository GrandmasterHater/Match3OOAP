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

            View.Show();
        }

        public void Deactivate()
        {
            View.Hide();
            
            try
            {
                OnDeactivate();
            }
            catch (Exception e)
            {
                // todo: преобразовать в статус
            }
        }

        public abstract void UpdateData();

        public abstract void UpdateViewImmedaitely();

        #endregion
        
        protected virtual void OnActivate() { }
        
        protected virtual void OnDeactivate() { }
    }
}