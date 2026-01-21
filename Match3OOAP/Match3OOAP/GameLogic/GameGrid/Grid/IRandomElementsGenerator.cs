using Match3OOAP.GameLogic.GameGrid;

namespace Match3OOAP.GameLogic.Core
{
    public interface IRandomElementsGenerator
    {
        Element GetElement();

        Element[] GetElementsRange(uint count);
    }
}