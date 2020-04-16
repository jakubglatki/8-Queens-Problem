using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _8_Quuens_Problem
{
    public abstract class FullfilAlgorithmAttributes  //Interface for layout of individual choosen algorithms
    {
        static protected MainWindow window;


        //Text that will be shown saying what input will be requaired from the user
        protected TextBlock GetTextBlockText(string text)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            return textBlock;
        }

        //Method calling AlgorithmAttributes class to fullfil the fields, that will be shown to the user
        public abstract void FillAlgorithmFields();
    }
}
