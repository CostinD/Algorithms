using System;
using System.Collections;
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
using System.IO;
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
            //Parse input array to int array
            int[] n = ParseInput(DataTextBox.Text);

            if (n != null)
            {
                //Display Feedback
                FeedbackLabel.Foreground = Brushes.Black;
                FeedbackLabel.Content = "Sorting...";
                //Sort int array
                Sort(ref n);
                //Reset Text
                DataTextBox.Text = "";

                //Display sorted array in DataTextBox
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < n.Length; i++)
                {
                    sb.Append(n[i]);
                    if (i != n.Length - 1)
                        sb.Append(",");
                }
                DataTextBox.Text = sb.ToString();

                //Feedback that it finished sorting.
                FeedbackLabel.Foreground = Brushes.Green;
                FeedbackLabel.Content = "Sorted!";
            }
        }
        //Chooses the proper algorithm based on the AlgorithmsComboBox.SelectedItem
        private void Sort(ref int[] n)
        {
            ComboBoxItem item = AlgorithmsComboBox.SelectedItem as ComboBoxItem;
            switch(item.Content.ToString())
            {
                case "Bubble Sort":
                    SortingAlgorithms.BubbleSort(ref n);
                    break;
                case "Insertion Sort":
                    SortingAlgorithms.InsertionSort(ref n);
                    break;
                case "Selection Sort":
                    SortingAlgorithms.SelectionSort(ref n);
                    break;
            }
        }
        //Parses data from DataTextBox
        int[] ParseInput(string input)
        {
            string[] s = DataTextBox.Text.Split(',');
            int[] n = new int[s.Length];
            for(int i = 0; i < s.Length; i++)
            {
                if (!int.TryParse(s[i], out n[i]))
                {
                    FeedbackLabel.Foreground = Brushes.Red;
                    FeedbackLabel.Content = "Invalid Data. Please double check.";
                    return null;
                }
            }
            return n;
        }
        //Brings up menu to browse a file to open
        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".txt";
            dlg.Filter = "TXT Files (*.txt)|*.txt";

            Nullable<bool> result = dlg.ShowDialog();

            if(result == true)
            {
                using(StreamReader sr  = new StreamReader(dlg.FileName))
                {
                    StringBuilder data = new StringBuilder();
                    data.Append(sr.ReadToEnd());
                    DataTextBox.Text = data.ToString();
                }
            }
        }

        //Generate random data
        private void RandomDataButton_Click(object sender, RoutedEventArgs e)
        {
            FeedbackLabel.Content = "Generating...";
            int count = 100;
            if (int.TryParse(DataCountTextBox.Text, out count))
                FeedbackLabel.Content = "Invalid Data. Please Double Check!";

            GenerateRandom(count);
            FeedbackLabel.Content = "Data Generated!";
        }

        //Generates random numbers as data.
        private void GenerateRandom(int count)
        {
            StringBuilder sb = new StringBuilder();
            DataTextBox.Text = "";
            Random rnd = new Random();
            for(int i = 0; i < count; i++)
            {
                sb.Append(rnd.Next(1000));
                if (i != count - 1)
                    sb.Append(",");
            }
            DataTextBox.Text = sb.ToString();
        }
    }
}
