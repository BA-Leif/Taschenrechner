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
using System.Windows.Shapes;
using System.Windows.Forms;

namespace Taschenrechner_GUI
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public List<string> Answers { get; set; }
        public Window1()
        {
            InitializeComponent();
            LoadingPath.Text = @"C:\Users\lerichsen\";
            SavingPath.Text = @"C:\Users\lerichsen\Desktop\Loesungen.txt";
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {

            if (ShowAnswers.IsChecked == true)
            {
                

                List<string> calcAnswers = new List<string>();
                string[] calcAnswersArr = ReadFile.ReturnAsString(LoadingPath.Text);

                foreach (string item in calcAnswersArr)
                {
                    calcAnswers.Add(item);
                }

                
                AnswersTextBlock.Text = "";
                foreach (string term in calcAnswers)
                {
                    AnswersTextBlock.Text = AnswersTextBlock.Text + ("\n" + term);
                }
            }
            else
            {
                ReadFile.SaveInFile(LoadingPath.Text, SavingPath.Text);
            }

        }

        private void FileSearch_Click(object sender, RoutedEventArgs e)
        {
            string filePath;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"C:\Users\lerichsen\Desktop\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|Al files (*.*) | *.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                //openFileDialog.ShowDialog();

                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    LoadingPath.Text = filePath;
                }
            }
        }
    }
}
