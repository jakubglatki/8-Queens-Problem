using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Quuens_Problem.Algorithm
{
    public class HillClimbingAlgorithm : Utilities
    {
        private int numberOfSteps;
        static private MainWindow window;
        public HillClimbingAlgorithm(MainWindow mainWindow)
        {
            window = mainWindow;
        }

        public int GetNumberOfSteps()
        {
            return numberOfSteps;
        }

        public void SolveProblem(Chessboard chessboard, int maxNumberOfSteps)
        {
            //array that works will be made on
            int[] queensPlacement = chessboard.GetQueensPlacament();

            //array to check if something changed between two arrays
            int[] compareArray = new int[queensPlacement.Length];

            //array to check heuristic of all position when queen moves verticaly
            int[] heuristicArray = new int[queensPlacement.Length];

            heuristic = CountHeuristic(queensPlacement);
            numberOfSteps = 0;

            while (numberOfSteps < maxNumberOfSteps && heuristic > 0)
            {
                queensPlacement.CopyTo(compareArray, 0);
                for (int i = 0; i < queensPlacement.Length; i++)
                {
                    for (int j = 0; j < queensPlacement.Length; j++)
                    {
                        queensPlacement[i] = j;
                        heuristicArray[j] = CountHeuristic(queensPlacement);
                    }

                    //it will set queen to the position with the least heuristic
                    int index = Array.IndexOf(heuristicArray, heuristicArray.Min());
                    queensPlacement[i] = index;

                }
                //we are stuck, so there is a need to generate new random chessboard
                if (ArrayNotChanged(queensPlacement, compareArray))
                {
                    chessboard.FillWithRandomPlacements();
                    queensPlacement = chessboard.GetQueensPlacament();
                }

                heuristic = CountHeuristic(queensPlacement);
                numberOfSteps++;
            }
            chessboard.DrawChessboard();
        }



    }
}
