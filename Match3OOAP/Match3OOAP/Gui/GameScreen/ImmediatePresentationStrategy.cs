using System;
using Match3OOAP.GameLogic.GameMove.Moves;
using Match3OOAP.Gui.GameScreen.Presenters;
using Match3OOAP.Helpers;
using Match3OOAP.InputHandle;

namespace Match3OOAP.Gui.GameScreen
{
    public class ImmediatePresentationStrategy : Strategy
    {
        private readonly IGameScorePresenter _scorePresenter;
        private readonly IGridPresenter _gridPresenter;
        private readonly IBonusPresenter _bonusPresenter;
        private readonly IPresentable _gameInfoPresenter;
        private readonly IInvalidMoveInfoPresenter _invalidMoveInfoPresenter;

        public ImmediatePresentationStrategy(
            IGameScorePresenter scorePresenter,
            IGridPresenter gridPresenter,
            IBonusPresenter bonusPresenter,
            IPresentable gameInfoPresenter,
            IInvalidMoveInfoPresenter invalidMoveInfoPresenter)
        {
            scorePresenter.AssertNotNull();
            gridPresenter.AssertNotNull();
            bonusPresenter.AssertNotNull();
            gameInfoPresenter.AssertNotNull();
            invalidMoveInfoPresenter.AssertNotNull();

            _scorePresenter = scorePresenter;
            _gridPresenter = gridPresenter;
            _bonusPresenter = bonusPresenter;
            _gameInfoPresenter = gameInfoPresenter;
            _invalidMoveInfoPresenter = invalidMoveInfoPresenter;
        }

        protected override void OnExecute()
        {
            Console.Clear();
            _gameInfoPresenter.UpdateData();
            _scorePresenter.UpdateData();
            _gridPresenter.UpdateData();
            _bonusPresenter.UpdateData();
            _invalidMoveInfoPresenter.UpdateData();
                
            _gameInfoPresenter.UpdateViewImmedaitely();
            _scorePresenter.UpdateViewImmedaitely();
            _gridPresenter.UpdateViewImmedaitely();
            _bonusPresenter.UpdateViewImmedaitely();
            _invalidMoveInfoPresenter.UpdateViewImmedaitely();
        }
    }
}