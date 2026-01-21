namespace Match3OOAP.Gui.StartGameScreen
{
    public interface IReadyGameView : IGuiView
    {
        void SetInfoText(string text);
        
        void SetDialogText(string text);
    }
}