using _8_Quuens_Problem.Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace _8_Quuens_Problem
{

    class Manager
    {
        static private MainWindow window;


        public Manager(MainWindow mainWindow)
        {
            window = mainWindow;
        }

        //This method unchecks all CheckBoxes beside the one that was clicked
        public void UncheckBoxes(ToggleButton toggleButton)
        {
            window.localBeamSearchBox.IsChecked = false;
            window.hillClimbingBox.IsChecked = false;
            window.simulatedAnnealingBox.IsChecked = false;
            window.geneticAlgorithmBox.IsChecked = false;
            toggleButton.IsChecked = true;
        }

        public void AddBoardSizesToChooseList()
        {
            for(int i=4; i<=12; i++)
            {
                string newItem = i + "x" + i;
                window.chooseBoardSizeBox.Items.Add(newItem);
            }
            window.chooseBoardSizeBox.SelectedItem = window.chooseBoardSizeBox.Items[0];
        }

        public int ChessboardSizeToInt()
        {
            string sSize = window.chooseBoardSizeBox.SelectedItem.ToString();
            sSize = sSize.Substring(0, sSize.IndexOf("x"));
            int result = Int32.Parse(sSize);
            return result;
        }

        public void ChessboardSizeChanged()
        {
            window.chessboardGrid.Children.Clear();
            window.chessboardGrid.RowDefinitions.Clear();
            window.chessboardGrid.ColumnDefinitions.Clear();
            window.chessboard = new Chessboard(this.ChessboardSizeToInt(), window);
            window.stepsValueText.Text = "";
            window.solvedTextValue.Text = "";
        }

        public void HillClimbingAlgorithm()
        {
            if (window.hillClimbingAttributes.GetMaxNumberTB() != 0)
            {
                window.chessboard = new Chessboard(this.ChessboardSizeToInt(), window);
                HillClimbingAlgorithm hillClimbing = new HillClimbingAlgorithm(window);
                hillClimbing.SolveProblem(window.GetChessboard(), window.hillClimbingAttributes.GetMaxNumberTB());
                this.SetUITextes(hillClimbing);
            }
        }

        public void SimulatedAnnealingAlgorithm()
        {
            if (window.simulatedAnnealingAttributes.GetStartingTemperature() != 0 && window.simulatedAnnealingAttributes.GetCoolingFactor() != 0)
            {
                window.chessboard = new Chessboard(this.ChessboardSizeToInt(), window);
                SimulatedAnnealingAlgorithm simulatedAnnealing = new SimulatedAnnealingAlgorithm(window);
                simulatedAnnealing.SolveProblem(window.GetChessboard(),
                    window.simulatedAnnealingAttributes.GetStartingTemperature(), window.simulatedAnnealingAttributes.GetCoolingFactor());
                this.SetUITextes(simulatedAnnealing);
            }
        }
        public void LocalBeamSearchAlgorithm()
        {
            if (window.localBeamSearchAttributes.GetMaxNumber() != 0 && window.localBeamSearchAttributes.GetNumberOfStates() != 0)
            {
                LocalBeamSearchAlgorithm localBeamSearch = new LocalBeamSearchAlgorithm(window);
                localBeamSearch.SolveProblem(window.GetChessboard(),
                    window.localBeamSearchAttributes.GetMaxNumber(), window.localBeamSearchAttributes.GetNumberOfStates());
                this.SetUITextes(localBeamSearch);
            }
        }
        public void GeneticAlgorithm()
        {
            if (window.geneticAlgorithmAttributes.GetSize() != 0 &&
                window.geneticAlgorithmAttributes.GetElitism() != 0 && window.geneticAlgorithmAttributes.GetCrossover() != 0 &&
                window.geneticAlgorithmAttributes.GetMutation() != 0 && window.geneticAlgorithmAttributes.GetNumber() != 0)
            {
                GeneticAlgorithm geneticAlgorithm = new GeneticAlgorithm(window);
                geneticAlgorithm.SolveProblem(window.GetChessboard(), window.geneticAlgorithmAttributes.GetSize(),
                    window.geneticAlgorithmAttributes.GetElitism(), window.geneticAlgorithmAttributes.GetCrossover(),
                    window.geneticAlgorithmAttributes.GetMutation(), window.geneticAlgorithmAttributes.GetNumber());
                this.SetUITextes(geneticAlgorithm);
            }
        }


        private void SetUITextes(Utilities algorithmAttributes)
        {
            window.stepsValueText.Text = algorithmAttributes.GetNumberOfSteps().ToString();
            if (algorithmAttributes.GetHeuristic() == 0)
            {
                window.solvedTextValue.Foreground = Brushes.DarkGreen;
                window.solvedTextValue.Text = "Yes";
            }
            else
            {
                window.solvedTextValue.Foreground = Brushes.DarkRed;
                window.solvedTextValue.Text = "No";
            }
        }
    }
}
