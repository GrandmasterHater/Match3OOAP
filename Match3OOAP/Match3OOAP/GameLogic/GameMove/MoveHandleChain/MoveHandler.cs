using Match3OOAP.GameLogic.MoveHandlers;

namespace Match3OOAP.GameLogic.Move.MoveHandleChain
{
    public abstract class MoveHandler
    {
        #region Конструкторы
        
        public MoveHandler() { }

        public MoveHandler(MoveHandler successor) { }
        
        #endregion
        
        #region Команды
        
        public abstract void Handle(MoveResult result);

        #endregion
    }
}