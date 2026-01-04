using System;

namespace Match3OOAP.ApplicationLayer
{
    public class GameRoot
    {
        public int INIT_OK_STATUS = 0;
        public int INIT_ERROR_STATUS = 1;
        public int INIT_ALREADY_INITIALIZED_STATUS = 2;
        
        public int SHUTDOWN_OK_STATUS = 0;
        public int SHUTDOWN_ERROR_STATUS = 1;
        public int SHUTDOWN_ALREADY_EXITED_STATUS = 2;

        #region Конструкторы

        public static GameRoot GetInstance() => throw new NotImplementedException();

        #endregion

        #region Команды

        // Предусловия: игра еще не запущена.
        // Постусловия: игра запущена успешно.
        public void Initiate() { }
        
        // Предусловия: игра запущена.
        // Постусловия: игра завершена.
        public void Shutdown() { }

        #endregion
        

        #region Запросы

        public bool IsRunning()
        {
            throw new NotImplementedException();
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
    }
}