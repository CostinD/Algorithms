using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraphicSortAlgorithmsCollection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            string[] input = DataTextBox.Text.Split(',');
            
            int[] n = new int[input.Length];
            for (int i = 0; i < input.Length; i++ )
            {
                n[i] = int.Parse(input[i]);
            }
            SortingAlgorithms.InsertionSort(ref n);
   
            DataTextBox.Text = "";

            for(int i = 0; i < n.Length; i++)
            {
                DataTextBox.Text += n[i];
                if (i != n.Length - 1)
                    DataTextBox.Text += ",";
            }
        }
    }
}
