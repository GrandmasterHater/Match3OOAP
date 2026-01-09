using System;

namespace Match3OOAP.InputHandle
{
    /// <summary>
    /// Класс, реализующий асинхронный обработчик ввода.
    /// </summary>
    public class AsyncInputListener
    {
        public static AsyncInputListener GetInstance()
        {
            throw new System.NotImplementedException();
        }

        public event Action<string> OnUserInputReceived;
    }
}