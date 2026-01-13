using Match3OOAP.GameLogic.BonusSystem;
using Match3OOAP.InputHandle;

namespace Match3OOAP.Gui.GameScreen
{
    public class BonusPresenter : GuiPresenter<BonusView>, IBonusPresenter
    {
        public BonusPresenter(BonusView view) : base(view)
        {
        }

        public void ShowRemoveBonus(BonusId bonusId)
        {
            throw new System.NotImplementedException();
        }

        public void ShowAddBonus(BonusId bonusId)
        {
            throw new System.NotImplementedException();
        }

        public override void UpdateViewImmedaitely()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IBonusPresenter : IPresentable
    {
        void ShowRemoveBonus(BonusId bonusId);
        
        void ShowAddBonus(BonusId bonusId);
        
        
    }
}