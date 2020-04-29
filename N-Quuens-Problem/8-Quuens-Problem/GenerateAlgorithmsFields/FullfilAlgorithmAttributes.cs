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

        //all the non-digitis symbols are deleted in case of something going wrong
        private string CleanStringOfNonDigits(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            string cleaned = new string(s.Where(char.IsDigit).ToArray());
            if (cleaned == ""){ return "0"; }
            return cleaned;
        }

        //Text that will be shown saying what input will be requaired from the user
        protected TextBlock GetTextBlockText(string text)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            return textBlock;
        }

        protected int ConvertTextBoxToInt(System.Windows.Controls.TextBox textBox)
        {
            if (textBox.Text != "")
            {
                string s = CleanStringOfNonDigits(textBox.Text);
                int x = Int32.Parse(s);
                return x;
            }
            else return 0;
        }

        //Method calling AlgorithmAttributes class to fullfil the fields, that will be shown to the user
        public abstract void FillAlgorithmFields();
    }
}
