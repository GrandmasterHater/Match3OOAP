using System;
using Match3OOAP.InputHandle;

namespace Match3OOAP.Gui.GameScreen.Presenters
{
    public class HowToPlayInfoPresenter : GuiPresenter<IGameInfoView>
    {
        private string _infoText = "To perform a move, enter the column and row of elements you want to rearrange. Example: \"A1 B1\"\n" +
                                   "To skip steps enter any symbol.\n" +
                                   "To apply the bonus, enter the bonus name: \"BRL\"\n" +
                                   "To finish the game, enter \"F\"";
        public HowToPlayInfoPresenter(GameInfoView infoView) : base(infoView)
        { }

        public override void UpdateData() { }

        public override void UpdateViewImmedaitely()
        {
            View.SetInfo(_infoText);
            View.Redraw();
        }

        protected override void OnActivate()
        {
            View.SetInfo(_infoText);
        }

        protected override void OnDeactivate() { }
    }
}