using System;
using Match3OOAP.Helpers;
using Match3OOAP.InputHandle;

namespace Match3OOAP.GameLifeCycle.GameStateManagement
{
    public abstract class GameState
    {
        #region Запросы

        public abstract GameStatus GameStatus { get; } 
        
        public bool IsStateActive { get; private set; }

        #endregion

        #region Команды

        public StateChangeStatus SetState()
        {
            StateChangeStatus stateChangeStatus;
            
            try
            {
                OnSetState();
                stateChangeStatus = new StateChangeStatus(true);
            }
            catch (Exception e)
            {
                stateChangeStatus = new StateChangeStatus(e);
            }

            IsStateActive = stateChangeStatus.IsSuccess;
            
            return stateChangeStatus;
        }

        public StateChangeStatus ResetState()
        {
            StateChangeStatus stateChangeStatus;
            
            try
            {
                OnResetState();
                stateChangeStatus = new StateChangeStatus(true);
            }
            catch (Exception e)
            {
                stateChangeStatus = new StateChangeStatus(e);
            }

            IsStateActive = stateChangeStatus.IsSuccess ? false : true;

            return stateChangeStatus;
        }

        #endregion
        
        protected virtual void OnSetState() { }
        
        protected virtual void OnResetState() { }
        
        public struct StateChangeStatus
        {
            public bool IsSuccess { get; }
        
            public Exception? Exception { get; }

            public StateChangeStatus(bool status)
            {
                IsSuccess = status;
                Exception = null;
            }
            
            public StateChangeStatus(Exception exception)
            {
                IsSuccess = false;
                Exception = exception;
            }
        }
    }
}