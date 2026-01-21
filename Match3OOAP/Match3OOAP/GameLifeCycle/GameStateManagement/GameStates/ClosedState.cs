
namespace Match3OOAP.GameLifeCycle.GameStateManagement.GameStates
{
    public sealed class ClosedState : GameState
    {
        public override GameStatus GameStatus => GameStatus.ClosedGame;
        
        //Конструктор: создано пустое состояние.
        
        // Постусловие: состояние не изменилось
        protected override void OnSetState() { }

        // Постусловие: состояние не изменилось
        protected override void OnResetState() { }
    }
}