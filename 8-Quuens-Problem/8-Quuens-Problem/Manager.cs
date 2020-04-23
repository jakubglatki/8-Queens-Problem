using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace _8_Quuens_Problem
{

    class Manager
    {
        static private MainWindow window;


        public Manager(MainWindow mainWindow)
        {
            window = mainWindow;
        }

        //This method unchecks all CheckBoxes beside the one that was clicked
        public void UncheckBoxes(ToggleButton toggleButton)
        {
            window.localBeamSearchBox.IsChecked = false;
            window.hillClimbingBox.IsChecked = false;
            window.simulatedAnnealingBox.IsChecked = false;
            window.geneticAlgorithmBox.IsChecked = false;
            toggleButton.IsChecked = true;
        }

        public void AddBoardSizesToChooseList()
        {
            for(int i=4; i<=12; i++)
            {
                string newItem = i + "x" + i;
                window.chooseBoardSizeBox.Items.Add(newItem);
            }
            window.chooseBoardSizeBox.SelectedItem = window.chooseBoardSizeBox.Items[0];
        }

        public int ChessboardSizeToInt()
        {
            string sSize = window.chooseBoardSizeBox.SelectedItem.ToString();
            sSize = sSize.Substring(0, sSize.IndexOf("x"));
            int result = Int32.Parse(sSize);
            return result;
        }

    }
}
