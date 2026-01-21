using System.Collections.Generic;
using Match3OOAP.GameLogic.Core;
using Match3OOAP.GameLogic.GameGrid;
using Match3OOAP.GameLogic.GameMove.Move;
using Match3OOAP.GameLogic.GameMove.Moves;
using Match3OOAP.GameLogic.GameMove.StepCommands;
using Match3OOAP.Helpers;

namespace Match3OOAP.GameLogic.GameMove.UserCommands
{
    public abstract class MoveStrategy : Strategy
    {
        private readonly IStepFactory _stepFactory;
        private MoveResult _result;
        
        // Предусловие: фабрика шагов не null.
        protected MoveStrategy(IStepFactory stepFactory)
        {
            stepFactory.AssertNotNull();
            
            _stepFactory = stepFactory; 
        }

        protected sealed override void OnExecute()
        {
            _result = ExecuteMove(_stepFactory);
        }

        // Получить результат последнего выполнения стратегии хода.
        public MoveResult GetMoveResult() => _result;

        protected abstract MoveResult ExecuteMove(IStepFactory stepFactory);
        
        protected void AddScoreForCombination(IReadOnlyList<Combination> combinations, IStepFactory stepFactory, MoveResult moveResult)
        {
            UpdateScoreStep updateScoreStep = stepFactory.CreateUpdateScoreStep(combinations);
            moveResult.AddLast(updateScoreStep);
            updateScoreStep.Execute();
        }

        protected FindCombinationsStep FindCombinationsByCoordinates(IReadOnlyList<Coordinate> coordinates, IStepFactory stepFactory, MoveResult moveResult)
        {
            FindCombinationsStep findCombinationsStep = stepFactory.CreateFindCombinationsStepByCoordinates(coordinates);
            moveResult.AddLast(findCombinationsStep);
            findCombinationsStep.Execute();
            
            return findCombinationsStep; 
        }
        
        protected FindCombinationsStep FindCombinationsOnGrid(IStepFactory stepFactory, MoveResult moveResult)
        {
            FindCombinationsStep findCombinationsStep = stepFactory.CreateFindCombinationsOnGrid();
            moveResult.AddLast(findCombinationsStep);
            findCombinationsStep.Execute();
            
            return findCombinationsStep; 
        }

        protected void RemoveCombinationsFromGrid(IReadOnlyList<Combination> combinations, IStepFactory stepFactory, MoveResult moveResult)
        {
            RemoveCombinationFromGridStep removeCombinationFromGridStep = stepFactory.CreateRemoveCombinationFromGridStep(combinations);
            moveResult.AddLast(removeCombinationFromGridStep);
            removeCombinationFromGridStep.Execute();
        }
        
        protected void MoveDownElements(IStepFactory stepFactory, MoveResult moveResult)
        {
            MoveDownElementsStep moveDownElementsStep = stepFactory.CreateMoveDownElementsStep();
            moveResult.AddLast(moveDownElementsStep);
            moveDownElementsStep.Execute();
        }
        
        protected void GenerateNewElements(IStepFactory stepFactory, MoveResult moveResult)
        {
            GenerateNewElementsStep generateNewElementsStep = stepFactory.CreateGenerateNewElementsStep();
            moveResult.AddLast(generateNewElementsStep);
            generateNewElementsStep.Execute();
        }
        
        protected void FindBonuses(IReadOnlyList<Combination> combinations, IStepFactory stepFactory, MoveResult moveResult)
        {
            FindBonusesStep findBonusesStep = stepFactory.CreateFindBonusesStep(combinations);
            moveResult.AddLast(findBonusesStep);
            findBonusesStep.Execute();
        }
        
        protected void ApplyAutoBonuses(IStepFactory stepFactory, MoveResult moveResult)
        {
            ApplyAutoBonusesStep applyAutoBonusesStep = stepFactory.CreateApplyAutoBonusesStep();
            moveResult.AddLast(applyAutoBonusesStep);
            applyAutoBonusesStep.Execute();
        }
        
        protected void GenerationCycle(IStepFactory stepFactory, MoveResult moveResult)
        {
            for (bool hasCombinations = true; hasCombinations; )
            {
                GenerateNewElements(stepFactory, moveResult);
                FindCombinationsStep findCombinationsStep = FindCombinationsOnGrid(stepFactory, moveResult);

                hasCombinations = findCombinationsStep.HasCombinations();
                
                if (findCombinationsStep.HasCombinations())
                {
                    AddScoreForCombination(findCombinationsStep.GetCombinations(), stepFactory, moveResult);
                    
                    RemoveCombinationsFromGrid(findCombinationsStep.GetCombinations(), stepFactory, moveResult);

                    MoveDownElements(stepFactory, moveResult);
                }
            }
        }
    }
}