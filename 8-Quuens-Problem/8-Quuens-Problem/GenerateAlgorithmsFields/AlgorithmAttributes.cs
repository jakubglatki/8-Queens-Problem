using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace _8_Quuens_Problem
{
    public class AlgorithmsAttributes
    {
        static protected MainWindow window;
        public AlgorithmsAttributes(MainWindow mainWindow) 
        {
            window = mainWindow;
        }

        private void SetTextBlockAttributtes(TextBlock textBlock)
        {
            textBlock.FontSize = 14;
        }

        private void SetTextBoxAttributtes(TextBox textBox)
        {
            textBox.Margin = new System.Windows.Thickness(10, 0, 0, 0);
            textBox.Width = 35;
            textBox.HorizontalAlignment = HorizontalAlignment.Right;
        }

        //Adding new stack panel contains of message about what should be putted in and field for putting in values
        public void GenerateNewField(TextBlock textBlock, TextBox textBox)
        {
            DockPanel dockPanel = new DockPanel();
            dockPanel.Margin = new Thickness(0, 10, 0, 0);
            this.SetTextBlockAttributtes(textBlock);
            this.SetTextBoxAttributtes(textBox);
            dockPanel.Children.Add(textBlock);
            dockPanel.Children.Add(textBox);
            window.algorithmAtributesPanel.Children.Add(dockPanel);
        }
    }
}
