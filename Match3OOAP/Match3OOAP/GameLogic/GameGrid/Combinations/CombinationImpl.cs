using System.Collections.Generic;
using System.Linq;
using Match3OOAP.GameLogic.GameGrid;
using Match3OOAP.Helpers;

namespace Match3OOAP.GameLogic.Core
{
    public class CombinationImpl : Combination
    {
        public enum Shape
        {
            None,
            RowLine,
            ColumnLine,
            Cross,
            Angle,
            Tshape
        }
        
        private Element _element;
        private List<Coordinate> _elements;
        private Shape _shape;

        public CombinationImpl()
        {
            _elements = new List<Coordinate>(MIN_ELEMENTS_COUNT_IN_LINE);
        }

        public override void Find(IGrid grid, Coordinate coordinate, Element element)
        {
            grid.AssertNotNull();
            element.AssertNotNull();

            _element = element;
            _elements.Clear();
            _shape = Shape.None;

            // Выполнить поиск совпадающих элементов по строке от текущего элемента
            List<Coordinate> rowCombination = GetRowCombination(grid, coordinate, element);
            // Выполнить поиск совпадающих элементов по столбцу от текущего элемента
            List<Coordinate> columnCombination = GetColumnCombination(grid, coordinate, element);
            
            bool hasRowCombination = HasCombination(rowCombination);
            bool hasColumnCombination = HasCombination(columnCombination);
            
            if (!hasRowCombination && !hasColumnCombination)
                return;
            
            // Если есть комбинация в строке - добавляем комбинацию в результирующий список.
            if (hasRowCombination)
                _elements.AddRange(rowCombination);
            // Если есть комбинация в столбце - добавляем комбинацию в результирующий список.
            if (hasColumnCombination)
                _elements = _elements.Union(columnCombination, LineCoordinateComparer.Instance).ToList();
            
            // Определяем форму комбинации.
            _shape = GetShape(coordinate, rowCombination, columnCombination);
        }
        
        public override IReadOnlyList<Coordinate> GetCoordinates() => _elements;

        public override bool IsValid() => HasCombination(_elements);

        public override int ElementsCount() => _elements.Count;

        public override Element GetElementType() => _element;
        
        public override Shape GetShape() => _shape;
        
        private bool HasCombination(List<Coordinate> combination) => 
            combination.Count >= MIN_ELEMENTS_COUNT_IN_LINE;
        
        private List<Coordinate> GetRowCombination(IGrid grid, Coordinate coordinate, Element element)
        {
            List<Coordinate> rowCombination = new List<Coordinate>(MIN_ELEMENTS_COUNT_IN_LINE);
            rowCombination.Add(coordinate);
            
            coordinate.TryGetRight(out Coordinate startCoordinate);
            
            for (Coordinate currentCoordinate = startCoordinate, previousCoordinate = coordinate;
                 !previousCoordinate.IsRightBorder(); 
                 previousCoordinate = currentCoordinate, previousCoordinate.TryGetRight(out currentCoordinate))
            {
                Element? currentElement = grid.GetElement(currentCoordinate);
                
                if (currentElement != null && currentElement.Equals(element))
                    rowCombination.Add(currentCoordinate);
                else
                    break;
            }
            
            coordinate.TryGetLeft(out startCoordinate);

            for (Coordinate currentCoordinate = startCoordinate, previousCoordinate = coordinate;
                 !previousCoordinate.IsLeftBorder(); 
                 previousCoordinate = currentCoordinate, previousCoordinate.TryGetLeft(out currentCoordinate))
            {
                Element? currentElement = grid.GetElement(currentCoordinate);
                
                if (currentElement != null && currentElement.Equals(element))
                    rowCombination.Add(currentCoordinate);
                else
                    break;
            }
            
            return rowCombination;
        }
        
        private List<Coordinate> GetColumnCombination(IGrid grid, Coordinate coordinate, Element element)
        {
            List<Coordinate> columnCombination = new List<Coordinate>(MIN_ELEMENTS_COUNT_IN_LINE);
            columnCombination.Add(coordinate);
            
            coordinate.TryGetTop(out Coordinate startCoordinate);
            
            for (Coordinate currentCoordinate = startCoordinate, previousCoordinate = coordinate;
                 !previousCoordinate.IsTopBorder(); 
                 previousCoordinate = currentCoordinate, previousCoordinate.TryGetTop(out currentCoordinate))
            {
                Element? currentElement = grid.GetElement(currentCoordinate);
                    
                if (currentElement != null && currentElement.Equals(element))
                    columnCombination.Add(currentCoordinate);
                else
                    break;
            }
            
            coordinate.TryGetBottom(out startCoordinate);
            
            for (Coordinate currentCoordinate = startCoordinate, previousCoordinate = coordinate;
                 !previousCoordinate.IsBottomBorder(); 
                 previousCoordinate = currentCoordinate, previousCoordinate.TryGetBottom(out currentCoordinate))
            {
                Element? currentElement = grid.GetElement(currentCoordinate);
                
                if (currentElement != null && currentElement.Equals(element))
                    columnCombination.Add(currentCoordinate);
                else
                    break;
            }
            
            return columnCombination;
        }
        
        private Shape GetShape(Coordinate coordinate, List<Coordinate> rowCombination, List<Coordinate> columnCombination)
        {
            if (HasLineCombination(out Shape shape))
                return shape;
            
            return GetIntersectionShape();
            
            
            bool HasLineCombination(out Shape shape)
            {
                shape = default;
                bool hasRowCombination = HasCombination(rowCombination);
                bool hasColumnCombination = HasCombination(columnCombination);
                
                bool hasLineCombination = hasRowCombination ^ hasColumnCombination;

                if (hasLineCombination && hasRowCombination)
                    shape = Shape.RowLine;
                
                if (hasLineCombination && hasColumnCombination) 
                    shape = Shape.ColumnLine;
                
                return hasLineCombination;
            }
            
            Shape GetIntersectionShape()
            {
                rowCombination.Sort(SortByRow);
                columnCombination.Sort(SortByColumn);
                
                int rowCoordinateIndex = rowCombination.IndexOf(coordinate);
                int columnCoordinateIndex = columnCombination.IndexOf(coordinate);

                bool isRowIndexMiddle = rowCoordinateIndex > 0 && rowCoordinateIndex < rowCombination.Count - 1;
                bool isColumnIndexMiddle = columnCoordinateIndex > 0 && columnCoordinateIndex < columnCombination.Count - 1;
                
                bool isCrossShape = isRowIndexMiddle && isColumnIndexMiddle;
                
                if (isCrossShape)
                    return Shape.Cross;

                bool isAngleShape = isRowIndexMiddle ^ isColumnIndexMiddle;
                
                if (isCrossShape)
                    return Shape.Angle;
                
                return Shape.Tshape;
            }

            int SortByRow(Coordinate first, Coordinate second)
            {
                int result = 0;
                
                if (first.Row < second.Row)
                    result = -1;
                
                if (first.Row > second.Row)
                    result = 1;
                
                return result;
            }
            
            int SortByColumn(Coordinate first, Coordinate second)
            {
                int result = 0;
                
                if (first.Column < second.Column)
                    result = -1;
                
                if (first.Column > second.Column)
                    result = 1;
                
                return result;
            }
        }
        
        private class LineCoordinateComparer : IEqualityComparer<Coordinate>
        {
            public static LineCoordinateComparer Instance = new LineCoordinateComparer();
            
            public bool Equals(Coordinate x, Coordinate y) => x.Equals(y);

            public int GetHashCode(Coordinate obj) => obj.GetHashCode();
            
        }
    }
}