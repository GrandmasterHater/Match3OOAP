namespace Match3OOAP.Gui.FinishGameScreen
{
    public interface IFinishGameView : IGuiView
    {
        void SetScore(int score);
        
        void SetMoveCount(int moveCount);
        
        void SetDialogText(string text);
    }
}