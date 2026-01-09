
namespace Match3OOAP.GameLifeCycle.GameStateManagement.GameStates
{
    public sealed class ClosedState : GameState
    {
        public override string Name => nameof(ClosedState);
        
        public override void SetState() { }

        public override void ResetState() { }
    }
}