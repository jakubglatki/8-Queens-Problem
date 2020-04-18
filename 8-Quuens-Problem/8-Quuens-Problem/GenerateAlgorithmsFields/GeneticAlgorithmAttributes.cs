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
        private TextBox sizeTB;
        private TextBox elitismTB;
        private TextBox crossoverTB;
        private TextBox mutationTB;
        private TextBox numberTB;
        public GeneticAlgorithmAttributes(MainWindow mainWindow)
        {
            window = mainWindow;
        }

        public int GetSize()
        {
            return this.ConvertTextBoxToInt(sizeTB);
        }

        public int GetElitism()
        {
            return this.ConvertTextBoxToInt(elitismTB);
        }

        public int GetCrossover()
        {
            return this.ConvertTextBoxToInt(crossoverTB);
        }

        public int GetMutation()
        {
            return this.ConvertTextBoxToInt(mutationTB);
        }

        public int GetNumber()
        {
            return this.ConvertTextBoxToInt(numberTB);
        }


        public override void FillAlgorithmFields()
        {
            sizeTB = new TextBox();
            elitismTB = new TextBox();
            crossoverTB = new TextBox();
            mutationTB = new TextBox();
            numberTB = new TextBox();
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
