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
    class Chessboard
    {
        private int[] queensPlacement;
        static private MainWindow window;

        public Chessboard(int size, MainWindow mainWindow)
        {
            window = mainWindow;
            queensPlacement = new int[size];
            this.FillWithRandomPlacements();
            this.DrawChessboard();
        }


        private void FillWithRandomPlacements()
        {
            Random randNum = new Random();
            for (int i = 0; i < this.queensPlacement.Length; i++)
            {
                this.queensPlacement[i] = randNum.Next(0, queensPlacement.Length);
            }
        }


        private void DrawChessboard()
        {
            Image bright = new Image();
            bright.Source = new BitmapImage(new Uri("D:/Users/Jakub Głatki/GitHub/8-Queens-Problem/8-Quuens-Problem/8-Quuens-Problem/Resources/bright.png"));

            Image dark = new Image();
            dark.Source = new BitmapImage(new Uri("D:/Users/Jakub Głatki/GitHub/8-Queens-Problem/8-Quuens-Problem/8-Quuens-Problem/Resources/dark.png"));

            for (int i=0;i<queensPlacement.Length;i++)
            {
                for (int j=0; j<queensPlacement.Length;j++)
                {
                    if (i == 0)
                    {
                        Grid.SetColumn(bright, j);
                        Grid.SetRow(bright, i);
                    }
                    else
                    {
                        Grid.SetColumn(dark, j);
                        Grid.SetRow(dark, i);
                    }
                }
            }
            window.chessboardGrid.Children.Add(bright);
            window.chessboardGrid.Children.Add(dark);
        }

        private void AddColumnsAndRowsToGrid()
        {
            for (int i=0; i<queensPlacement.Length;i++)
            {
                ColumnDefinition column = new ColumnDefinition();
                window.chessboardGrid.ColumnDefinitions.Add(column);

                RowDefinition row = new RowDefinition();
                window.chessboardGrid.RowDefinitions.Add(row);
            }
        }

    }
}
