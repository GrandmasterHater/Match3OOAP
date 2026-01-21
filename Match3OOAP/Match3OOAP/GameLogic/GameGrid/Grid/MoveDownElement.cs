namespace Match3OOAP.GameLogic.GameGrid
{
    public struct MoveDownElement
    {
        public Coordinate From { get; }
        public Coordinate To { get; }
        public Element Element { get; }
        
        public MoveDownElement(Coordinate from, Coordinate to, Element element)
        {
            From = from;
            To = to;
            Element = element;
        }
    }
}