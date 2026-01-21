using Match3OOAP.GameLogic.BonusSystem;
using Match3OOAP.GameLogic.Core;
using Match3OOAP.GameLogic.GameGrid;
using Match3OOAP.Helpers;

namespace Match3OOAP.GameLogic.GameMove.StepCommands
{
    public class CheckNextMoveAvailableStep : IStep
    {
        private readonly IGrid _grid;
        private readonly IBonusContainer<ManualApplicableBonus> _manualBonusContainer;
        
        public bool IsNextMoveAvailable { get; private set; }

        public CheckNextMoveAvailableStep(IGrid grid, IBonusContainer<ManualApplicableBonus> manualBonusContainer)
        {
            grid.AssertNotNull();
            manualBonusContainer.AssertNotNull();

            _grid = grid;
            _manualBonusContainer = manualBonusContainer;
        } 
        
        public void Execute()
        {
            IsNextMoveAvailable = false;
            
            Size gridSize = _grid.GetSize();

            if (_manualBonusContainer.Count > 0)
            {
                IsNextMoveAvailable = true;
                return;
            }
            
            for (int row = Coordinate.MIN_ROW; row < gridSize.Rows; row++)
            {
                for (int column = Coordinate.MIN_COLUMN; column < gridSize.Columns; column++)
                {
                    Coordinate coordinate = new Coordinate(gridSize, row, column);
                    Element element = _grid.GetElement(coordinate)!;

                    if (HasMoveVariant(coordinate, element))
                    {
                        IsNextMoveAvailable = true;
                        return;
                    }
                }
            }

            bool HasMoveVariant(Coordinate coordinate, Element element)
            {
                bool hasSameTop = coordinate.TryGetTop(out Coordinate topCoordinate) && _grid.GetElement(topCoordinate)!.Equals(element);
                bool hasSameBottom = coordinate.TryGetBottom(out Coordinate bottomCoordinate) && _grid.GetElement(bottomCoordinate)!.Equals(element);
                bool hasSameLeft = coordinate.TryGetLeft(out Coordinate leftCoordinate) && _grid.GetElement(leftCoordinate)!.Equals(element);
                bool hasSameRight = coordinate.TryGetRight(out Coordinate rightCoordinate) && _grid.GetElement(rightCoordinate)!.Equals(element);

                Coordinate variantCoordinate;
                
                bool hasTopMoveVariant = hasSameBottom 
                                         && topCoordinate.TryGetTop(out variantCoordinate)
                                         && !HasSameElementOnAdjacentCell(variantCoordinate, element, coordinate);
                bool hasBottomMoveVariant = hasSameTop 
                                            && bottomCoordinate.TryGetTop(out variantCoordinate)
                                            && !HasSameElementOnAdjacentCell(variantCoordinate, element, coordinate);
                bool hasLeftMoveVariant = hasSameRight 
                                          && leftCoordinate.TryGetTop(out variantCoordinate)
                                          && !HasSameElementOnAdjacentCell(variantCoordinate, element, coordinate);
                bool hasRightMoveVariant = hasSameLeft 
                                           && rightCoordinate.TryGetTop(out variantCoordinate)
                                           && !HasSameElementOnAdjacentCell(variantCoordinate, element, coordinate);
                
                return hasTopMoveVariant || hasBottomMoveVariant || hasLeftMoveVariant || hasRightMoveVariant;
            }

            bool HasSameElementOnAdjacentCell(Coordinate coordinate, Element element, Coordinate excludedCoordinate)
            {
                bool hasSameTop = coordinate.TryGetTop(out Coordinate topCoordinate) 
                                  && !topCoordinate.Equals(excludedCoordinate) 
                                  && _grid.GetElement(topCoordinate)!.Equals(element);
                bool hasSameBottom = coordinate.TryGetBottom(out Coordinate bottomCoordinate) 
                                     && !bottomCoordinate.Equals(excludedCoordinate) 
                                     && _grid.GetElement(bottomCoordinate)!.Equals(element);
                bool hasSameLeft = coordinate.TryGetLeft(out Coordinate leftCoordinate) 
                                   && !leftCoordinate.Equals(excludedCoordinate) 
                                   && _grid.GetElement(leftCoordinate)!.Equals(element);
                bool hasSameRight = coordinate.TryGetRight(out Coordinate rightCoordinate) 
                                    && !rightCoordinate.Equals(excludedCoordinate) 
                                    && _grid.GetElement(rightCoordinate)!.Equals(element);
                
                return hasSameTop || hasSameBottom || hasSameLeft || hasSameRight;
            }
        }

        public void ReadResult(IStepReader readerVisitor)
        {
            readerVisitor.Read(this);
        }
    }
}