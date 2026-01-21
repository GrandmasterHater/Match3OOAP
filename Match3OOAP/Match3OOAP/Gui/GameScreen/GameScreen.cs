using System;
using Match3OOAP.GameLifeCycle.GameStateManagement;
using Match3OOAP.GameLogic.BonusSystem;
using Match3OOAP.GameLogic.GameGrid;
using Match3OOAP.GameLogic.GameMove;
using Match3OOAP.GameLogic.Statistics;
using Match3OOAP.Gui.GameScreen.Presenters;
using Match3OOAP.Helpers;
using Match3OOAP.InputHandle;

namespace Match3OOAP.Gui.GameScreen
{
    public class GameScreen : IPresentable
    {
        private readonly IGameScorePresenter _scorePresenter;
        private readonly IGridPresenter _gridPresenter;
        private readonly IBonusPresenter _bonusPresenter;
        private readonly IPresentable _gameInfoPresenter;
        private readonly IInvalidMoveInfoPresenter _invalidMoveInfoPresenter;
        private readonly IConsoleAsyncInputListener _inputListener;
        private readonly IGrid _grid;
        private readonly IMove _move;
        private readonly IScore _score;
        private readonly IBonusContainer<ManualApplicableBonus> _bonusContainer;
        private readonly GameController _gameController;
        private readonly Predicate<string>[] _inputHandlers;
        private Strategy? _movePresentationStrategy;

        public GameScreen(IGrid grid, 
            IMove move, 
            IScore score, 
            GameController gameController, 
            IBonusContainer<ManualApplicableBonus> manualBonusContainer)
        {
            grid.AssertNotNull();
            move.AssertNotNull();
            score.AssertNotNull();
            gameController.AssertNotNull();
            manualBonusContainer.AssertNotNull();

            _grid = grid;
            _move = move;
            _score = score;
            _gameController = gameController;
            
            _bonusContainer = manualBonusContainer;
            _gridPresenter = CreateGridPresenter();
            _bonusPresenter = CreateBonusPresenter();
            _gameInfoPresenter = CreateGameInfoPresenter();
            _scorePresenter = CreateGameScorePresenter();
            _inputListener = CreateInputListener();
            _invalidMoveInfoPresenter = CreateInvalidMoveInfoPresenter();
            
            _inputHandlers = GetInputHandlers();
        }

        public void Activate()
        {
            Console.Clear();
            
            _gameInfoPresenter.Activate();
            _scorePresenter.Activate();
            _gridPresenter.Activate();
            _bonusPresenter.Activate();
            _invalidMoveInfoPresenter.Activate();

            _inputListener.OnUserInputReceived += OnUserInputReceived;
            _move.OnMoveCompletedEvent += OnMoveCompleted;
        }

        public void Deactivate()
        {
            _inputListener.OnUserInputReceived -= OnUserInputReceived;
            _move.OnMoveCompletedEvent -= OnMoveCompleted;
            
            _gameInfoPresenter.Deactivate();
            _scorePresenter.Deactivate();
            _gridPresenter.Deactivate();
            _bonusPresenter.Deactivate();
            _invalidMoveInfoPresenter.Deactivate();
        }

        public void UpdateViewImmedaitely()
        {
            _gameInfoPresenter.UpdateViewImmedaitely();
            _scorePresenter.UpdateViewImmedaitely();
            _bonusPresenter.UpdateViewImmedaitely();
            _gridPresenter.UpdateViewImmedaitely();
            _invalidMoveInfoPresenter.UpdateViewImmedaitely();
        }

        public void UpdateData()
        {
            _gameInfoPresenter.UpdateViewImmedaitely();
            _scorePresenter.UpdateViewImmedaitely();
            _bonusPresenter.UpdateViewImmedaitely();
            _gridPresenter.UpdateViewImmedaitely();
            _invalidMoveInfoPresenter.UpdateViewImmedaitely();
        }

        private void OnUserInputReceived(string inputText)
        {
            if (_movePresentationStrategy != null)
            {
                _movePresentationStrategy = new ImmediatePresentationStrategy(
                    _scorePresenter,
                    _gridPresenter,
                    _bonusPresenter,
                    _gameInfoPresenter,
                    _invalidMoveInfoPresenter);
                
                _movePresentationStrategy.Execute();
                _movePresentationStrategy = null;
                return;
            }
            
            foreach (Predicate<string> handler in _inputHandlers)
            {
                if (handler(inputText))
                    return;
            }
            
            Console.Clear();
            _invalidMoveInfoPresenter.SetInvalidMoveInfo("Unrecognized command! Try again!");
            UpdateViewImmedaitely();
        }
        
        private void OnMoveCompleted()
        {
            _movePresentationStrategy = new StepByStepPresentationStrategy(
                _scorePresenter,
                _gridPresenter,
                _bonusPresenter,
                _gameInfoPresenter,
                _invalidMoveInfoPresenter,
                _move.GetLastMoveResult()!,
                () => _movePresentationStrategy == null);
            
            _movePresentationStrategy.Execute();

            _movePresentationStrategy = null;
        }
        
        private Predicate<string>[] GetInputHandlers()
        {
            return new Predicate<string>[]
            {
                _gridPresenter.TryHandleInput, 
                _bonusPresenter.TryHandleInput,
                text =>
                {
                    if (string.IsNullOrEmpty(text) || !text.Trim().Equals("F", StringComparison.OrdinalIgnoreCase))
                        return false;
                    
                    _gameController.FinishGame();
                    return true;
                }
            };
        }
        
        protected virtual IGridPresenter CreateGridPresenter() => new GridPresenter(_grid, _move, new GridView());
        
        protected virtual IBonusPresenter CreateBonusPresenter() => new BonusPresenter(_bonusContainer, _move, new BonusView());
        
        protected virtual IGameScorePresenter CreateGameScorePresenter() => new GameScorePresenter(_score, new GameScoreView());
        
        protected virtual IPresentable CreateGameInfoPresenter() => new HowToPlayInfoPresenter(new GameInfoView());

        protected virtual IInvalidMoveInfoPresenter CreateInvalidMoveInfoPresenter() => new InvalidMoveInfoPresenter(new GameInfoView());
        
        protected virtual IConsoleAsyncInputListener CreateInputListener() => ConsoleAsyncInputListener.Instance;
    }
}