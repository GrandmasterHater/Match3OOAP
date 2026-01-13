
namespace Match3OOAP.GameLifeCycle.GameStateManagement.GameStateFactory
{
    public interface IGameStateFactory
    {
        GameState GetReadyState();
        
        GameState GetRunState();
        
        GameState GetFinishedState();
        
        GameState GetClosedState();
    }
}

