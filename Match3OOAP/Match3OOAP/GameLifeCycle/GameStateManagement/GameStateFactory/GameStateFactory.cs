using Match3OOAP.InputHandle;

namespace Match3OOAP.GameLifeCycle.GameStateManagement.GameStateFactory
{
    public class GameStateFactory : IGameStateFactory
    {
        public GameState GetState<TState>() where TState : GameState, new()
        {
            return new TState();
        }
    }
}