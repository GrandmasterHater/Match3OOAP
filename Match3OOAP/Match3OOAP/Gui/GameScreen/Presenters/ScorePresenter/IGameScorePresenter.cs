using Match3OOAP.InputHandle;

namespace Match3OOAP.Gui.GameScreen
{
    public interface IGameScorePresenter : IPresentable
    {
        void DrawChange(int scoreChange);
    }
}