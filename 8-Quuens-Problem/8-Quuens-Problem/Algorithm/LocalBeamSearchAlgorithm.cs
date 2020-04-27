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
            Chessboard bestChessboard = GetChessboardWithLowestHeuristic(chessboardStates, size);
            heuristic = CalculateHeuristic(bestChessboard.GetQueensPlacament());

            while (maxNumberOfSteps>numberOfSteps && heuristic>0)
            {
                bestChessboard = GetChessboardWithLowestHeuristic(chessboardStates, size);
                heuristic = CalculateHeuristic(bestChessboard.GetQueensPlacament());
                if(heuristic==0)
                {
                    break;
                }
                for(int n=0;n<numberOfStates;n++)
                {
                    int[] compareArray = new int[size];
                    int[] heuristicArray = new int[size];
                    chessboardStates[n].GetQueensPlacament().CopyTo(compareArray, 0);

                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            chessboardStates[n].GetQueensPlacament()[i] = j;
                            heuristicArray[j] = CalculateHeuristic(chessboardStates[i].GetQueensPlacament());
                        }

                        //it will set queen to the position with the least heuristic
                        int index = Array.IndexOf(heuristicArray, heuristicArray.Min());
                        chessboardStates[i].GetQueensPlacament()[i] = index;

                    }

                    if (ArrayNotChanged(chessboardStates[n].GetQueensPlacament(), compareArray))
                    {
                        chessboard.FillWithRandomPlacements();
                        chessboardStates[n].SetQueensPlacement(chessboard.GetQueensPlacament());
                    }
                }
                heuristic = CalculateHeuristic(bestChessboard.GetQueensPlacament());
                numberOfSteps++;
            }
           //
            
            
            
            bestChessboard.DrawChessboard();
            Chessboard drawChessboard = new Chessboard(bestChessboard.GetQueensPlacament(), window);
        }

        private List<Chessboard> GenerateChessboardsList(int size, int numberOfStates)
        {
            List<Chessboard> chessboardStates = new List<Chessboard>();

            for (int i = 0; i < numberOfStates; i++)
            {
                Chessboard chessboard = new Chessboard(size);
                chessboardStates.Add(chessboard);
            }

            return chessboardStates;
        }

        private Chessboard GetChessboardWithLowestHeuristic(List<Chessboard> chessboardsList, int size)
        {
            Chessboard chessboardToReturn = chessboardsList[0];
            int lowestHeuristic = CalculateHeuristic(chessboardsList[0].GetQueensPlacament());
            
            for(int i=1;i<size;i++)
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
