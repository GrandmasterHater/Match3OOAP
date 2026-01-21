using System;
using System.Collections.Generic;
using System.Linq;
using Match3OOAP.GameLogic.Core;
using Match3OOAP.GameLogic.GameGrid;
using Match3OOAP.GameLogic.GameMove.Moves;
using Match3OOAP.GameLogic.GameMove.StepCommands;
using Match3OOAP.GameLogic.GameMove.UserCommands;
using Match3OOAP.Helpers;

namespace Match3OOAP.GameLogic.GameMove.Move
{
    public class SwapStrategy : MoveStrategy
    {
        private readonly IGrid _grid;
        private readonly Coordinate _firstCoordinate;
        private readonly Coordinate _secondCoordinate;

        public SwapStrategy(IGrid grid, Coordinate firstCoordinate, Coordinate secondCoordinate, IStepFactory stepFactory) : base(stepFactory)
        {
            grid.AssertNotNull();
            
            _grid = grid;
            _firstCoordinate = firstCoordinate;
            _secondCoordinate = secondCoordinate;
        }

        protected override MoveResult ExecuteMove(IStepFactory stepFactory)
        {
            MoveResult moveResult = new MoveResult();
            
            if (!IsSwapPossible(stepFactory, moveResult))
                return moveResult;

            FindCombinationsStep findCombinationsBySwapStep = FindCombinationsBySwap(stepFactory, moveResult);
            
            if (!findCombinationsBySwapStep.HasCombinations())
                return moveResult;

            if (!ApplySwap(stepFactory, moveResult))
                return moveResult;

            AddScoreForCombination(findCombinationsBySwapStep.GetCombinations(), stepFactory, moveResult);
            
            FindBonuses(findCombinationsBySwapStep.GetCombinations(), stepFactory, moveResult);
            
            ApplyAutoBonuses(stepFactory, moveResult);
            
            RemoveCombinationsFromGrid(findCombinationsBySwapStep.GetCombinations(), stepFactory, moveResult);

            MoveDownElements(stepFactory, moveResult);
            
            GenerationCycle(stepFactory, moveResult);
            
            return moveResult; 
        }

        private bool IsSwapPossible(
            IStepFactory stepFactory,
            MoveResult moveResult)
        {
            CheckSwapPossibleStep checkSwapPossibleStep = stepFactory.CreateCheckSwapPossibleStep(_firstCoordinate, _secondCoordinate);
            moveResult.AddLast(checkSwapPossibleStep);
            checkSwapPossibleStep.Execute();

            return checkSwapPossibleStep.IsSwapPossible;
        }
        
        private FindCombinationsStep FindCombinationsBySwap(IStepFactory stepFactory, MoveResult moveResult)
        {
            FindCombinationsStep findCombinationsStep = stepFactory.CreateFindCombinationsBySwapStep(_firstCoordinate, _secondCoordinate);
            moveResult.AddLast(findCombinationsStep);
            findCombinationsStep.Execute();
            
            return findCombinationsStep; 
        }
        
        private bool ApplySwap(IStepFactory stepFactory, MoveResult moveResult)
        {
            ApplySwapStep applySwapStep = stepFactory.CreateApplySwapStep(_firstCoordinate, _secondCoordinate);
            moveResult.AddLast(applySwapStep);
            applySwapStep.Execute();
            
            return applySwapStep.IsSuccess; 
        }
    }
}