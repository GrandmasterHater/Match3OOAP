using System.Text;
using System.Text.RegularExpressions;
using Match3OOAP.GameLogic.BonusSystem;
using Match3OOAP.GameLogic.GameMove;
using Match3OOAP.Gui.GameScreen.Presenters;
using Match3OOAP.Helpers;
using Match3OOAP.InputHandle;

namespace Match3OOAP.Gui.GameScreen
{
    public class BonusPresenter : GuiPresenter<IBonusView>, IBonusPresenter
    {
        private readonly IBonusContainer<ManualApplicableBonus> _bonusContainer;
        private readonly IMove _move;
        private readonly Regex _applyBonusCommandRegex;

        public BonusPresenter(IBonusContainer<ManualApplicableBonus> bonusContainer, IMove move, BonusView view) : base(view)
        {
            bonusContainer.AssertNotNull();
            move.AssertNotNull();
            
            _bonusContainer = bonusContainer;
            _move = move;
            _applyBonusCommandRegex = new Regex("^[A-Za-z]{3,6}([1-9])?$", RegexOptions.Compiled);
        }

        protected override void OnActivate()
        {
            SetBonusText();
        }

        public void ShowRemoveBonus(BonusId bonusId)
        {
            string manualBonusesLine = GetManualBonusLine();
            
            View.SetManualBonusText($"Bonuses: {manualBonusesLine} (Used: {bonusId})");
            View.Redraw();
        }

        public void ShowAddBonus(BonusId bonusId)
        {
            string manualBonusesLine = GetManualBonusLine();
            
            View.SetManualBonusText($"Bonuses: {manualBonusesLine} (Added: {bonusId})");
            View.SetAutoBonusText(string.Empty);
            View.Redraw();
        }

        public void ShowAutoBonusApplied()
        {
            string manualBonusesLine = GetManualBonusLine();
            
            View.SetManualBonusText($"Bonuses: {manualBonusesLine}");
            View.SetAutoBonusText("!!!Auto bonus applied!!!");
            View.Redraw();
        }

        public override void UpdateData()
        {
            SetBonusText();
        }
        
        private void SetBonusText()
        {
            string manualBonusesLine = GetManualBonusLine();
            
            View.SetManualBonusText($"Bonuses: {manualBonusesLine}");
            View.SetAutoBonusText(string.Empty);
        }

        public override void UpdateViewImmedaitely()
        {
            View.Redraw();
        }

        private string GetManualBonusLine()
        {
            if (_bonusContainer.Count == 0)
                return "none"; 
            
            StringBuilder sb = new StringBuilder();

            foreach (ManualApplicableBonus manualApplicableBonus in _bonusContainer)
            {
                sb.Append(manualApplicableBonus.GetId()).Append(" ");
            }

            return sb.ToString()
                .Trim()
                .Replace(" ", ", ");
        }
        
        public bool TryHandleInput(string inputText)
        {
            if (string.IsNullOrEmpty(inputText))
                return false;

            string bonusCommand = inputText.Trim();
            
            if (!_applyBonusCommandRegex.IsMatch(bonusCommand))
                return false;

            BonusId bonusId = null;

            foreach (ManualApplicableBonus bonus in _bonusContainer)
            {
                BonusId currentBonus = bonus.GetId();
                if (currentBonus.Id == bonusCommand)
                {
                    bonusId = currentBonus;
                    break;
                }
            }
            
            bool hasBonus = bonusId != null;

            if (hasBonus)
            {
                _move.ApplyBonus(bonusId!);
            }
            
            return hasBonus; 
        }
    }
}