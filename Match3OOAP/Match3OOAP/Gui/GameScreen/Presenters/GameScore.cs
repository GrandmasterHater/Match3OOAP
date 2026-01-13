using Match3OOAP.InputHandle;

namespace Match3OOAP.Gui.GameScreen
{
    public class GameScorePresenter : GuiPresenter<GameStatisticsView>
    {
        public GameScorePresenter(GameStatisticsView view) : base(view) { }
        
        public override void UpdateViewImmedaitely()
        {
            throw new System.NotImplementedException();
        }
    }
}