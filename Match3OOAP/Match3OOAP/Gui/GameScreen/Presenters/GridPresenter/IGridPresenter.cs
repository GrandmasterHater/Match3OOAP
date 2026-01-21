using System.Collections.Generic;
using Match3OOAP.GameLogic.Core;
using Match3OOAP.GameLogic.GameGrid;
using Match3OOAP.InputHandle;

namespace Match3OOAP.Gui.GameScreen
{
    public interface IGridPresenter : IPresentable
    {
        void ShowSwap(Coordinate firstCoordinate, Coordinate secondCoordinate);

        void ShowDeleteElements(IReadOnlyList<Coordinate> coordinates);
        
        void ShowMoveDownElements(IReadOnlyList<MoveDownElement> movedCoordinates);
        
        void ShowGeneratedElements(IReadOnlyList<FilledPlace> coordinates);

        bool TryHandleInput(string inputText);
    }
}