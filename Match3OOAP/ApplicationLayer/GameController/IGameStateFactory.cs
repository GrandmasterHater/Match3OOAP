namespace Match3OOAP.ApplicationLayer.GameController
{
    public interface IGameStateFactory
    {
        public GameState GetState(GameStateName name);
    }
}