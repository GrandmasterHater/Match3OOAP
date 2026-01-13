using Match3OOAP.GameLogic.Core;

namespace Match3OOAP.GameLogic.Statistics
{
    public interface IScore
    {
        #region Конструктор
        
        // Постусловие: значение счёта равно 0;
        
        #endregion

        #region Команды
        
        // Предусловие: combination не null
        // Постусловие: очки начислены в соответствии с комбинацией
        void AddScore(Combination combination);

        // Постусловие: очки сброшены, значение счёта равно нулю.
        void Clear();
        
        #endregion
        
        #region Запросы

        void GetScore();

        #endregion
    }
    
    public class ScoreImpl : IScore
    {
        public void AddScore(Combination combination)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public void GetScore()
        {
            throw new System.NotImplementedException();
        }
    }
}