using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Quuens_Problem.Algorithm
{
    public class HillClimbingAlgorithm : Utilities
    {
        public HillClimbingAlgorithm(MainWindow mainWindow)
        {
            window = mainWindow;
        }


        public void SolveProblem(Chessboard chessboard, int maxNumberOfSteps)
        {
            //array that works will be made on
            int[] queensPlacement = chessboard.GetQueensPlacament();

            //array to check if something changed between two arrays
            int[] compareArray = new int[queensPlacement.Length];

            //array to check heuristic of all position when queen moves verticaly
            int[] heuristicArray = new int[queensPlacement.Length];

            heuristic = CalculateHeuristic(queensPlacement);
            numberOfSteps = 0;

            while (numberOfSteps < maxNumberOfSteps && heuristic > 0)
            {
                numberOfSteps++;
                queensPlacement.CopyTo(compareArray, 0);

                queensPlacement = MoveQueensInChessboard(queensPlacement, queensPlacement.Length, heuristicArray);

                //If array wasn't changed it will be replaced by a new random one
                if (ArrayNotChanged(queensPlacement, compareArray))
                {
                    chessboard.FillWithRandomPlacements();
                    queensPlacement = chessboard.GetQueensPlacament();
                }

                heuristic = CalculateHeuristic(queensPlacement);
            }


            Chessboard drawCheesboard = new Chessboard(queensPlacement, window);
        }



    }
}
