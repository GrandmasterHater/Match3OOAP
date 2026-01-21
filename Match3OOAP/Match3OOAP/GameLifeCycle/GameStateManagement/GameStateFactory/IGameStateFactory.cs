
namespace Match3OOAP.GameLifeCycle.GameStateManagement.GameStateFactory
{
    public interface IGameStateFactory
    {
        GameState GetReadyState(GameController gameController);
        
        GameState GetRunState(GameController gameController);
        
        GameState GetFinishedState(GameController gameController);
        
        GameState GetClosedState();
    }
}

