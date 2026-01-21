using System;
using Match3OOAP.GameLogic.GameGrid;
using Match3OOAP.Helpers;
using Match3OOAP.InputHandle;

namespace Match3OOAP.Gui.GameScreen
{
    public class GridView : IGridView
    {
        public bool IsVisible { get; private set; }
        
        public string[,] GridValues { get; private set; }
        
        public void Show()
        {
            DrawGrid();
            IsVisible = true;
        }

        public void Hide()
        {
            IsVisible = false;
        }

        public void Redraw()
        {
            DrawGrid();
        }

        public void SetGrid(string[,] grid)
        {
            grid.AssertNotNull();
            
            GridValues = grid;
        }

        private void DrawGrid()
        {
            Console.Write("\n");
            
            for (int row = 0; row < GridValues.GetLength(0); row++)
            {
                for (int column = 0; column < GridValues.GetLength(1); column++)
                {
                    Console.Write(GridValues[row, column]);
                    Console.Write(" ");
                }
                Console.Write("\n");
            }
        }
    }
}