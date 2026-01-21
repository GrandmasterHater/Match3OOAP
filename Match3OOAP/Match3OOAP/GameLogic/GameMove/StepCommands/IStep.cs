using System;

namespace Match3OOAP.GameLogic.GameMove.StepCommands
{
    public interface IStep
    {
        // Команды выполнения шага.
        void Execute();

        // Запрос получения результата шага.
        void ReadResult(IStepReader readerVisitor);
    }
}