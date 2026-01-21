using System;
using System.Collections.Generic;
using System.Linq;
using Match3OOAP.GameLogic.Core;
using Match3OOAP.GameLogic.GameGrid;
using Match3OOAP.Helpers;

namespace Match3OOAP.GameLogic.BonusSystem.AutoBonus
{
    public class RemoveLineBonus : AutoApplicableBonus
    {
        private const double MIN_ELEMENTS_COUNT_IN_LINE = 4;

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
            
            CombinationImpl.Shape combinationShape = CurrentCombination!.GetShape();

            List<Coordinate> removedCoordinates = combinationShape == CombinationImpl.Shape.RowLine
                ? GetRowCoordinates(grid, CurrentCombination)
                : GetColumnCoordinates(grid, CurrentCombination);

            foreach (Coordinate coordinate in removedCoordinates)
            {
                grid.RemoveElement(coordinate);
            }
        }

        private List<Coordinate> GetRowCoordinates(IGrid grid, Combination combination)
        {
            List<Coordinate> removedCoordinates = new List<Coordinate>();
            
            Coordinate startCoordinate = combination.GetCoordinates().First();

            for (Coordinate coordinate = new Coordinate(grid.GetSize(), startCoordinate.Row, Coordinate.MIN_COLUMN), previousCoordinate = coordinate;
                 !previousCoordinate.IsRightBorder();
                 previousCoordinate = coordinate, coordinate.TryGetRight(out Coordinate nextCoordinate), coordinate = nextCoordinate)
            {
                removedCoordinates.Add(coordinate);
            }
            
            return removedCoordinates;
        }
        
        private List<Coordinate> GetColumnCoordinates(IGrid grid, Combination combination)
        {
            List<Coordinate> removedCoordinates = new List<Coordinate>();
            
            Coordinate startCoordinate = combination.GetCoordinates().First();

            for (Coordinate coordinate = new Coordinate(grid.GetSize(), Coordinate.MIN_COLUMN, startCoordinate.Column), previousCoordinate = coordinate;
                 !previousCoordinate.IsBottomBorder();
                 previousCoordinate = coordinate, coordinate.TryGetBottom(out Coordinate nextCoordinate), coordinate = nextCoordinate)
            {
                removedCoordinates.Add(coordinate);
            }
            
            return removedCoordinates;
        }
    }
}