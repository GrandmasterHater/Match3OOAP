using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Match3OOAP.GameLogic.BonusSystem;
using Match3OOAP.GameLogic.GameGrid;
using Match3OOAP.Helpers;

namespace Match3OOAP.GameLogic.GameMove.StepCommands
{
    public class ApplyAutoBonusesStep : IStep
    {
        private readonly IGrid _grid;
        private readonly IBonusContainer<AutoApplicableBonus> _autoApplicableBonusContainer;
        private IReadOnlyList<Coordinate> _removedCoordinates;

        public ApplyAutoBonusesStep(IGrid grid, IBonusContainer<AutoApplicableBonus> autoApplicableBonusContainer)
        {
            grid.AssertNotNull();
            autoApplicableBonusContainer.AssertNotNull();

            _grid = grid;
            _autoApplicableBonusContainer = autoApplicableBonusContainer;
            _removedCoordinates = new List<Coordinate>();
        }

        public void Execute()
        {
            foreach (AutoApplicableBonus bonus in _autoApplicableBonusContainer)
            {
                bonus.Apply(_grid);
            }
            
            _autoApplicableBonusContainer.Clear();

            _removedCoordinates = _grid.GetEmptyCells();
        }

        public void ReadResult(IStepReader readerVisitor)
        {
            readerVisitor.Read(this);
        }

        public IReadOnlyList<Coordinate> GetRemovedCoordinates() => _removedCoordinates;
    }

    public class ApplyManualBonusStep : IStep
    {
        private readonly IGrid _grid;
        private readonly BonusId _bonusId;
        private readonly IBonusContainer<ManualApplicableBonus> _bonusContainer;
        
        private ApplyBonusResult _applyBonusResult;
        
        public ApplyManualBonusStep(IGrid grid, BonusId bonusId, IBonusContainer<ManualApplicableBonus> bonusContainer)
        {
            grid.AssertNotNull();
            bonusId.AssertNotNull();
            bonusContainer.AssertNotNull();

            _grid = grid;
            _bonusId = bonusId;
            _bonusContainer = bonusContainer;
        }
        public void Execute()
        {
            ManualApplicableBonus? bonus = _bonusContainer.FirstOrDefault(bonus => bonus.GetId() == _bonusId);

            if (bonus == null)
            {
                _applyBonusResult = new ApplyBonusResult(false, "There is no such bonus.", _bonusId);
                return;
            }
                
            bonus.Apply(_grid); 
            _applyBonusResult = new ApplyBonusResult(true, string.Empty, _bonusId);
        }

        public void ReadResult(IStepReader readerVisitor)
        {
            readerVisitor.Read(this);
        }
        
        public ApplyBonusResult GetApplyBonusResult() => _applyBonusResult;
    }
}
    