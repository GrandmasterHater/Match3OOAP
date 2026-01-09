using System;
using Match3OOAP.InputHandle;

namespace Match3OOAP.GameLifeCycle.GameStateManagement
{
    public abstract class GameState
    {
        #region Запросы

        public abstract string Name { get; } 
        
        public bool IsSatateActive { get; }

        #endregion

        #region Команды

        public abstract void SetState();
        
        public abstract void ResetState();

        #endregion
    }
}