using System;
using Match3OOAP.GameLifeCycle.GameStateManagement.GameStateFactory;

namespace Match3OOAP.GameLifeCycle.GameStateManagement
{
    public class GameController
    {
        private readonly IGameStateFactory _gameStateFactory;
        private GameState _currentState;
        
        #region Конструкторы

        // Предусловие - gameStateFactory не null.
        // Постусловие - текущее состояние игры - готова (Ready).
        public GameController(IGameStateFactory gameStateFactory)
        {
            _gameStateFactory = gameStateFactory ?? throw new ArgumentNullException(nameof(gameStateFactory));
            SwitchState(null, _gameStateFactory.GetReadyState(this));
        }

        #endregion
        
        #region Команды 
        
        // Предусловия: текущее состояние игры - готова(ReadyToGame), запущена игра (StartedGame) или завершена (FinishedGame).
        // Постусловия: текущее состояние игры - запущена (StartedGame).
        public void StartGame()
        {
            bool canSwitchState = _currentState.GameStatus == GameStatus.ReadyToGame
                                  || _currentState.GameStatus == GameStatus.FinishedGame
                                  || _currentState.GameStatus == GameStatus.StartedGame;
            
            if (canSwitchState)
                SwitchState(_currentState, _gameStateFactory.GetRunState(this));
        }
        
        // Предусловия: текущее состояние игры - запущена (StartedGame).
        // Постусловия: текущее состояние игры - завершена (FinishedGame).
        public void FinishGame()
        {
            if (_currentState.GameStatus == GameStatus.StartedGame) 
                SwitchState(_currentState, _gameStateFactory.GetFinishedState(this));
        }
        
        // Предусловия: текущее состояние игры - завершена (FinishedGame) или готова (ReadyToGame).
        // Постусловия: текущее состояние игры - завершена (ClosedGame).
        public void CloseGame()
        {
            if (_currentState.GameStatus == GameStatus.FinishedGame || _currentState.GameStatus == GameStatus.ReadyToGame)
                SwitchState(_currentState, _gameStateFactory.GetClosedState());
        }
        
        #endregion

        #region Запросы
        
        public GameStatus GetCurrentGameStatus() => _currentState.GameStatus;
        
        public bool IsGameClosed() => 
            _currentState.GameStatus == GameStatus.ClosedGame;
        
        #endregion

        private void SwitchState(GameState? currentState, GameState nextState)
        {
            if (currentState != null && currentState.IsStateActive)
            {
                currentState.ResetState();
            }
            
            nextState.SetState();

            _currentState = nextState;
        }
        
    }
}