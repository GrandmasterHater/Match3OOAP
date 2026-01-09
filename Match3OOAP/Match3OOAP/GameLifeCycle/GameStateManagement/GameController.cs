using System;
using Match3OOAP.GameLifeCycle.GameStateManagement.GameStateFactory;
using Match3OOAP.GameLifeCycle.GameStateManagement.GameStates;

namespace Match3OOAP.GameLifeCycle.GameStateManagement
{
    public class GameController
    {
        private IGameStateFactory _gameStateFactory;
        private GameState _currentState;
        
        #region Конструкторы

        // Предусловие - gameStateFactory не null.
        // Постусловие - текущее состояние игры - не готова (NotReady).
        public GameController(IGameStateFactory gameStateFactory)
        {
            _gameStateFactory = gameStateFactory ?? throw new ArgumentNullException(nameof(gameStateFactory));
            _currentState = _gameStateFactory.GetState<ReadyState>();
            _currentState.SetState();
        }

        #endregion
        
        #region Команды 
        
        // Предусловия: текущее состояние игры - готова(ReadyToGame), запущена игра (StartedGame) или завершена (FinishedGame).
        // Постусловия: текущее состояние игры - запущена (StartedGame).
        public void StartGame() { }
        
        // Предусловия: текущее состояние игры - запущена (StartedGame).
        // Постусловия: текущее состояние игры - завершена (FinishedGame).
        public void FinishGame() { }
        
        // Предусловия: текущее состояние игры - завершена (FinishedGame).
        // Постусловия: текущее состояние игры - завершена (ClosedGame).
        public void CloseGame() { }
        
        #endregion

        #region Запросы
        
        public bool IsGameClosed()
        {
            throw new NotImplementedException();
        }
        
        #endregion 
        
    }
}