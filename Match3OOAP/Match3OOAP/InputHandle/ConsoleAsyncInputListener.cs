using System;
using System.Threading;
using System.Threading.Tasks;

namespace Match3OOAP.InputHandle
{
    public class ConsoleAsyncInputListener : IConsoleAsyncInputListener
    {
        private CancellationTokenSource _cts;
        private static IConsoleAsyncInputListener? _consoleAsyncInputListener;

        public static IConsoleAsyncInputListener Instance
        {
            get
            {
                if (_consoleAsyncInputListener is null)
                    _consoleAsyncInputListener = new ConsoleAsyncInputListener();
                
                return _consoleAsyncInputListener; 
            }
        }

        public ConsoleAsyncInputListener()
        {
            SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());

            StartListening();
        }
        
        public event Action<string> OnUserInputReceived;

        private void StartListening()
        {
            SynchronizationContext context = SynchronizationContext.Current;
            
            Task.Run(async () =>
            {
                while (true)
                {
                    string inputText = await Console.In.ReadLineAsync();

                    if (inputText != null)
                        context.Post(_ => OnUserInputReceived?.Invoke(inputText), null);
                }
            });
        }
    }
}