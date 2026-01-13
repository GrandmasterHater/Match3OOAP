using System.Collections.Generic;
using Match3OOAP.GameLogic.Core;
using Match3OOAP.InputHandle;

namespace Match3OOAP.Gui.GameScreen
{
    public class GridPresenter : GuiPresenter<GridView>, IGridPresenter
    {
        public GridPresenter(GridView view) : base(view)
        {
        }

        public void ShowSwap(Coordinate firstCoordinate, Coordinate secondCoordinate)
        {
            throw new System.NotImplementedException();
        }

        public void ShowDeleteElements(IEnumerable<Coordinate> coordinates)
        {
            throw new System.NotImplementedException();
        }

        public void ShowMoveDownElements(IReadOnlyDictionary<Coordinate, Coordinate> movedCoordinates)
        {
            throw new System.NotImplementedException();
        }

        public void ShowGeneratedElements(IEnumerable<Coordinate> coordinates)
        {
            throw new System.NotImplementedException();
        }

        public override void UpdateViewImmedaitely()
        {
            throw new System.NotImplementedException();
        }
    }
}