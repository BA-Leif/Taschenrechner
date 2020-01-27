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
using ClassLibrary1;

namespace Taschenrechner_GUI
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double X = 0;
        double Y = 0;
        double Answer = 0;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Test_Click(object sender, RoutedEventArgs e)
        {
            if (DefineXY.IsChecked == true)
                DefineXY.IsChecked = false;
            else
                DefineXY.IsChecked = true;
        }


        #region Digit_Buttons
        private void Digit_1_Click(object sender, RoutedEventArgs e)
        {
            TermDisplay.AppendText("1");
        }

        private void Digit_2_Click(object sender, RoutedEventArgs e)
        {
            TermDisplay.AppendText("2");
        }

        private void Digit_3_Click(object sender, RoutedEventArgs e)
        {
            TermDisplay.AppendText("3");
        }

        private void Digit_4_Click(object sender, RoutedEventArgs e)
        {
            TermDisplay.AppendText("4");
        }

        private void Digit_5_Click(object sender, RoutedEventArgs e)
        {
            TermDisplay.AppendText("5");
        }

        private void Digit_6_Click(object sender, RoutedEventArgs e)
        {
            TermDisplay.AppendText("6");
        }

        private void Digit_9_Click(object sender, RoutedEventArgs e)
        {
            TermDisplay.AppendText("9");
        }

        private void Digit_8_Click(object sender, RoutedEventArgs e)
        {
            TermDisplay.AppendText("8");
        }

        private void Digit_7_Click(object sender, RoutedEventArgs e)
        {
            TermDisplay.AppendText("7");
        }

        private void Digit_0_Click(object sender, RoutedEventArgs e)
        {
            TermDisplay.AppendText("0");
        }
        private void Negative_Click(object sender, RoutedEventArgs e)
        {
            TermDisplay.AppendText("-");
        }
        private void Decimalpoint_Click(object sender, RoutedEventArgs e)
        {
            TermDisplay.AppendText(",");
        }
        #endregion
        #region Operator_Buttons
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            TermDisplay.AppendText("+");
        }

        private void Subtract_Click(object sender, RoutedEventArgs e)
        {
            TermDisplay.AppendText("-");
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            TermDisplay.AppendText("*");
        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            TermDisplay.AppendText("/");
        }

        private void PowerrOf_Click(object sender, RoutedEventArgs e)
        {
            TermDisplay.AppendText("^");
        }

        private void RootOf_Click(object sender, RoutedEventArgs e)
        {
            TermDisplay.AppendText("V");
        }

        private void LeftBracket_Click(object sender, RoutedEventArgs e)
        {
            TermDisplay.AppendText("(");
        }

        private void RightBracket_Click(object sender, RoutedEventArgs e)
        {
            TermDisplay.AppendText(")");
        }

        private void Faculty_Click(object sender, RoutedEventArgs e)
        {
            TermDisplay.AppendText("!");
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            Answer = (ClassLibrary1.ParserClass.Start(TermDisplay.Text.ToLower()));
            ResultDisplay.Text = "= " + Answer;
        }

        private void mod_Click(object sender, RoutedEventArgs e)
        {
            TermDisplay.AppendText("%");
        }



        #endregion
        #region Other
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            TermDisplay.Text = "";
        }
        private void Variable_X_Click(object sender, RoutedEventArgs e)
        {
            if (DefineXY.IsChecked == true)
            {
                X = Answer;
                X_Text.Text = "X = " + X.ToString();
            }
            else
            {
                TermDisplay.AppendText(X.ToString());
            }
        }

        private void Variable_Y_Click(object sender, RoutedEventArgs e)
        {
            if (DefineXY.IsChecked == true)
            {
                Y = Answer;
                Y_Text.Text = "X = " + Y.ToString();
            }
            else
            {
                TermDisplay.AppendText(Y.ToString());
            }
        }
        #endregion

        #region TopMenu
        private void Datei_Beenden_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ReadFile_Click(object sender, RoutedEventArgs e)
        {

            Window1 answers = new Window1();
            answers.Show();
        }
        
        private void WriteFile_Click(object sender, RoutedEventArgs e)
        {
            
            ResultDisplay.Text = "Datei gespeichert.";
        }

        #endregion


    }
}