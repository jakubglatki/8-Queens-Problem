using _8_Quuens_Problem.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace _8_Quuens_Problem
{
    public class Chessboard
    {
        private int[] queensPlacement;
        private int heuristic;
        static private MainWindow window;


        //initial chessboard
        public Chessboard(int size, MainWindow mainWindow)
        {
            window = mainWindow;
            queensPlacement = new int[size];
            this.FillWithRandomPlacements();
            this.DrawChessboard();

        }

        //chessboard object for solved chessboard
        public Chessboard(int[] queensArray, MainWindow mainWindow)
        {
            window = mainWindow;
            queensPlacement = queensArray;
            this.DrawChessboard();

        }

        public void SetQueensPlacement(int[] queensArray)
        {
            this.queensPlacement = queensArray;
        }
        public int[] GetQueensPlacament()
        {
            return this.queensPlacement;
        }

        public int GetHeuristic()
        {
            return this.heuristic;
        }

        

        public void FillWithRandomPlacements()
        {
            Random randNum = new Random();
            for (int i = 0; i < this.queensPlacement.Length; i++)
            {
                this.queensPlacement[i] = randNum.Next(0, queensPlacement.Length);
            }
        }


        public void DrawChessboard()
        {
            AddColumnsAndRowsToGrid();


            int blackOrWhite;
            for (int i=0;i<queensPlacement.Length;i++)
            {
                if (i % 2 == 0)
                {
                    blackOrWhite = 1;
                }
                else
                {
                    blackOrWhite = 0;
                }
                for (int j=0; j<queensPlacement.Length;j++)
                {

                    if (j % 2 == blackOrWhite)
                    {
                        SetFields(j, i, "bright");
                    }
                    else
                    {
                        SetFields(j, i, "dark");
                    }
                }
            }

            Utilities utilities = new Utilities();
            heuristic = utilities.CalculateHeuristic(queensPlacement);
            window.heuristicValueText.Text = heuristic.ToString();
        }

        //method setting fields to proper image
        private void SetFields(int j, int i, string field)
        {
            Image bright = new Image();
            string pathString = "pack://application:,,,/8-Quuens-Problem;component/Resources/";
            if (queensPlacement[j] != i)
            {
                bright.Source = new BitmapImage(new Uri(pathString+field+".png"));
            }
            else
            {
                bright.Source = new BitmapImage(new Uri(pathString+field +"Q.png"));
            }

            Grid.SetColumn(bright, j);
            Grid.SetRow(bright, i);
            window.chessboardGrid.Children.Add(bright);

        }


        private void AddColumnsAndRowsToGrid()
        {
            window.chessboardGrid.Children.Clear();
            window.chessboardGrid.ColumnDefinitions.Clear();
            window.chessboardGrid.RowDefinitions.Clear();
            double gridLength = window.chessboardGrid.Width/queensPlacement.Length;
            for (int i=0; i<queensPlacement.Length;i++)
            {
                ColumnDefinition column = new ColumnDefinition();
                column.Width =new System.Windows.GridLength(gridLength);
                window.chessboardGrid.ColumnDefinitions.Add(column);

                RowDefinition row = new RowDefinition();
                row.Height = new System.Windows.GridLength(gridLength);
                window.chessboardGrid.RowDefinitions.Add(row);
            }
        }

    }
}
