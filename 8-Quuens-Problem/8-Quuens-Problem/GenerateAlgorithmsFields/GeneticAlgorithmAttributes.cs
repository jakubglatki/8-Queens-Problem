using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _8_Quuens_Problem
{
    class GeneticAlgorithmAttributes : FullfilAlgorithmAttributes
    {
        TextBox sizeTB = new TextBox();
        TextBox elitismTB = new TextBox();
        TextBox crossoverTB = new TextBox();
        TextBox mutationTB = new TextBox();
        TextBox numberTB = new TextBox();
        public GeneticAlgorithmAttributes(MainWindow mainWindow)
        {
            window = mainWindow;
        }

        public override void FillAlgorithmFields()
        {
            window.algorithmAtributesPanel.Children.Clear();
            AlgorithmsAttributes algorithmAttributes = new AlgorithmsAttributes(window);
            algorithmAttributes.GenerateNewField(this.GetTextBlockText("Size of single generation"), sizeTB);
            algorithmAttributes.GenerateNewField(this.GetTextBlockText("Percentage of elitism (0-100)"), elitismTB);
            algorithmAttributes.GenerateNewField(this.GetTextBlockText("Crossover probability (0-100)"), crossoverTB);
            algorithmAttributes.GenerateNewField(this.GetTextBlockText("Mutation probability (0-100)"), mutationTB);
            algorithmAttributes.GenerateNewField(this.GetTextBlockText("Number of generations"), numberTB);
        }
    }
}
