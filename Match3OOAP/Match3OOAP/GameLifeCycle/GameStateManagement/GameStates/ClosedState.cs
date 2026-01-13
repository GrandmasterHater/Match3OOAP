
namespace Match3OOAP.GameLifeCycle.GameStateManagement.GameStates
{
    public sealed class ClosedState : GameState
    {
        public override string Name => nameof(ClosedState);
        
        //Конструктор: создано пустое состояние.
        
        // Постусловие: состояние не изменилось
        public override void SetState() { }

        // Постусловие: состояние не изменилось
        public override void ResetState() { }
    }
}