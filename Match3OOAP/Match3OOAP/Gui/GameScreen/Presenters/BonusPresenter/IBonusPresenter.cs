using Match3OOAP.GameLogic.BonusSystem;
using Match3OOAP.InputHandle;

namespace Match3OOAP.Gui.GameScreen.Presenters
{
    public interface IBonusPresenter : IPresentable
    {
        void ShowRemoveBonus(BonusId bonusId);
        
        void ShowAddBonus(BonusId bonusId);

        void ShowAutoBonusApplied();

        bool TryHandleInput(string inputText);
    }
}