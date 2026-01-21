using System;

namespace Match3OOAP.InputHandle
{
    public interface IConsoleAsyncInputListener
    {
        event Action<string> OnUserInputReceived;
    }
}