using System;
using Match3OOAP.GameLifeCycle.GameStateManagement;
using Match3OOAP.GameLifeCycle.GameStateManagement.GameStateFactory;
using Match3OOAP.InputHandle;

namespace Match3OOAP.GameLifeCycle
{
    public class GameRoot
    {
        public int INIT_OK_STATUS = 0;
        public int INIT_ERROR_STATUS = 1;
        public int INIT_ALREADY_INITIALIZED_STATUS = 2;
        
        public int SHUTDOWN_OK_STATUS = 0;
        public int SHUTDOWN_ERROR_STATUS = 1;
        public int SHUTDOWN_ALREADY_EXITED_STATUS = 2;

        private GameController _gameController;
        
        #region Команды

        // Предусловия: игра еще не запущена.
        // Постусловия: игра запущена успешно.
        public void Initiate()
        {
            _gameController = GetGameController();
        }
        
        // Предусловия: игра запущена.
        // Постусловия: игра завершена.
        public void Shutdown() { }

        #endregion
        

        #region Запросы

        public bool IsGameClosed()
        {
            return !_gameController.IsGameClosed();
        }

        #endregion
        
        #region Дополнительные запросы

        public int GetInitializationStatus()
        {
            throw new NotImplementedException();
            
        }

        public void GetShutdownStatus()
        {
            throw new NotImplementedException();
        }
        
        #endregion

        protected virtual GameStateFactory GetGameStateFactory() => new GameStateFactory();

        protected virtual GameController GetGameController() => new GameController(GetGameStateFactory());
        
    }
}