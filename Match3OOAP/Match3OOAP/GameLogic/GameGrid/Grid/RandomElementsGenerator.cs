using System;
using Match3OOAP.GameLogic.GameGrid;
using Match3OOAP.GameLogic.GameGrid.Elements;

namespace Match3OOAP.GameLogic.Core
{
    public class RandomElementsGenerator : IRandomElementsGenerator
    {
        private Element[] _elements;
        private readonly Random _random;
        private Element _lastGeneratedElement;

        public RandomElementsGenerator()
        {
            _elements = new Element[]
            {
                Element.Create<ElementA>(),
                Element.Create<ElementB>(),
                Element.Create<ElementC>(),
                Element.Create<ElementD>(),
                Element.Create<ElementE>(),
                Element.Create<ElementH>()
            };
            
            _random = new Random();
            _lastGeneratedElement = _elements[0];
        }
        
        public Element GetElement()
        {
            return GetRandomElement(); 
        }

        public Element[] GetElementsRange(uint count)
        {
            Element[] elements = new Element[count];
            
            for (int i = 0; i < count; i++)
                elements[i] = GetRandomElement();
            
            return elements;
        }

        private Element GetRandomElement()
        {
            Element element;

            do
            {
                int elementIndex = _random.Next(_elements.Length);
                element = _elements[elementIndex];
            } while (_lastGeneratedElement.Equals(element));
            
            _lastGeneratedElement = element;
            
            return element; 
        }
    }
}