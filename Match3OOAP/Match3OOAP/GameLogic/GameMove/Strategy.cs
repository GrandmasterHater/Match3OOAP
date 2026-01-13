using System;

namespace Match3OOAP.GameLogic.GameMove.Move
{
    public abstract class Strategy
    {
        private Exception _exception;
        
        public void Execute()
        {
            _exception = null;
            
            try
            {
                OnExecute();
            }
            catch (Exception e)
            {
                _exception = e;
            }
        }
        
        public bool IsExecutionFailed() => _exception != null;
        
        public Exception GetException() => _exception;
        
        protected virtual void OnExecute() { }
    }
}