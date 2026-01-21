namespace Match3OOAP.GameLogic.BonusSystem
{
    public abstract class AutoApplicableBonus : Bonus
    {
        public sealed override bool IsAutoApplyAvailable() => true;
    }
}