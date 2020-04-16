
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _8_Quuens_Problem
{
    public class HillClimbingAttributes : FullfilAlgorithmAttributes
    {

        TextBox maxNumberTB = new TextBox();
        public HillClimbingAttributes(MainWindow mainWindow)
        {
            window = mainWindow;
        }


        override public void FillAlgorithmFields()
        {
            window.algorithmAtributesPanel.Children.Clear();
            AlgorithmsAttributes algorithmAttributes = new AlgorithmsAttributes(window);
            algorithmAttributes.GenerateNewField(this.GetTextBlockText("Maximum number of steps"), maxNumberTB);
        }

    }
}
