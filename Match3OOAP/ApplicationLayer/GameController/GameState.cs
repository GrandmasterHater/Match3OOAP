namespace Match3OOAP.ApplicationLayer.GameController
{
    public abstract class GameState
    {
        #region Запросы

        public abstract GameStateName Name { get; } 

        #endregion

        #region Команды

        public abstract void SetState();

        #endregion
    }
}