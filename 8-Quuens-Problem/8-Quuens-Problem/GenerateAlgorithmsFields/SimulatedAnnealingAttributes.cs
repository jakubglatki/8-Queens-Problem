using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _8_Quuens_Problem
{
    class SimulatedAnnealingAttributes : FullfilAlgorithmAttributes
    {
        TextBox startingTB = new TextBox();
        TextBox coolingTB = new TextBox();
        public SimulatedAnnealingAttributes(MainWindow mainWindow)
        {
            window = mainWindow;
        }

        public override void FillAlgorithmFields()
        {
            window.algorithmAtributesPanel.Children.Clear();
            AlgorithmsAttributes algorithmAttributes = new AlgorithmsAttributes(window);
            algorithmAttributes.GenerateNewField(this.GetTextBlockText("Starting temperature"), startingTB);
            algorithmAttributes.GenerateNewField(this.GetTextBlockText("Cooling factor"), coolingTB);
        }
    }
}
