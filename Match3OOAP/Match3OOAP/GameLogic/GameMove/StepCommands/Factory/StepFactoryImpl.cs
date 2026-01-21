using System.Collections.Generic;
using Match3OOAP.GameLogic.BonusSystem;
using Match3OOAP.GameLogic.Core;
using Match3OOAP.GameLogic.GameGrid;
using Match3OOAP.GameLogic.Statistics;
using Match3OOAP.Helpers;

namespace Match3OOAP.GameLogic.GameMove.StepCommands
{
    public class StepFactoryImpl : IStepFactory
    {
        private readonly IGrid _grid;
        private readonly IScore _score;
        private readonly IBonusFactory _bonusFactory;
        private readonly IBonusContainer<AutoApplicableBonus> _autoBonusContainer;
        private readonly IBonusContainer<ManualApplicableBonus> _manualBonusContainer;

        public StepFactoryImpl(
            IGrid grid, 
            IScore score, 
            IBonusFactory bonusFactory,
            IBonusContainer<AutoApplicableBonus> autoBonusContainer, 
            IBonusContainer<ManualApplicableBonus> manualBonusContainer)
        {
            grid.AssertNotNull();
            score.AssertNotNull();
            bonusFactory.AssertNotNull();
            autoBonusContainer.AssertNotNull();
            manualBonusContainer.AssertNotNull();
            
            _grid = grid;
            _score = score;
            _bonusFactory = bonusFactory;
            _autoBonusContainer = autoBonusContainer;
            _manualBonusContainer = manualBonusContainer;
        }
        
        public ApplyAutoBonusesStep CreateApplyAutoBonusesStep()
        {
            return new ApplyAutoBonusesStep(_grid, _autoBonusContainer);
        }

        public CheckNextMoveAvailableStep CreateCheckNextMoveAvailableStep()
        {
            return new CheckNextMoveAvailableStep(_grid, _manualBonusContainer);
        }

        public CheckSwapPossibleStep CreateCheckSwapPossibleStep(Coordinate firstCoordinate, Coordinate secondCoordinate)
        {
            return new CheckSwapPossibleStep(_grid, firstCoordinate, secondCoordinate);
        }

        public FindBonusesStep CreateFindBonusesStep(IReadOnlyList<Combination> combinations)
        {
            return new FindBonusesStep(combinations, _bonusFactory, _autoBonusContainer, _manualBonusContainer);
        }

        public FindCombinationsStep CreateFindCombinationsStepByCoordinates(IReadOnlyList<Coordinate> coordinates)
        {
            return new FindCombinationsStepByCoordinates(_grid, coordinates);
        }

        public FindCombinationsStep CreateFindCombinationsOnGrid()
        {
            return new FindCombinationsStepOnGrid(_grid);
        }

        public FindCombinationsStep CreateFindCombinationsBySwapStep(Coordinate firstCoordinate, Coordinate secondCoordinate)
        {
            return new FindCombinationsBySwapStep(_grid, firstCoordinate, secondCoordinate);
        }

        public GenerateNewElementsStep CreateGenerateNewElementsStep()
        {
            return new GenerateNewElementsStep(_grid);
        }

        public MoveDownElementsStep CreateMoveDownElementsStep()
        {
            return new MoveDownElementsStep(_grid);
        }

        public RemoveCombinationFromGridStep CreateRemoveCombinationFromGridStep(IReadOnlyList<Combination> combination)
        {
            return new RemoveCombinationFromGridStep(_grid, combination);
        }

        public UpdateScoreStep CreateUpdateScoreStep(IReadOnlyList<Combination> combinations)
        {
            return new UpdateScoreStep(_score, combinations);
        }

        public ApplySwapStep CreateApplySwapStep(Coordinate firstCoordinate, Coordinate secondCoordinate)
        {
            return new ApplySwapStep(_grid, firstCoordinate, secondCoordinate);
        }

        public ApplyManualBonusStep CreateApplyManualBonusStep(BonusId bonusId)
        {
            return new ApplyManualBonusStep(_grid, bonusId, _manualBonusContainer);
        }
    }
}