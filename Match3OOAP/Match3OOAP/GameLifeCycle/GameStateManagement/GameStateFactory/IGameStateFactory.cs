
namespace Match3OOAP.GameLifeCycle.GameStateManagement.GameStateFactory
{
    public interface IGameStateFactory
    {
        GameState GetState<TState>() where TState : GameState, new();
    }
}

