using System;

namespace Match3OOAP.GameLogic.GameMove.StepCommands
{
    public abstract class Step
    {
        public abstract void Execute();

        public abstract void ReadResult(IStepReader readerVisitor);
    }
}