using System;

namespace Template_Method
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ScoringAlgorithm algorithm;
            algorithm = new MenScoringAlgorithm();
            Console.WriteLine("ManScore: "+algorithm.GenerateScore(8,new TimeSpan(0,2,34)));

            algorithm = new WomenScoringAlgorithm();
            Console.WriteLine("WomenScore: " + algorithm.GenerateScore(8, new TimeSpan(0, 2, 55)));

        }

        abstract class ScoringAlgorithm
        {
            public int GenerateScore(int hits,TimeSpan time)
            {
                int score = CalculateBaseScore(hits);
                int reduction = CalculateReducition(time);
                return CalculateOverallScore(score, reduction);
            }
            public abstract int CalculateOverallScore(int score, int reduction);
            public abstract int CalculateBaseScore(int hits);
            public abstract int CalculateReducition(TimeSpan time);
        }
        class MenScoringAlgorithm : ScoringAlgorithm
        {
            public override int CalculateBaseScore(int hits)
            {
                return hits * 100;
            }
            public override int CalculateOverallScore(int score, int reduction)
            {
                return score - reduction;
            }
            public override int CalculateReducition(TimeSpan time)
            {
                return (int)time.TotalSeconds / 5;
            }
        }
        class WomenScoringAlgorithm : ScoringAlgorithm
        {
            public override int CalculateBaseScore(int hits)
            {
                return hits * 100;
            }
            public override int CalculateOverallScore(int score, int reduction)
            {
                return score - reduction;
            }
            public override int CalculateReducition(TimeSpan time)
            {
                return (int)time.TotalSeconds / 3;
            }
        }
    }
}
