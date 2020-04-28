using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Quuens_Problem
{
    public class Utilities
    {
        protected int heuristic;
        protected int numberOfSteps;
        static protected MainWindow window;
        private static readonly object syncLock = new object();
        private static readonly Random random = new Random();
        public Utilities() { }


        public int GetHeuristic()
        {
            return heuristic;
        }


        public int GetNumberOfSteps()
        {
            return numberOfSteps;
        }

        //Heuristic is getting bigger each time two pieces are in the same row/are sharing the same diagonal line
        public int CalculateHeuristic(int[] chessboard)
        {
            int heuristic = 0;

            for (int i = 0; i < chessboard.Length; i++)
            {
                for (int j = i + 1; j < chessboard.Length; j++)
                {
                    if (chessboard[i] == chessboard[j] || Math.Abs(chessboard[i] - chessboard[j]) == j - i)
                        heuristic += 1;
                }
            }
            return heuristic;
        }

        protected bool ArrayNotChanged(int[] firstA, int[] secondA)
        {
            for (int i = 0; i < firstA.Length; i++)
            {
                if (firstA[i] != secondA[i])
                {
                    return false;
                }
            }
            return true;
        }

        protected int GenerateRandomNumber(int min, int max)
        {
            lock (syncLock)
            {
                return random.Next(min, max);
            }
        }

        protected List<Chessboard> GenerateChessboardsList(int size, int numberOfStates)
        {
            List<Chessboard> chessboardStates = new List<Chessboard>(numberOfStates);

            for (int i = 0; i < numberOfStates; i++)
            {
                Chessboard chessboard = new Chessboard(size);
                chessboardStates.Add(chessboard);
            }
            return chessboardStates;
        }



        protected Chessboard GetChessboardWithLowestHeuristic(List<Chessboard> chessboardsList, int size)
        {
            Chessboard chessboardToReturn = chessboardsList[0];
            int lowestHeuristic = CalculateHeuristic(chessboardsList[0].GetQueensPlacament());

            for (int i = 0; i < size; i++)
            {
                int tempHeuristic = CalculateHeuristic(chessboardsList[i].GetQueensPlacament());
                if (tempHeuristic < lowestHeuristic)
                {
                    lowestHeuristic = tempHeuristic;
                    chessboardToReturn = chessboardsList[i];
                }
            }

            return chessboardToReturn;
        }
    }
}
