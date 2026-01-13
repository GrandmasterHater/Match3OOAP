using Match3OOAP.GameLogic.Statistics;
using Match3OOAP.InputHandle;

namespace Match3OOAP.Gui.EndGameScreen
{
    public class FinishGamePresenter : GuiPresenter<FinishGameView>
    {
        public FinishGamePresenter(IScore score, IMoveHistory moveHistory, FinishGameView view) : base(view)
        {
        }

        public override void UpdateViewImmedaitely()
        {
            throw new System.NotImplementedException();
        }
    }
}