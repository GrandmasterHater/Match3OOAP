using System.Collections.Generic;
using Match3OOAP.GameLogic.Core;
using Match3OOAP.GameLogic.Statistics;
using Match3OOAP.Helpers;

namespace Match3OOAP.GameLogic.GameMove.StepCommands
{
    public class UpdateScoreStep : IStep
    {
        private readonly IScore _score;
        private readonly IReadOnlyList<Combination> _combinations;
        private int _scoreChange;

        public UpdateScoreStep(IScore score, IReadOnlyList<Combination> combinations)
        {
            score.AssertNotNull();
            combinations.AssertNotNull();
            combinations.AssertItemsNotNull();
            
            _score = score;
            _combinations = combinations;
        }
        
        public void Execute()
        {
            int currentScore = _score.GetScore();
            
            foreach (Combination combination in _combinations)
            {
                _score.AddScore(combination);
            }

            _scoreChange = _score.GetScore() - currentScore;
        }

        public void ReadResult(IStepReader readerVisitor)
        {
            readerVisitor.Read(this);
        }

        public int GetScoreChange() => _scoreChange;
    }
}