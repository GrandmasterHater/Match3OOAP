using System;
using Match3OOAP.Helpers;

namespace Match3OOAP.Gui.GameScreen
{
    public class BonusView : IBonusView
    {
        private string _autoBonusText;
        private string _manualBonusText;
        
        public bool IsVisible { get; private set; }

        public BonusView()
        {
            IsVisible = false;
            _autoBonusText = string.Empty;
            _manualBonusText = string.Empty;
        }
        
        public void Show()
        {
            DrawText();
            IsVisible = true;
        }

        public void Hide()
        {
            DrawText();
            IsVisible = false;
        }

        public void Redraw()
        {
            DrawText();
        }

        public void SetAutoBonusText(string text)
        {
            text.AssertNotNull();

            _autoBonusText = text;
        }

        public string GetAutoBonusText() => _autoBonusText;

        public void SetManualBonusText(string text)
        {
            text.AssertNotNull();

            _manualBonusText = text;
        }

        public string GetManualBonusText() => _manualBonusText;

        private void DrawText()
        {
            Console.WriteLine(_autoBonusText);
            Console.WriteLine(_manualBonusText);
        }
    }
}