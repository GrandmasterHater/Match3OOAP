using Match3OOAP.GameLogic.Core;

namespace Match3OOAP.GameLogic.GameGrid
{
    public interface IGrid
    {
        #region Конструктор
        
        // Постусловие:
        // - создана сетка указанного размера.
        // - сетка заполнена случайными элементами.
        // - на поле нет комбинаций.

        #endregion
        
        
        #region Команды
        
        // Постусловие: в колонках где под элементами есть пустые ячейки, элементы перемещены вниз. 
        void MoveDownElements();
        
        // Постусловие: элемент удалён по указанным координатам.
        void RemoveElement(Coordinate coordinate);
        
        // Предусловие: в сетке есть пустые места.
        // Постусловие: пустые ячейки заполнены случайными элементами.
        void FillWithElements();
        
        // Предусловие:
        // - в указанных координатах есть элементы.
        // - элементы расположены рядом друг с другом.
        // Постусловие: элементы с указанными координатами поменяны местами.
        void SwapElements(Coordinate firstCoordinate, Coordinate secondCoordinate);
        
        #endregion
        
        
        #region Запросы
        
        bool IsCellEmpty(Coordinate coordinate);
        
        bool HasEmptyCells();
        
        int GetElement(Coordinate coordinate);
        
        bool IsSwapPossible(Coordinate firstCoordinate, Coordinate secondCoordinate);
        
        #endregion
    }
}