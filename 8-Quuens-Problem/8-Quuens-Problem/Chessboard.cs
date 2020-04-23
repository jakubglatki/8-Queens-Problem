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
                        Image bright = new Image();
                        if (queensPlacement[j] != i)
                        {
                            bright.Source = new BitmapImage(new Uri("pack://application:,,,/8-Quuens-Problem;component/Resources/bright.png"));
                        }
                        else
                        {
                            bright.Source = new BitmapImage(new Uri("pack://application:,,,/8-Quuens-Problem;component/Resources/brightQ.png"));
                        }

                        Grid.SetColumn(bright, j);
                        Grid.SetRow(bright, i);
                        window.chessboardGrid.Children.Add(bright);
                    }
                    else
                    {
                        Image dark = new Image();
                        if (queensPlacement[j] != i)
                        {
                            dark.Source = new BitmapImage(new Uri("pack://application:,,,/8-Quuens-Problem;component/Resources/dark.png"));
                        }
                        else
                        {
                            dark.Source = new BitmapImage(new Uri("pack://application:,,,/8-Quuens-Problem;component/Resources/darkQ.png"));
                        }
                        Grid.SetColumn(dark, j);
                        Grid.SetRow(dark, i);
                        window.chessboardGrid.Children.Add(dark);
                    }
                }
            }
        }

        private void AddColumnsAndRowsToGrid()
        {
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
