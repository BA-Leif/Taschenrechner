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

namespace Taschenrechner_Oberfläche
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
            TermDisplay.AppendText("7");
        }

        private void Digit_8_Click(object sender, RoutedEventArgs e)
        {
            TermDisplay.AppendText("8");
        }

        private void Digit_7_Click(object sender, RoutedEventArgs e)
        {
            TermDisplay.AppendText("9");
        }

        private void Digit_0_Click(object sender, RoutedEventArgs e)
        {
            TermDisplay.AppendText("0");
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
            ResultDisplay.Text = "= " + Parser.Start(TermDisplay.Text.ToLower());
        }

        private void Equal_Copy_Click(object sender, RoutedEventArgs e)
        {
            TermDisplay.Text = "";
        }

        #endregion


    }
}
