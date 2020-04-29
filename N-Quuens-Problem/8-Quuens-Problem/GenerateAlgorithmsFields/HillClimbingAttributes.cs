
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
        private TextBox maxNumberTB; 


        public int GetMaxNumberTB()
        {
            return this.ConvertTextBoxToInt(maxNumberTB);
        }
        public HillClimbingAttributes(MainWindow mainWindow)
        {
            window = mainWindow;
        }


        override public void FillAlgorithmFields()
        {
            maxNumberTB = new TextBox();
            window.algorithmAtributesPanel.Children.Clear();
            AlgorithmsAttributes algorithmAttributes = new AlgorithmsAttributes(window);
            algorithmAttributes.GenerateNewField(this.GetTextBlockText("Maximum number of steps"), maxNumberTB);
        }

    }
}
