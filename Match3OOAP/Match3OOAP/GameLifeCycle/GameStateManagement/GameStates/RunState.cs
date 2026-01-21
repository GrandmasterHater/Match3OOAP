
using Match3OOAP.GameLogic.BonusSystem;
using Match3OOAP.GameLogic.Core;
using Match3OOAP.GameLogic.GameGrid;
using Match3OOAP.GameLogic.GameMove;
using Match3OOAP.GameLogic.GameMove.StepCommands;
using Match3OOAP.GameLogic.Statistics;
using Match3OOAP.Gui.GameScreen;
using Match3OOAP.Helpers;
using Match3OOAP.InputHandle;

namespace Match3OOAP.GameLifeCycle.GameStateManagement.GameStates
{
    public class RunState : GameState
    {
        private readonly GameController _gameController;
        private readonly IScore _score;
        
        private readonly IMoveHistory _moveHistory;
        private readonly IGrid _grid;
        private readonly IMove _move;
        private readonly IBonusContainer<AutoApplicableBonus> _autoBonusContainer;
        private readonly IBonusContainer<ManualApplicableBonus> _manualBonusContainer;
        private readonly IStepFactory _stepFactory;

        private readonly IPresentable _gameScreen;

        public override GameStatus GameStatus => GameStatus.StartedGame;

        // Предусловие: счёт и история ходов не null.
        // Постусловие: игровая логика и поле готово к показу.
        public RunState(IScore score, IMoveHistory moveHistory, GameController gameController)
        {
            score.AssertNotNull();
            moveHistory.AssertNotNull();
            gameController.AssertNotNull();
            
            _score = score;
            _moveHistory = moveHistory;
            _gameController = gameController;

            _autoBonusContainer = CreateAutoBonusContainer();
            _manualBonusContainer = CreateManualBonusContainer();
            _grid = CreateGrid();
            _stepFactory = CreateStepFactory();
            _move = CreateMove();
            _gameScreen = CreateGameScreenPresenter();
        }

        // Постусловие:
        // - игровое поле отображено;
        // - игровая логика запущена;
        protected override void OnSetState()
        {
            _moveHistory.Clear();
            _score.Clear();

            InitializeGrid();

            _gameScreen.Activate();

            _move.OnMoveCompletedEvent += OnMoveCompleted;
        }

        // Постусловие:
        // - игровая логика остановлена;
        // - игровая поле скрыто;
        protected override void OnResetState()
        {
            _move.OnMoveCompletedEvent -= OnMoveCompleted;
        }
        
        private void OnMoveCompleted()
        {
            if (!_move.IsNextMoveAvailable())
                _gameController.FinishGame();
        }
        
        private void InitializeGrid()
        {
            FindCombinationsStep findCombinations = _stepFactory.CreateFindCombinationsOnGrid();
            findCombinations.Execute();

            for (FindCombinationsStep currentCombinations = findCombinations, nextCombinations = findCombinations;
                 currentCombinations.HasCombinations();
                 currentCombinations = nextCombinations)
            {
                RemoveCombinationFromGridStep removeCombinations = _stepFactory.CreateRemoveCombinationFromGridStep(findCombinations.GetCombinations());
                removeCombinations.Execute();
                _grid.FillEmptyPlaces();
                nextCombinations = _stepFactory.CreateFindCombinationsOnGrid();
                nextCombinations.Execute();
            }
        }

        protected virtual IGrid CreateGrid()
        {
            return new GridImpl(new Size(8, 8), new RandomElementsGenerator());
        }

        protected virtual IPresentable CreateGameScreenPresenter()
        {
            return new GameScreen(_grid, _move, _score, _gameController, _manualBonusContainer);
        }
        
        protected virtual IMove CreateMove()
        {
            IMoveStrategyFactory moveStrategyFactory = new MoveStrategyFactoryImpl(_grid);

            return new MoveImpl(moveStrategyFactory, _moveHistory, _stepFactory);
        }

        private IStepFactory CreateStepFactory()
        {
            IStepFactory stepFactory = new StepFactoryImpl(_grid, _score, new BonusFactoryImpl(), _autoBonusContainer, _manualBonusContainer);
            return stepFactory;
        }

        protected virtual IBonusContainer<AutoApplicableBonus>? CreateAutoBonusContainer()
        {
            return new BonusContainer<AutoApplicableBonus>();
        }
        
        protected virtual IBonusContainer<ManualApplicableBonus>? CreateManualBonusContainer()
        {
            return new BonusContainer<ManualApplicableBonus>();
        }
    }
}