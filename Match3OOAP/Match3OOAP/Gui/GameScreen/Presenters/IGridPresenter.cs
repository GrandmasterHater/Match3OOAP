using System.Collections.Generic;
using Match3OOAP.GameLogic.Core;
using Match3OOAP.InputHandle;

namespace Match3OOAP.Gui.GameScreen
{
    public interface IGridPresenter : IPresentable
    {
        void ShowSwap(Coordinate firstCoordinate, Coordinate secondCoordinate);

        void ShowDeleteElements(IEnumerable<Coordinate> coordinates);
        
        void ShowMoveDownElements(IReadOnlyDictionary<Coordinate, Coordinate> movedCoordinates);
        
        void ShowGeneratedElements(IEnumerable<Coordinate> coordinates);
    }
}