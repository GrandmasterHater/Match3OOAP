using Match3OOAP.Helpers;
using Match3OOAP.InputHandle;

namespace Match3OOAP.Gui.GameScreen
{
    public class InvalidMoveInfoPresenter : GuiPresenter<IGameInfoView>, IInvalidMoveInfoPresenter
    {
        private string _text;

        public InvalidMoveInfoPresenter(IGameInfoView infoView) : base(infoView)
        {
            _text = string.Empty;
        }

        public override void UpdateData() { }

        public override void UpdateViewImmedaitely()
        {
            View.SetInfo($"\n{_text}");
            View.Redraw();
        }

        public void SetInvalidMoveInfo(string text)
        {
            text.AssertNotNull();

            _text = text;
        }
    }
}