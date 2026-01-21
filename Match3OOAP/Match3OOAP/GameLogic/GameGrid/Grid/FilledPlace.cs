namespace Match3OOAP.GameLogic.GameGrid
{
    public struct FilledPlace
    {
        public Coordinate Coordinate { get; }
        
        public Element Element { get; }

        public FilledPlace(Coordinate coordinate, Element element)
        {
            Coordinate = coordinate;
            Element = element;
        }
    }
}