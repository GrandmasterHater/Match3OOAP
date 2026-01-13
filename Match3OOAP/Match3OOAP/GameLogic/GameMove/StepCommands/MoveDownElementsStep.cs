using System.Collections.Generic;
using Match3OOAP.GameLogic.Core;
using Match3OOAP.GameLogic.GameGrid;

namespace Match3OOAP.GameLogic.GameMove.StepCommands
{
    public class MoveDownElementsStep : Step
    {
        public MoveDownElementsStep(IGrid grid) { }
        
        public override void Execute()
        {
            throw new System.NotImplementedException();
        }

        public override void ReadResult(IStepReader readerVisitor)
        {
            readerVisitor.Read(this);
        }
        
        public IReadOnlyDictionary<Coordinate, Coordinate> GetMovedCoordinates()
        {
            throw new System.NotImplementedException();
        }
    }
}