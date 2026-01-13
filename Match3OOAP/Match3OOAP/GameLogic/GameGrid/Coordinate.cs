namespace Match3OOAP.GameLogic.Core
{
    public struct Coordinate
    {
        public int Row { get; private set; }
        
        public int Column { get; private set; }
        
        public Coordinate(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}