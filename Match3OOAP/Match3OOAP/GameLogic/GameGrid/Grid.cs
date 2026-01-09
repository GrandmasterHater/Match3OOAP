using System;
using Match3OOAP.GameLogic.Core;

namespace Match3OOAP.GameLogic.GameGrid
{
    public class Grid
    {
        #region Конструктор

        // Постусловие: создана сетка указанного размера.
        public Grid(byte size)
        {
            
        }

        #endregion
        
        
        #region Команды
        
        // Предусловие:
        // - Координаты указаны в диапазоне от 0 до размера сетки.
        // - Ячейка с указанными координатами пустая.
        //
        // Постусловие: добавлен элемент в указанную ячейку.
        public void AddElement(Coordinate coordinate, Element element) { }
        
        // Предусловие:
        // - Координаты указаны в диапазоне от 0 до размера сетки.
        // - Ячейка с указанными координатами не пустая.
        //
        // Постусловие: удален элемент из указанной ячейки.
        public void RemoveElement(Coordinate coordinate) { }
        
        // Предусловие:
        // - Координаты указаны в диапазоне от 0 до размера сетки.
        // - Ячейки с указанными координатами не пустые.
        //
        // Постусловие: элементы с указанными координатами поменяны местами.
        public void SwapElements(Coordinate firstCoordinate, Coordinate secondCoordinate) { }
        
        #endregion


        #region Запросы
        
        // true - если ячейка пустая
        public bool IsCellEmpty()
        {
            throw new NotImplementedException();
        }

        // true - если в сетке есть пустые ячейки
        public bool HasEmptyCells()
        {
            throw new NotImplementedException();
        }
        
        // Предусловие: координаты указаны в диапазоне от 0 до размера сетки.
        public int GetCellElement(uint row, uint column) { throw new NotImplementedException(); }
        
        #endregion
    }
}

