using Match3OOAP.GameLogic.GameGrid;

namespace Match3OOAP.GameLogic.Core
{
    public abstract class Combination
    {
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

        #endregion
        
        #region Команды

        // Предусловия: 
        // - сетка не null.
        // - координата не null.
        // Постусловие: если есть совпадения элементов, то комбинация найдена.
        public abstract void TryFind(IGrid grid, Coordinate fromCoordinate);
        
        // Постусловие: комбинация очищена - стала пустой.
        public abstract void Clear();

        #endregion
    }
}