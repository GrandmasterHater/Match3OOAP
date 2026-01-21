using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Match3OOAP.GameLogic.Core;
using Match3OOAP.GameLogic.GameGrid;
using Match3OOAP.GameLogic.GameMove;
using Match3OOAP.Helpers;
using Match3OOAP.InputHandle;

namespace Match3OOAP.Gui.GameScreen
{
    public class GridPresenter : GuiPresenter<IGridView>, IGridPresenter
    {
        private const int HEADER_OFFSET = 1;
        private readonly string[] _columnNames = { " ", "a", "b", "c", "d", "e", "f", "g", "h"};
        private readonly IGrid _grid;
        private readonly IMove _move;
        
        private readonly string[,] _gridValues;
        private readonly Regex _swapCommandRegex;

        public GridPresenter(IGrid grid, IMove move, IGridView view) : base(view)
        {
            grid.AssertNotNull();
            move.AssertNotNull();
            
            _grid = grid;
            _move = move;
            
            Size size = _grid.GetSize();
            _gridValues = new string[size.Rows + HEADER_OFFSET, size.Columns + HEADER_OFFSET];
            _swapCommandRegex = new Regex("^([A-Ha-h])([1-8])\\s+([A-Ha-h])([1-8])$", RegexOptions.Compiled);
        }

        protected override void OnActivate()
        {
            SetHeaders(_grid);
            SetElements(_grid);
            View.SetGrid(_gridValues);
        }

        public void ShowSwap(Coordinate firstCoordinate, Coordinate secondCoordinate)
        {
            DateTime time = DateTime.Now + new TimeSpan(0, 0, 0, 0, 500);

            string elementSymbolFirst = _gridValues[firstCoordinate.Row, firstCoordinate.Column];
            string elementSymbolSecond = _gridValues[secondCoordinate.Row, secondCoordinate.Column];

            _gridValues[firstCoordinate.Row, firstCoordinate.Column] = elementSymbolSecond;
            _gridValues[secondCoordinate.Row, secondCoordinate.Column] = elementSymbolFirst;
            
            View.SetGrid(_gridValues);
            View.Redraw();
        }

        public void ShowDeleteElements(IReadOnlyList<Coordinate> coordinates)
        {
            foreach (Coordinate coordinate in coordinates)
            {
                _gridValues[coordinate.Row, coordinate.Column] = " ";
            }
            
            View.SetGrid(_gridValues);
            View.Redraw();
        }

        public void ShowMoveDownElements(IReadOnlyList<MoveDownElement> movedCoordinates)
        {
            foreach (MoveDownElement downElement in movedCoordinates)
            {
                _gridValues[downElement.From.Row, downElement.From.Column] = " ";
                _gridValues[downElement.To.Row, downElement.To.Column] = downElement.Element.Name;
            }
            
            View.SetGrid(_gridValues);
            View.Redraw();
        }

        public void ShowGeneratedElements(IReadOnlyList<FilledPlace> places)
        {
            foreach (FilledPlace place in places)
            {
                _gridValues[place.Coordinate.Row, place.Coordinate.Column] = place.Element.Name;
            }
            
            View.SetGrid(_gridValues);
            View.Redraw();
        }

        public override void UpdateData()
        {
            SetElements(_grid);
        }

        public override void UpdateViewImmedaitely()
        {
            View.SetGrid(_gridValues);
            View.Redraw();
        }
        
        public bool TryHandleInput(string inputText)
        {
            if (string.IsNullOrEmpty(inputText))
                return false;
            
            string commandText = inputText.Trim();

            if (!_swapCommandRegex.IsMatch(commandText))
            {
                return false;
            }

            string[] coordinatesTexts = commandText.Split(' ');

            Coordinate firstCoordinate = ParseCoordinate(coordinatesTexts[0]);
            Coordinate secondCoordinate = ParseCoordinate(coordinatesTexts[1]);
            
            _move.Swap(firstCoordinate, secondCoordinate);
            
            return true;
        }

        private Coordinate ParseCoordinate(string commandText)
        {
            int column = Array.IndexOf(_columnNames, commandText[0].ToString().ToLower());
            int row = int.Parse(commandText[1].ToString());

            return new Coordinate(_grid.GetSize(), row, column);
        }

        private void SetElements(IGrid grid)
        {
            Size size = grid.GetSize();
            
            for (int row = Coordinate.MIN_ROW; row <= size.Rows; row++)
            {
                for (int column = Coordinate.MIN_COLUMN; column <= size.Columns; column++)
                {
                    _gridValues[row, column] = grid.GetElement(new Coordinate(size, row, column))?.Name ?? " ";
                }
            }
        }

        private void SetHeaders(IGrid grid)
        {
            Size size = grid.GetSize();
            
            for (int column = 0; column < size.Columns + HEADER_OFFSET; column++)
            {
                _gridValues[0, column] = _columnNames[column];
            }

            for (int row = HEADER_OFFSET; row < size.Rows + 1; row++)
            {
                _gridValues[row, 0] = row.ToString();
            }
        }
    }
}