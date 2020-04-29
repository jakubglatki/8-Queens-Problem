using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Quuens_Problem.Algorithm
{
    public class LocalBeamSearchAlgorithm : Utilities
    {
        public LocalBeamSearchAlgorithm(MainWindow mainWindow)
        {
            window = mainWindow;
        }

        public void SolveProblem(Chessboard chessboard, int maxNumberOfSteps, int numberOfStates)
        {
            int size = chessboard.GetQueensPlacament().Length;
            List<Chessboard> chessboardStates = GenerateChessboardsList(size, numberOfStates);
            Chessboard bestChessboard = GetChessboardWithLowestHeuristic(chessboardStates, numberOfStates);
            heuristic = CalculateHeuristic(bestChessboard.GetQueensPlacament());

            while (maxNumberOfSteps>numberOfSteps && heuristic>0)
            {

                numberOfSteps++;
                bestChessboard = GetChessboardWithLowestHeuristic(chessboardStates, numberOfStates);
                heuristic = CalculateHeuristic(bestChessboard.GetQueensPlacament());

                //if solution will be generated at the beggining the method will end and new chessboard will be drawn
                if(heuristic==0)
                {
                    break;
                }

                //each board will be changed to it's state with better heuristic, if it won't be possible it will be replaced by a new one
                chessboardStates = ChangeBoard(size, numberOfStates, chessboardStates, chessboard);

                bestChessboard = GetChessboardWithLowestHeuristic(chessboardStates, numberOfStates);
                heuristic = CalculateHeuristic(bestChessboard.GetQueensPlacament());
            }
           // bestChessboard.DrawChessboard();
            Chessboard drawChessboard = new Chessboard(bestChessboard.GetQueensPlacament(), window);
        }

        private List<Chessboard> ChangeBoard(int size, int numberOfStates,  List<Chessboard> chessboardStates, Chessboard chessboard)
        {

            for (int n = 0; n < numberOfStates; n++)
            {
                int[] compareArray = new int[size];
                int[] heuristicArray = new int[size];
                chessboardStates[n].GetQueensPlacament().CopyTo(compareArray, 0);

                //in each iteration of for loop given chessboard will be moved to it's best possible state
                chessboardStates[n].SetQueensPlacement(MoveQueensInChessboard(chessboardStates[n].GetQueensPlacament(), size, heuristicArray));


                //If array wasn't changed it will be replaced by a new random one
                if (ArrayNotChanged(chessboardStates[n].GetQueensPlacament(), compareArray))
                {
                    chessboard.FillWithRandomPlacements();
                    chessboardStates[n].SetQueensPlacement(chessboard.GetQueensPlacament());
                }
            }
            return chessboardStates;
        }

         
    }
}
