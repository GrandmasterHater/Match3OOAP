using System.Collections.Generic;
using Match3OOAP.GameLogic.Core;
using Match3OOAP.GameLogic.GameGrid;
using Match3OOAP.Helpers;

namespace Match3OOAP.GameLogic.GameMove.StepCommands
{
    public abstract class FindCombinationsStep : IStep
    {
        private readonly IGrid _grid;
        private List<Combination> _combinations;

        protected FindCombinationsStep(IGrid grid)
        {
            grid.AssertNotNull();

            _grid = grid;

            _combinations = new List<Combination>(1);
        }

        public void Execute()
        {
            _combinations = OnExecute(_grid);
        }

        protected abstract List<Combination> OnExecute(IGrid grid);

        public virtual void ReadResult(IStepReader readerVisitor)
        {
            readerVisitor.Read(this);
        }

        public bool HasCombinations() => _combinations.Count > 0;

        public IReadOnlyList<Combination> GetCombinations() => _combinations;

        protected Combination FindCombination(Coordinate coordinate, Element element)
        {
            Combination combination = Combination.Create<CombinationImpl>();
            
            combination.Find(_grid, coordinate, element);
            
            return combination;
        }
    }
}