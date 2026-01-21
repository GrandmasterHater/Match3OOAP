using System;
using System.Threading;
using Match3OOAP.GameLifeCycle.GameStateManagement;
using Match3OOAP.GameLifeCycle.GameStateManagement.GameStateFactory;
using Match3OOAP.GameLogic.Statistics;
using Match3OOAP.InputHandle;

namespace Match3OOAP.GameLifeCycle
{
    public class GameRoot
    {
        public enum InitStatus
        {
            NotInitialized = 0,
            Ok = 1,
            Error = 2,
            AlreadyInitialized = 3
        }

        private GameController _gameController;
        private InitStatus _initStatus;

        #region Конструктор

        public GameRoot()
        {
            _initStatus = InitStatus.NotInitialized;
        } 

        #endregion
        
        #region Команды

        // Предусловия: игра еще не запущена.
        // Постусловия: игра запущена успешно.
        public void Initiate()
        {
            _gameController = GetGameController();
            _initStatus = InitStatus.Ok;
        }

        #endregion
        

        #region Запросы

        public bool IsGameClosed()
        {
            return _gameController.IsGameClosed();
        }

        #endregion
        
        
        #region Дополнительные запросы

        public InitStatus GetInitializationStatus() => _initStatus;
        
        #endregion

        protected virtual GameController GetGameController()
        {
            IScore score = new ScoreImpl();
            IMoveHistory moveHistory = new MoveHistoryImpl();

            GameStateFactory factory = new GameStateFactory(score, moveHistory);
            
            return new GameController(factory);
        }
        
    }
}