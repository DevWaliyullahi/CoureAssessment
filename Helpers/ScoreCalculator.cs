namespace CoureAssessment.Helpers
{
    public static class ScoreCalculator
    {
        /// <summary>
        /// Scores an array of numbers:
        /// - Even: +1 point
        /// - Odd: +3 points  
        /// - If value is 8: +5 bonus
        /// </summary>
        public static int CalculateScore(int[] numbers)
        {
            
            int score = 0;

            foreach (var num in numbers)
            {
                score += num % 2 == 0 ? 1 : 3;
                if (num == 8)
                    score += 5;
            }

            return score;
        }
    }
}