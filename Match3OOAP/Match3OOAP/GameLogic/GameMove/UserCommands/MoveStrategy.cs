using Match3OOAP.GameLogic.GameMove.Move;
using Match3OOAP.GameLogic.GameMove.StepCommands;
using Match3OOAP.Helpers;

namespace Match3OOAP.GameLogic.GameMove.UserCommands
{
    public abstract class MoveStrategy : Strategy
    {
        private readonly IStepFactory _stepFactory;
        private MoveResult _result;

        // Предусловие: фабрика шагов не null.
        protected MoveStrategy(IStepFactory stepFactory)
        {
            stepFactory.AssertNotNull();
            
            _stepFactory = stepFactory; 
        }

        protected sealed override void OnExecute()
        {
            _result = ExecuteMove(_stepFactory);
        }

        public MoveResult GetMoveResult() => _result;

        protected abstract MoveResult ExecuteMove(IStepFactory stepFactory);
    }
}