using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Quuens_Problem.Algorithm
{
    class GeneticAlgorithm : Utilities
    {
        public GeneticAlgorithm(MainWindow mainWindow)
        {
            window=mainWindow;
        }

        public void SolveProblem(Chessboard chessboard, int sizeOfSingleGeneration, int percentageOfElitism, int crossoverProbability,
            int mutationProbability, int numberOfGenerations)
        {
            int size = chessboard.GetQueensPlacament().Length;
            List<Chessboard> chessboardGeneration = GenerateChessboardsList(size, sizeOfSingleGeneration);
            Chessboard bestChessboard = GetChessboardWithLowestHeuristic(chessboardGeneration, sizeOfSingleGeneration);
            heuristic = CalculateHeuristic(bestChessboard.GetQueensPlacament());
            if(heuristic==0)
            {
                Chessboard drawChessboard = new Chessboard(bestChessboard.GetQueensPlacament(), window);
                return;
            }

            List<Chessboard> chessboardGenerationChromosomes = new List<Chessboard>();
            this.SortGeneration(chessboardGeneration);
        }


        private void SortGeneration(List<Chessboard> chessboards)
        {
            int size = chessboards.Count;

            for(int i=0;i<size;i++)
            {
                int tempHeuristic = CalculateHeuristic(chessboards[i].GetQueensPlacament());
                chessboards[i].SetHeuristic(tempHeuristic);
            }
        }
    }

}
