using System;
using Match3OOAP.InputHandle;

namespace Match3OOAP.Gui.GameScreen
{
    public class GamePresenter : GuiPresenter<GameView>
    {
        private IMovePresentationStrategy _strategy;
        
        public GamePresenter(GameView view) : base(view)
        {
            /*
             * Нужна стратегия показа всего экрана. Ход по итогу должен гшенерировать событие на которое реагирует презентер экрана и выбирает стратегию показа.
             * 
             * 
             */
        }
    }
}