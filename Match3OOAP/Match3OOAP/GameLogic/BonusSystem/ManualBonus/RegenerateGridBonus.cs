using Match3OOAP.GameLogic.Core;
using Match3OOAP.GameLogic.GameGrid;
using Match3OOAP.Helpers;

namespace Match3OOAP.GameLogic.BonusSystem.ManualBonus
{
    public class RegenerateGridBonus : ManualApplicableBonus
    {
        private const double MIN_ELEMENTS_COUNT_IN_LINE = 4;
        private readonly BonusId _bonusId;
        
        public RegenerateGridBonus()
        {
            _bonusId = new RegenerateBonusId();
        }
        
        public override bool IsBonusAvailable()
        {
            if (CurrentCombination == null)
                return false;
            
            CombinationImpl.Shape combinationShape = CurrentCombination.GetShape();

            return CurrentCombination.ElementsCount() >= MIN_ELEMENTS_COUNT_IN_LINE 
                   && (combinationShape == CombinationImpl.Shape.RowLine ||
                       combinationShape == CombinationImpl.Shape.ColumnLine);
        }

        public override void Apply(IGrid grid)
        {
            if (!IsBonusAvailable())
            {
                return;
            }

            Size size = grid.GetSize();
            
            for (int row = Coordinate.MIN_ROW; row <= size.Rows; row++)
            {
                for (int column = Coordinate.MIN_COLUMN; column <= size.Columns; column++)
                {
                    grid.RemoveElement(new Coordinate(size, row, column));
                }
            }

            grid.FillEmptyPlaces();
        }
        public override BonusId GetId() => _bonusId;
    }
}