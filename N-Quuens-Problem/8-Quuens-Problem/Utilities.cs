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
        protected static readonly object syncLock = new object();
        protected static readonly Random random = new Random();
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

        //Method for HillClimbing and LocalBeamSearch, it moves queen to the best row in each column
        protected int[] MoveQueensInChessboard(int[] chessboard, int size, int[] heuristicArray)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    chessboard[i] = j;
                    heuristicArray[j] = CalculateHeuristic(chessboard);
                }

                //it will set queen to the position with the least heuristic
                int index = Array.IndexOf(heuristicArray, heuristicArray.Min());
                chessboard[i] = index;

            }
            return chessboard;
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


        protected int[] MoveQueenInRandomColumn(int[] queensPlacement)
        {
            int randomQueen = GenerateRandomNumber(0, queensPlacement.Length);
            int queensStartPlacement = queensPlacement[randomQueen];
            queensPlacement[randomQueen] = GenerateRandomNumber(0, queensPlacement.Length);

            //if queen didn't change it's placement after giving it a new random one we are trying to give her a new random placament, as long as needed
            while (queensPlacement[randomQueen] == queensStartPlacement)
            {
                queensPlacement[randomQueen] = GenerateRandomNumber(0, queensPlacement.Length);
            }
            return queensPlacement;
        }
    }
}
