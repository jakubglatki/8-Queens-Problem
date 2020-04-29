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

            //whole first generation
            List<Chessboard> chessboardGeneration = GenerateChessboardsList(size, sizeOfSingleGeneration);

            //List where new chromosomes will be saved
            List<Chessboard> chessboardNewGeneration = new List<Chessboard>();
            heuristic = CalculateHeuristic(chessboardGeneration[0].GetQueensPlacament());

            while (numberOfSteps < numberOfGenerations && heuristic > 0)
            {
                numberOfSteps++;

                chessboardGeneration = this.SortGeneration(chessboardGeneration);

            //if one of the chessboards is already solved after making first generation algorithm ends
            heuristic = CalculateHeuristic(chessboardGeneration[0].GetQueensPlacament());
            if (heuristic == 0)
            {
                Chessboard drawSolvedChessboard = new Chessboard(chessboardGeneration[0].GetQueensPlacament(), window);
                return;
            }

            //saving the best values into Elite list
            List<Chessboard> chessboardElite = this.GetEliteList(chessboardGeneration, percentageOfElitism);

            //saving elite list into newGeneration
            chessboardNewGeneration.AddRange(chessboardElite);

                while (chessboardNewGeneration.Count<sizeOfSingleGeneration)
                {
                    //Method responsible for selection, crossover and mutation
                    chessboardNewGeneration.AddRange(MakeOperationsForNewGeneration(chessboardGeneration, crossoverProbability, mutationProbability));
                }
                chessboardGeneration.Clear();
                chessboardGeneration.AddRange(chessboardNewGeneration);
                chessboardNewGeneration.Clear();
                heuristic = CalculateHeuristic(GetChessboardWithLowestHeuristic(chessboardGeneration,size).GetQueensPlacament());
            }

            Chessboard drawChessboard = new Chessboard(chessboardGeneration[0].GetQueensPlacament(), window);
            return;
        }


        //The generation is solved by heuristic, with the lowest at the beginning 
        private List<Chessboard> SortGeneration(List<Chessboard> chessboards)
        {
            int size = chessboards.Count;

            for(int i=0;i<size;i++)
            {
                int tempHeuristic = CalculateHeuristic(chessboards[i].GetQueensPlacament());
                chessboards[i].SetHeuristic(tempHeuristic);
            }
            List<Chessboard> sortedList = chessboards.OrderBy(o => o.GetHeuristic()).ToList();
            return sortedList;
        }

        
        private List<Chessboard> GetEliteList(List<Chessboard> chessboards, int percentageOfElitism)
        {
            int numberOfElitism = chessboards.Count * percentageOfElitism / 100;
            List<Chessboard> eliteList= chessboards.GetRange(0, numberOfElitism);
            return eliteList;
        }


        private List<Chessboard> MakeOperationsForNewGeneration(List<Chessboard> chessboardGeneration,int crossoverProbability, int mutationProbability)
        {
            //random selection of two parents from Generation
            Chessboard parentA = this.Selection(chessboardGeneration);
            Chessboard parentB = this.Selection(chessboardGeneration);

            //while loop to make sure that selected parents are different chessboards
            while (parentA == parentB)
            {
                parentB = this.Selection(chessboardGeneration);
            }

            //swaping all colums beyond random one in parents
            this.Crossover(parentA, parentB, crossoverProbability);

            //moving queen from random column to randow row
            this.Mutation(parentA, parentB, mutationProbability);

            List<Chessboard> returnList= new List<Chessboard>();
            returnList.Add(parentA);
            returnList.Add(parentB);
            return returnList;
        }
        
        private Chessboard Selection(List<Chessboard> chessboards)
        {
            int index;
            lock (syncLock)
            {
                index= random.Next(0, chessboards.Count);
            }
            return chessboards[index];
        }

        private void Crossover(Chessboard parentA, Chessboard parentB, int crossoverProbability)
        {
            //if this statement won't be true crossover won't be done

            if (WillChromosomeBeChanged(crossoverProbability))
            {
                int column = GenerateRandomNumber(0, parentA.GetQueensPlacament().Length);

                for (int i = column; i < parentA.GetQueensPlacament().Length; i++)
                {
                    int temp = parentA.GetQueensPlacament()[i];
                    parentA.GetQueensPlacament()[i] = parentB.GetQueensPlacament()[i];
                    parentB.GetQueensPlacament()[i] = temp;
                }
            }
        }

        private void Mutation(Chessboard parentA, Chessboard parentB, int mutationProbability)
        {
            //if this statement won't be true mutation won't be done
            if (WillChromosomeBeChanged(mutationProbability))
            {
                parentA.SetQueensPlacement(this.MoveQueenInRandomColumn(parentA.GetQueensPlacament()));
                parentB.SetQueensPlacement(this.MoveQueenInRandomColumn(parentA.GetQueensPlacament()));
            }

        }
        

        private bool WillChromosomeBeChanged(int probability)
        {
            double mutationValue = (double)probability / 100;
            double randomValue;
            lock (syncLock)
            {
                randomValue = random.NextDouble();
            }

            //if this statement won't be true crossover won't be done
            if (mutationValue >= randomValue)
            {
                return true;
            }

            else return false;
        }
        

    }

}
