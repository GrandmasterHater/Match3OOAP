using System;
using System.Collections.Generic;
using Match3OOAP.GameLogic.Core;
using Match3OOAP.GameLogic.GameGrid.Elements;
using Match3OOAP.Helpers;

namespace Match3OOAP.GameLogic.GameGrid
{
    public class GridImpl : IGrid
    {
        private readonly Element[,] _elements;
        private readonly IRandomElementsGenerator _randomElementsGenerator;
        private readonly Size _size;

        public GridImpl(Size size, IRandomElementsGenerator randomElementsGenerator)
        {
            randomElementsGenerator.AssertNotNull();
            
            _randomElementsGenerator = randomElementsGenerator;
            _size = size;
            
            _elements = new Element[size.Rows, size.Columns];
            
            FillGridWithElements();
        }

        public IReadOnlyList<MoveDownElement> MoveDownElements()
        {
            List<MoveDownElement> result = new List<MoveDownElement>();

            // Для каждого столбца идём снизу вверх.
            for (int column = 0; column < _size.Columns; ++column)
            {
                for (int row = _size.Rows - 1; row >= 0; --row)
                {
                    // Если найдена пустая ячейка, то идём вверх до ближайшей не пустой ячейки.
                    bool isCellEmpty = IsCellEmpty(row, column);
                    int nextRow = default;
                    bool hasNextRowWithElement = isCellEmpty && HasNextRowWithElement(row, column, out nextRow);
                    
                    // Если ячейка найдена, то перемещаем элемент на пустую и возобновляем проверку столбца дальше до следующей пустой ячейки.
                    if (isCellEmpty && hasNextRowWithElement)
                    {
                        Element element = _elements[nextRow, column];
                        
                        _elements[nextRow, column] = null;
                        _elements[row, column] = element;
                        
                        Coordinate from = Coordinate.CreateFromArray(_size, nextRow, column);
                        Coordinate to = Coordinate.CreateFromArray(_size, row, column);
                        MoveDownElement moveDownElement = new MoveDownElement(from, to, element);
                        
                        result.Add(moveDownElement);
                    }
                }
            }

            return result;
            
            
            bool HasNextRowWithElement(int currentRow, int column, out int nextRow)
            {
                nextRow = -1;
                
                for (int row = currentRow; row >= 0; --row)
                {
                    if (!IsCellEmpty(row, column))
                    {
                        nextRow = row;
                        return true;
                    }
                }

                return false;
            }
                
        }

        public void RemoveElement(Coordinate coordinate)
        {
            _elements[coordinate.ToArrayRowIndex(), coordinate.ToArrayColumnIndex()] = null;
        }

        public IReadOnlyList<FilledPlace> FillEmptyPlaces() => FillGridWithElements();

        public void SwapElements(Coordinate firstCoordinate, Coordinate secondCoordinate)
        {
            SwapAvailabilityResult swapAvailabilityResult = IsSwapPossible(firstCoordinate, secondCoordinate);
            
            if (swapAvailabilityResult.IsSwapPossible)
            {
                Element firstElement = _elements[firstCoordinate.ToArrayRowIndex(), firstCoordinate.ToArrayColumnIndex()];
                Element secondElement = _elements[secondCoordinate.ToArrayRowIndex(), secondCoordinate.ToArrayColumnIndex()];
                
                _elements[firstCoordinate.ToArrayRowIndex(), firstCoordinate.ToArrayColumnIndex()] = secondElement;
                _elements[secondCoordinate.ToArrayRowIndex(), secondCoordinate.ToArrayColumnIndex()] = firstElement;
            }
        }

        public bool IsCellEmpty(Coordinate coordinate)
        {
            return IsCellEmpty(coordinate.ToArrayRowIndex(), coordinate.ToArrayColumnIndex());
        }

        public bool HasEmptyCells()
        {
            for (int row = 0; row < _size.Rows; row++)
            {
                for (int column = 0; column < _size.Columns; column++)
                {
                    if (IsCellEmpty(row, column))
                        return true;
                }
            }

            return false;
        }

        public IReadOnlyList<Coordinate> GetEmptyCells()
        {
            List<Coordinate> result = new List<Coordinate>();
            
            for (int row = 0; row < _size.Rows; row++)
            {
                for (int column = 0; column < _size.Columns; column++)
                {
                    if (IsCellEmpty(row, column))
                        result.Add(Coordinate.CreateFromArray(_size, row, column));
                }
            }

            return result;
        }

        public Element? GetElement(Coordinate coordinate)
        {
            AssertCoordinatesForSize(coordinate);
            
            return _elements[coordinate.ToArrayRowIndex(), coordinate.ToArrayColumnIndex()];
        }

        public Size GetSize() => _size;

        public SwapAvailabilityResult IsSwapPossible(Coordinate firstCoordinate, Coordinate secondCoordinate)
        {
            bool areCoordinatesForGridSize;
            
            try
            {
                AssertCoordinatesForSize(firstCoordinate);
                AssertCoordinatesForSize(secondCoordinate);
                areCoordinatesForGridSize = true;
            }
            catch
            {
                areCoordinatesForGridSize = false;
            }
            
            if (!areCoordinatesForGridSize)
                return new SwapAvailabilityResult(false, "Coordinates are outside the grid."); 
            
            if (firstCoordinate.Equals(secondCoordinate))
                return new SwapAvailabilityResult(false, "Coordinates are the same.");
            
            if (IsCellEmpty(firstCoordinate) || IsCellEmpty(secondCoordinate))
                return new SwapAvailabilityResult(false, "At least one of the coordinates is empty.");

            bool areCoordinatesAdjacent = Math.Abs(firstCoordinate.Row - secondCoordinate.Row) <= 1 &&
                                          Math.Abs(firstCoordinate.Column - secondCoordinate.Column) <= 1;
            
            string info = areCoordinatesAdjacent ? "Swap is possible." : "The coordinates must be adjacent.";

            return new SwapAvailabilityResult(areCoordinatesAdjacent, info);

        }
        
        private void AssertCoordinatesForSize(Coordinate coordinate)
        {
            if (!coordinate.IsCoordinateForSize(_size))
                throw new ArgumentOutOfRangeException($"Incompatible coordinates. Coordinate:{coordinate}, but expected size {_size}.");
        }
        
        private bool IsCellEmpty(int row, int column) => _elements[row, column] is null;

        private List<FilledPlace> FillGridWithElements()
        {
            List<FilledPlace> filledPlaces = new List<FilledPlace>();
            
            for (int row = _size.Rows - 1; row >= 0; row--)
            {
                for (int column = 0; column < _size.Columns; column++)
                {
                    if (IsCellEmpty(row, column))
                    {
                        Element element = _randomElementsGenerator.GetElement();
                        _elements[row, column] = element;
                        FilledPlace filledPlace = new FilledPlace(Coordinate.CreateFromArray(_size, row, column), element);
                        filledPlaces.Add(filledPlace);
                    }
                }
            }

            return filledPlaces;
        }
    }
}

