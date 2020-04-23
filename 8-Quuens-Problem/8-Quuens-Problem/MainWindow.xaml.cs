using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _8_Quuens_Problem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static private Manager manager;

        private HillClimbingAttributes hillClimbingAttributes;
        private SimulatedAnnealingAttributes simulatedAnnealingAttributes;
        private LocalBeamSearchAttributes localBeamSearchAttributes;
        private GeneticAlgorithmAttributes geneticAlgorithmAttributes;

        private Chessboard chessboard;
        public MainWindow()
        {
            manager = new Manager(this);
            hillClimbingAttributes = new HillClimbingAttributes(this);
            simulatedAnnealingAttributes = new SimulatedAnnealingAttributes(this);
            localBeamSearchAttributes = new LocalBeamSearchAttributes(this);
            geneticAlgorithmAttributes = new GeneticAlgorithmAttributes(this);

            InitializeComponent();
            manager.AddBoardSizesToChooseList();
            chessboard = new Chessboard(manager.ChessboardSizeToInt(),this);
        }

        private void HillClimbingBox_Click(object sender, RoutedEventArgs e)
        {
            manager.UncheckBoxes(this.hillClimbingBox);
            hillClimbingAttributes.FillAlgorithmFields();
        }

        private void SimulatedAnnealingBox_Click(object sender, RoutedEventArgs e)
        {
            manager.UncheckBoxes(this.simulatedAnnealingBox);
            simulatedAnnealingAttributes.FillAlgorithmFields();
        }

        private void LocalBeamSearchBox_Click(object sender, RoutedEventArgs e)
        {
            manager.UncheckBoxes(this.localBeamSearchBox);
            localBeamSearchAttributes.FillAlgorithmFields();
        }

        private void GeneticAlgorithmBox_Click(object sender, RoutedEventArgs e)
        {
            manager.UncheckBoxes(this.geneticAlgorithmBox);
            geneticAlgorithmAttributes.FillAlgorithmFields();
        }


        private void ChessboardSizeChanged(object sender, EventArgs e)
        {
            this.chessboardGrid.Children.Clear();
            this.chessboardGrid.RowDefinitions.Clear();
            this.chessboardGrid.ColumnDefinitions.Clear();
            chessboard = new Chessboard(manager.ChessboardSizeToInt(), this);

        }
    }
}
