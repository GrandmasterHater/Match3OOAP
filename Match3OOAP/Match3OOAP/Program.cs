using System;
using Match3OOAP.GameLifeCycle;

namespace Match3OOAP
{ 
    class Program
    {
        static void Main(string[] args)
        {
            GameRoot root = new GameRoot();
            
            root.Initiate();

            GameRoot.InitStatus initStatus = root.GetInitializationStatus();

            if (initStatus != GameRoot.InitStatus.Ok)
            {
                Console.WriteLine($"Game not started. Initialization failed. Status: {initStatus}");
                return;
            }

            while (!root.IsGameClosed()) { }
        }
    }
}