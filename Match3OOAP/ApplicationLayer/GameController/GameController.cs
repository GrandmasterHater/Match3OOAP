using System;

namespace Match3OOAP.ApplicationLayer.GameController
{
    public class GameController
    {
        #region Конструкторы

        // Предусловие - gameStateFactory не null.
        // Постусловие - текущее состояние игры - не готова (NotReady).
        public GameController(IGameStateFactory gameStateFactory)
        {
            
        }

        #endregion
        
        #region Команды 
        
        // Предусловия: текущее состояние игры - не готова (NotReady).
        // Постусловия: текущее состояние игры - готова (ReadyToGame).
        public void ReadyToGame() { }
        
        // Предусловия: текущее состояние игры - готова(ReadyToGame), запущена игра (StartedGame) или завершена (FinishedGame).
        // Постусловия: текущее состояние игры - запущена (StartedGame).
        public void StartGame() { }
        
        // Предусловия: текущее состояние игры - запущена (StartedGame).
        // Постусловия: текущее состояние игры - завершена (FinishedGame).
        public void FinishGame() { }
        
        #endregion

        #region Запросы
        
        public GameStateName GetCurrentState()
        {
            throw new NotImplementedException();
        }
        
        #endregion 
        
    }
}