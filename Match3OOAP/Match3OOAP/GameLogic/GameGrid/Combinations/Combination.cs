using System.Collections.Generic;
using Match3OOAP.GameLogic.GameGrid;

namespace Match3OOAP.GameLogic.Core
{
    public abstract class Combination
    {
        public const int MIN_ELEMENTS_COUNT_IN_LINE = 3;
        
        #region Конструктор

        // Постусловие: создана пустая комбинация.
        public static Combination Create<TCombination>() where TCombination : Combination, new() => new TCombination();

        #endregion
        
        #region Запросы

        // Комбинация валидна если есть минимум 3 элемента в ряд.
        public abstract bool IsValid();
        
        // Количество элементов в комбинации.
        public abstract int ElementsCount();
        
        // Для какого типа элемента комбинация.
        public abstract Element GetElementType();

        public abstract IReadOnlyList<Coordinate> GetCoordinates();
        
        public abstract CombinationImpl.Shape GetShape();

        #endregion
        
        #region Команды

        // Предусловия: 
        // - сетка не null.
        // - координата не null.
        // Постусловие: если есть совпадения элементов, то комбинация найдена.
        public abstract void Find(IGrid grid, Coordinate coordinate, Element element);

        #endregion
    }
}