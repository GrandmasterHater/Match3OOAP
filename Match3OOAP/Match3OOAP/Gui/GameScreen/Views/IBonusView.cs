namespace Match3OOAP.Gui.GameScreen
{
    public interface IBonusView : IGuiView
    {
        void SetAutoBonusText(string text);
        string GetAutoBonusText();
        void SetManualBonusText(string text);
        string GetManualBonusText();
    }
}