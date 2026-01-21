using Match3OOAP.InputHandle;

namespace Match3OOAP.Gui.GameScreen
{
    public interface IInvalidMoveInfoPresenter : IPresentable
    {
        void SetInvalidMoveInfo(string text);
    }
}