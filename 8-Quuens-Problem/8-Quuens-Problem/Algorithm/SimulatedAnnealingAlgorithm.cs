using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Quuens_Problem.Algorithm
{
    public class SimulatedAnnealingAlgorithm : Utilities
    {
        public SimulatedAnnealingAlgorithm(MainWindow mainWindow)
        {
            window = mainWindow;
        }

        public void SolveProblem(Chessboard chessboard, int temperature, int coolingFactor)
        {
            int[] queensPlacement = chessboard.GetQueensPlacament();
            heuristic = CalculateHeuristic(queensPlacement);
            while (temperature>0 && heuristic>0)
            {

                int randomQueen = GenerateRandomNumber(0, queensPlacement.Length);
                int queensStartPlacement=queensPlacement[randomQueen];
                queensPlacement[randomQueen] = GenerateRandomNumber(0, queensPlacement.Length);

                //if queen didn't change it's placement after giving it a new random one we are trying to give her a new random placament, as long as needed
                while (queensPlacement[randomQueen] == queensStartPlacement)
                {
                    queensPlacement[randomQueen] = GenerateRandomNumber(0, queensPlacement.Length);
                }
                int changedHeuristic = CalculateHeuristic(queensPlacement);

                //if new heuristic is worse or equal the old one it is checked if it should be saved
                if(changedHeuristic>=heuristic)
                {

                    int heuristicDifference = changedHeuristic - heuristic;

                    
                    double probabilityOfAcceptance = Math.Min(1, Math.Exp(changedHeuristic / temperature));

                    Random random = new Random();
                    double randomValue = random.NextDouble();

                    //if random value is higher than probability of acceptance we are coming back to previous state
                    if (randomValue > probabilityOfAcceptance)
                    {
                        queensPlacement[randomQueen] = queensStartPlacement;
                    }

                }

                heuristic = CalculateHeuristic(queensPlacement);
                temperature = temperature - coolingFactor;
                numberOfSteps++;
            }
            chessboard.DrawChessboard();
            //Chessboard drawCheesboard = new Chessboard(queensPlacement, window);
        }
    }
}
