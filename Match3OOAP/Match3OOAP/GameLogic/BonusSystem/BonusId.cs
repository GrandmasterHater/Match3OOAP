using System;

namespace Match3OOAP.GameLogic.BonusSystem
{
    public abstract class BonusId
    {
        public abstract string Id { get; }

        public BonusId()
        {
            if (string.IsNullOrEmpty(Id)) 
                throw new ArgumentNullException(nameof(Id));
        }

        public override string ToString() => Id;
    }
}