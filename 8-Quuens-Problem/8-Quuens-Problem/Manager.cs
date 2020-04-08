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
            //toggleButton.IsChecked = true;
        }
    }
}
