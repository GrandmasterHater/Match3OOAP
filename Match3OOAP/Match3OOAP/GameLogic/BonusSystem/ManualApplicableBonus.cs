namespace Match3OOAP.GameLogic.BonusSystem
{
    public abstract class ManualApplicableBonus : Bonus
    {
        public sealed override bool IsAutoApplyAvailable() => false;

        public abstract BonusId GetId();
    }
}