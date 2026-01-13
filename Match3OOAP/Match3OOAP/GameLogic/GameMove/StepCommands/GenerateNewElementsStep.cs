using System.Collections.Generic;
using Match3OOAP.GameLogic.Core;
using Match3OOAP.GameLogic.GameGrid;

namespace Match3OOAP.GameLogic.GameMove.StepCommands
{
    public class GenerateNewElementsStep : Step
    {
        public GenerateNewElementsStep(IGrid grid) { }
        
        public override void Execute()
        {
            throw new System.NotImplementedException();
        }

        public override void ReadResult(IStepReader readerVisitor)
        {
            readerVisitor.Read(this);
        }

        public IReadOnlyDictionary<Coordinate, Element> GetNewElements()
        {
            throw new System.NotImplementedException();
        }
    }
}