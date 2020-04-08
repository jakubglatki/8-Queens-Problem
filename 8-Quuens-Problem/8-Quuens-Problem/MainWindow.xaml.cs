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
        public MainWindow()
        {
            manager = new Manager(this);
            InitializeComponent();

        }

        private void HillClimbingBox_Click(object sender, RoutedEventArgs e)
        {
            manager.UncheckBoxes(this.hillClimbingBox);
        }

        private void SimulatedAnnealingBox_Click(object sender, RoutedEventArgs e)
        {
            manager.UncheckBoxes(this.simulatedAnnealingBox);
        }

        private void LocalBeamSearchBox_Click(object sender, RoutedEventArgs e)
        {
            manager.UncheckBoxes(this.localBeamSearchBox);

        }

        private void GeneticAlgorithmBox_Click(object sender, RoutedEventArgs e)
        {
            manager.UncheckBoxes(this.geneticAlgorithmBox);

        }
    }
}
