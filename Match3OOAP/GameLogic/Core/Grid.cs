using System;

namespace Match3OOAP.GameLogic.Core
{
    public class Grid
    {
        #region Конструктор

        // Постусловие: создана сетка указанного размера.
        public Grid(uint size)
        {
            
        }

        #endregion
        
        
        #region Команды
        
        // Предусловие:
        // - Координаты указаны в диапазоне от 0 до размера сетки.
        // - Ячейка с указанными координатами пустая.
        //
        // Постусловие: добавлен элемент в указанную ячейку.
        public void AddElement(uint row, uint column) { }
        
        // Предусловие:
        // - Координаты указаны в диапазоне от 0 до размера сетки.
        // - Ячейка с указанными координатами не пустая.
        //
        // Постусловие: удален элемент из указанной ячейки.
        public void RemoveElement(uint row, uint column) { }
        
        // Предусловие:
        // - Координаты указаны в диапазоне от 0 до размера сетки.
        // - Ячейки с указанными координатами не пустые.
        //
        // Постусловие: элементы с указанными координатами поменяны местами.
        public void SwapElements(uint row1, uint column1, uint row2, uint column2) { }
        
        // Постусловие: все элементы сдвинуты на пустые ячейки вниз на 1 клетку.
        public void MoveDownAllOneCell() { }
        
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

