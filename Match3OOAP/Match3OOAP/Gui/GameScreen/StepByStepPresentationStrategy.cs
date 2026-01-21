using System;
using System.Collections.Generic;
using System.Threading;
using Match3OOAP.GameLogic.GameGrid;
using Match3OOAP.GameLogic.GameMove.Moves;
using Match3OOAP.GameLogic.GameMove.StepCommands;
using Match3OOAP.Gui.GameScreen.Presenters;
using Match3OOAP.Helpers;
using Match3OOAP.InputHandle;

namespace Match3OOAP.Gui.GameScreen
{
    public class StepByStepPresentationStrategy : Strategy, IStepReader
    {
        private readonly IGameScorePresenter _scorePresenter;
        private readonly IGridPresenter _gridPresenter;
        private readonly IBonusPresenter _bonusPresenter;
        private readonly IPresentable _gameInfoPresenter;
        private readonly IInvalidMoveInfoPresenter _invalidMoveInfoPresenter;
        private readonly MoveResult _moveResult;
        private readonly Func<bool>  _isStopPresentation;

        public StepByStepPresentationStrategy(
            IGameScorePresenter scorePresenter,
            IGridPresenter gridPresenter,
            IBonusPresenter bonusPresenter,
            IPresentable gameInfoPresenter,
            IInvalidMoveInfoPresenter invalidMoveInfoPresenter,
            MoveResult moveResult,
            Func<bool> isStopPresentation)
        {
            scorePresenter.AssertNotNull();
            gridPresenter.AssertNotNull();
            bonusPresenter.AssertNotNull();
            gameInfoPresenter.AssertNotNull();
            invalidMoveInfoPresenter.AssertNotNull();
            moveResult.AssertNotNull();
            isStopPresentation.AssertNotNull();

            _scorePresenter = scorePresenter;
            _gridPresenter = gridPresenter;
            _bonusPresenter = bonusPresenter;
            _gameInfoPresenter = gameInfoPresenter;
            _invalidMoveInfoPresenter = invalidMoveInfoPresenter;
            _moveResult = moveResult;
            _isStopPresentation = isStopPresentation;
        }

        protected override void OnExecute()
        {
            _invalidMoveInfoPresenter.SetInvalidMoveInfo(string.Empty);
            _invalidMoveInfoPresenter.UpdateViewImmedaitely();
            
            foreach (IStep step in _moveResult)
            {
                if (_isStopPresentation())
                    break;
                
                Console.Clear();
                step.ReadResult(this);
            }
        }
        
        public void Read(CheckSwapPossibleStep checkSwapPossibleStep)
        {
            _gameInfoPresenter.UpdateViewImmedaitely();
            _scorePresenter.UpdateViewImmedaitely();
            _gridPresenter.UpdateViewImmedaitely();
            _bonusPresenter.UpdateViewImmedaitely();

            if (!checkSwapPossibleStep.IsSwapPossible)
                _invalidMoveInfoPresenter.SetInvalidMoveInfo(checkSwapPossibleStep.AvailabilityInfo);
            else
                _invalidMoveInfoPresenter.SetInvalidMoveInfo(string.Empty);
            
            _invalidMoveInfoPresenter.UpdateViewImmedaitely();
        }

        public void Read(FindCombinationsStep findCombinationsStep)
        {
            _gameInfoPresenter.UpdateViewImmedaitely();
            _scorePresenter.UpdateViewImmedaitely();
            _gridPresenter.UpdateViewImmedaitely();
            _bonusPresenter.UpdateViewImmedaitely();
            _invalidMoveInfoPresenter.UpdateViewImmedaitely();
        }
        
        public void Read(ApplySwapStep applySwapStep)
        {
            _gameInfoPresenter.UpdateViewImmedaitely();
            _scorePresenter.UpdateViewImmedaitely();
            
            _gridPresenter.ShowSwap(applySwapStep.FirstCoordinate, applySwapStep.SecondCoordinate);
            
            _bonusPresenter.UpdateViewImmedaitely();
            _invalidMoveInfoPresenter.UpdateViewImmedaitely();
            
            Thread.Sleep(1000);
        }

        public void Read(FindCombinationsBySwapStep findCombinationsBySwapStep)
        {
            _gameInfoPresenter.UpdateViewImmedaitely();
            _scorePresenter.UpdateViewImmedaitely();
            _gridPresenter.UpdateViewImmedaitely();
            _bonusPresenter.UpdateViewImmedaitely();
            
            if (!findCombinationsBySwapStep.HasCombinations())
                _invalidMoveInfoPresenter.SetInvalidMoveInfo("Combinations not found!");
            else
                _invalidMoveInfoPresenter.SetInvalidMoveInfo(string.Empty);
            
            _invalidMoveInfoPresenter.UpdateViewImmedaitely();
            
            Thread.Sleep(1000);
        }

