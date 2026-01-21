using System;
using Match3OOAP.GameLogic.BonusSystem;
using Match3OOAP.GameLogic.GameGrid;
using Match3OOAP.GameLogic.GameMove.Moves;
using Match3OOAP.GameLogic.GameMove.StepCommands;
using Match3OOAP.GameLogic.GameMove.UserCommands;
using Match3OOAP.GameLogic.Statistics;
using Match3OOAP.Helpers;

namespace Match3OOAP.GameLogic.GameMove
{
    public class MoveImpl : IMove
    {
        private readonly IMoveStrategyFactory _moveStrategyFactory;
        private readonly IMoveHistory _moveHistory;
        private readonly IStepFactory _stepFactory;
        
        private MoveResult? _lastMoveResult;
        private CheckNextMoveAvailableStep? _lastCheckResult;

        public event Action OnMoveCompletedEvent;

        public MoveImpl(IMoveStrategyFactory moveStrategyFactory, IMoveHistory moveHistory, IStepFactory stepFactory)
        {
            moveStrategyFactory.AssertNotNull();
            moveHistory.AssertNotNull();
            stepFactory.AssertNotNull();
            
            _moveStrategyFactory = moveStrategyFactory;
            _moveHistory = moveHistory;
            _stepFactory = stepFactory;
            _lastMoveResult = null;
            _lastCheckResult = null;
        }
        
        public void Swap(Coordinate firstCoordinate, Coordinate secondCoordinate)
        {
            MoveStrategy swapStrategy = _moveStrategyFactory.CreateSwapMove(firstCoordinate, secondCoordinate, _stepFactory); 
            
            ExecuteStrategy(swapStrategy);
        }

        public void ApplyBonus(BonusId bonusId)
        {
            bonusId.AssertNotNull();
            
            MoveStrategy swapStrategy = _moveStrategyFactory.CreateApplyBonusesMove(bonusId, _stepFactory);

            ExecuteStrategy(swapStrategy);
        }

        public MoveResult? GetLastMoveResult() => _lastMoveResult;

        public bool IsNextMoveAvailable()
        {
            if (_lastCheckResult == null)
            {
                CheckNextMoveAvailableStep nextMoveAvailableStep = CheckForNextMoveAvailable();
                return nextMoveAvailableStep.IsNextMoveAvailable;
            }

            return _lastCheckResult.IsNextMoveAvailable;
        }

        private void ExecuteStrategy(MoveStrategy moveStrategy)
        {
            moveStrategy.Execute(); 
            
            MoveResult moveResult = moveStrategy.GetMoveResult();

            CheckNextMoveAvailableStep nextMoveAvailableStep = CheckForNextMoveAvailable();
            
            moveResult.AddLast(nextMoveAvailableStep);
            
            _lastCheckResult = nextMoveAvailableStep;
            _lastMoveResult = moveResult;
            _moveHistory.Add(_lastMoveResult);
            
            OnMoveCompletedEvent?.Invoke();
        }

        private CheckNextMoveAvailableStep CheckForNextMoveAvailable()
        {
            CheckNextMoveAvailableStep nextMoveAvailableStep = _stepFactory.CreateCheckNextMoveAvailableStep();
            nextMoveAvailableStep.Execute();

            return nextMoveAvailableStep;
        }
    }
}