using Match3OOAP.GameLogic.Core;

namespace Match3OOAP.GameLogic.Statistics
{
    public class ScoreImpl : IScore
    {
        private const int ELEMENT_PRICE = 1;
        private int _currentScore;

        public ScoreImpl()
        {
            _currentScore = 0;
        }
        
        public void AddScore(Combination combination)
        {
            _currentScore += CalculateScore(combination);
        }

        public void Clear()
        {
            _currentScore = 0;
        }

        public int GetScore() => _currentScore;

        private int CalculateScore(Combination combination)
        {
            float combinationMultiplier = 1.0f;
            CombinationImpl.Shape shape = combination.GetShape();

            if (shape == CombinationImpl.Shape.Angle)
                combinationMultiplier = 1.5f;
            else if (shape == CombinationImpl.Shape.Tshape)
                combinationMultiplier = 2.0f;
            else if (shape == CombinationImpl.Shape.Cross)
                combinationMultiplier = 3.0f;
            
            float elementsPriceMultiplier = ELEMENT_PRICE + (combination.ElementsCount() - Combination.MIN_ELEMENTS_COUNT_IN_LINE) * 2.0f;
            
            return (int) (combination.ElementsCount() * ELEMENT_PRICE * elementsPriceMultiplier * combinationMultiplier);
        }
    }
}