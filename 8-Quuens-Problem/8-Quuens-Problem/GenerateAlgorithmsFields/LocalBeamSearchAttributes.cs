using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _8_Quuens_Problem
{
    class LocalBeamSearchAttributes : FullfilAlgorithmAttributes
    {
        TextBox numberTB;
        TextBox maxNumberTB;
        public LocalBeamSearchAttributes(MainWindow mainWindow)
        {
            window = mainWindow;
        }

        public override void FillAlgorithmFields()
        {
            numberTB = new TextBox();
            maxNumberTB = new TextBox();
            window.algorithmAtributesPanel.Children.Clear();
            AlgorithmsAttributes algorithmAttributes = new AlgorithmsAttributes(window);
            algorithmAttributes.GenerateNewField(this.GetTextBlockText("Number of states"), numberTB);
            algorithmAttributes.GenerateNewField(this.GetTextBlockText("Maximum number of steps"), maxNumberTB);
        }
    }
}
