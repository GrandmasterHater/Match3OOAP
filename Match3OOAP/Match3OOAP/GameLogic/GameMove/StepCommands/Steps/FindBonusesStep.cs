using System;
using System.Collections.Generic;
using Match3OOAP.GameLogic.BonusSystem;
using Match3OOAP.GameLogic.Core;
using Match3OOAP.Helpers;

namespace Match3OOAP.GameLogic.GameMove.StepCommands
{
    public class FindBonusesStep : IStep
    {
        private readonly IBonusContainer<AutoApplicableBonus> _autoBonusesContainer;
        private readonly IBonusContainer<ManualApplicableBonus> _manualBonusesContainer;
        private readonly IReadOnlyList<Combination> _combinations;
        private readonly IBonusFactory _bonusFactory;

        public FindBonusesStep(
            IReadOnlyList<Combination> combinations, 
            IBonusFactory bonusFactory,
            IBonusContainer<AutoApplicableBonus> autoBonusesContainer,
            IBonusContainer<ManualApplicableBonus> manualBonusesContainer)
        {
            combinations.AssertNotNull();
            combinations.AssertItemsNotNull();
            bonusFactory.AssertNotNull();
            autoBonusesContainer.AssertNotNull();
            manualBonusesContainer.AssertNotNull();

            _combinations = combinations;
            _bonusFactory = bonusFactory;
            _autoBonusesContainer = autoBonusesContainer;
            _manualBonusesContainer = manualBonusesContainer;
        }
        
        public void Execute()
        {
            foreach (Combination combination in _combinations)
            {
                FindAutoApplicableBonuses(combination);
                FindManualApplicableBonuses(combination);
            }
        }

        private void FindAutoApplicableBonuses(Combination combination)
        {
            IReadOnlyList<AutoApplicableBonus> autoApplicableBonuses = _bonusFactory.CreateAutoBonuses();

            foreach (AutoApplicableBonus autoApplicableBonus in autoApplicableBonuses)
            {
                autoApplicableBonus.SetCombination(combination);
                
                if (autoApplicableBonus.IsBonusAvailable())
                {
                    _autoBonusesContainer.Add(autoApplicableBonus);
                }
            }
        }
        
        private void FindManualApplicableBonuses(Combination combination)
        {
            IReadOnlyList<ManualApplicableBonus> manualApplicableBonuses = _bonusFactory.CreateManualBonuses();
            
            foreach (ManualApplicableBonus manualApplicableBonus in manualApplicableBonuses)
            {
                manualApplicableBonus.SetCombination(combination);
                
                if (manualApplicableBonus.IsBonusAvailable())
                {
                    _manualBonusesContainer.Add(manualApplicableBonus);
                }
            }
        }

        public void ReadResult(IStepReader readerVisitor)
        {
            readerVisitor.Read(this);
        }

        public IReadOnlyList<Bonus> GetBonuses()
        {
            throw new System.NotImplementedException();   
        }
        
        
    }
}