        public void Read(CheckNextMoveAvailableStep removeCombinationFromGridStep)
        {
            _gameInfoPresenter.UpdateViewImmedaitely();
            _scorePresenter.UpdateViewImmedaitely();
            _gridPresenter.UpdateViewImmedaitely();
            _bonusPresenter.UpdateViewImmedaitely();
            _invalidMoveInfoPresenter.UpdateViewImmedaitely();
        }

        public void Read(ApplyManualBonusStep applyManualBonusStep)
        {
            _gameInfoPresenter.UpdateViewImmedaitely();
            _scorePresenter.UpdateViewImmedaitely();
            
            _gridPresenter.UpdateData();
            _gridPresenter.UpdateViewImmedaitely();
            
            _bonusPresenter.UpdateViewImmedaitely();

            ApplyBonusResult result = applyManualBonusStep.GetApplyBonusResult();

            if (!result.IsApplied)
                _invalidMoveInfoPresenter.SetInvalidMoveInfo(result.Info);
            else
                _invalidMoveInfoPresenter.SetInvalidMoveInfo(string.Empty);
            
            _invalidMoveInfoPresenter.UpdateViewImmedaitely();
        }

        public void Read(RemoveCombinationFromGridStep removeCombinationFromGridStep)
        {
            _gameInfoPresenter.UpdateViewImmedaitely();
            _scorePresenter.UpdateViewImmedaitely();
            
            _gridPresenter.ShowDeleteElements(removeCombinationFromGridStep.RemovedCoordinates());
            
            _bonusPresenter.UpdateViewImmedaitely();
            _invalidMoveInfoPresenter.UpdateViewImmedaitely();
            
            Thread.Sleep(1000);
        }
        
        public void Read(MoveDownElementsStep moveDownElementsStep)
        {
            _gameInfoPresenter.UpdateViewImmedaitely();
            _scorePresenter.UpdateViewImmedaitely();
            
            _gridPresenter.ShowMoveDownElements(moveDownElementsStep.GetMovedCoordinates());
            
            _bonusPresenter.UpdateViewImmedaitely();
            _invalidMoveInfoPresenter.UpdateViewImmedaitely();
            
            Thread.Sleep(1000);
        }
        
        public void Read(GenerateNewElementsStep generateNewElementsStep)
        {
            _gameInfoPresenter.UpdateViewImmedaitely();
            _scorePresenter.UpdateViewImmedaitely();
            
            _gridPresenter.ShowGeneratedElements(generateNewElementsStep.GetNewElements());
            
            _bonusPresenter.UpdateData();
            _bonusPresenter.UpdateViewImmedaitely();
            _invalidMoveInfoPresenter.UpdateViewImmedaitely();
            
            Thread.Sleep(1000);
        }
        
        public void Read(UpdateScoreStep updateScoreStep)
        {
            _gameInfoPresenter.UpdateViewImmedaitely();
            _scorePresenter.DrawChange(updateScoreStep.GetScoreChange());
            _gridPresenter.UpdateViewImmedaitely();
            _bonusPresenter.UpdateViewImmedaitely();
            _invalidMoveInfoPresenter.UpdateViewImmedaitely();
            
            Thread.Sleep(700);
            
            _scorePresenter.UpdateData();
        }

        public void Read(ApplyAutoBonusesStep applyAutoBonusesStep)
        {
            _gameInfoPresenter.UpdateViewImmedaitely();
            _scorePresenter.UpdateViewImmedaitely();

            IReadOnlyList<Coordinate> removedCoordinates = applyAutoBonusesStep.GetRemovedCoordinates();
            
            _gridPresenter.ShowDeleteElements(removedCoordinates);
            
            if (removedCoordinates.Count > 0)
                _bonusPresenter.ShowAutoBonusApplied();
            else 
                _bonusPresenter.UpdateViewImmedaitely();
                
            _invalidMoveInfoPresenter.UpdateViewImmedaitely();
            
            Thread.Sleep(1000);
        }

        public void Read(FindBonusesStep findBonusesStep)
        {
            _gameInfoPresenter.UpdateViewImmedaitely();
            _scorePresenter.UpdateViewImmedaitely();
            _gridPresenter.UpdateViewImmedaitely();
            _bonusPresenter.UpdateViewImmedaitely();
            _invalidMoveInfoPresenter.UpdateViewImmedaitely();
        }
    }
}