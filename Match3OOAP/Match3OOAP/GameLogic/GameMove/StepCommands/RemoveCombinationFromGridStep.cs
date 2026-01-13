using System.Collections;
using System.Collections.Generic;
using Match3OOAP.GameLogic.Core;
using Match3OOAP.GameLogic.GameGrid;

namespace Match3OOAP.GameLogic.GameMove.StepCommands
{
    public class RemoveCombinationFromGridStep : Step
    {
        public RemoveCombinationFromGridStep(Combination combination, IGrid grid)
        {
            
        }
        
        public override void Execute()
        {
            throw new System.NotImplementedException();
        }

        public override void ReadResult(IStepReader readerVisitor)
        {
            readerVisitor.Read(this);
        }

        public IEnumerable<Coordinate> RemovedCoordinates()
        {
            throw new System.NotImplementedException();
        }
    }
}