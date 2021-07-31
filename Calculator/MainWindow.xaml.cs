using System;
using System.Data;
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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement element in MainGrid.Children)
            {
                if (element is Button)
                {
                    ((Button) element).Click += ButtonClick;
                }
            }
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button) e.OriginalSource).Content;
            
            if (str == "CE" || str == "C")
            {
                Label.Text = "";
            }
            else if (str == "⌫")
            {
                if (Label.Text == "")
                {
                    str = "";
                }
                else Label.Text = Label.Text.Substring(0, Label.Text.Length - 1);
            }
            else if (str == "%")
            {
                if (Label.Text == "")
                {
                    str = "";
                }
                else Label.Text = (Double.Parse(Label.Text) * 0.01).ToString();
            }
            else if (str == "1/x")
            {
                if (Label.Text == "")
                {
                    str = "";
                }
                else Label.Text = (1 / Double.Parse(Label.Text)).ToString();
            }
            else if (str == "x²")
            {
                if (Label.Text == "")
                {
                    str = "";
                }
                else Label.Text = (Double.Parse(Label.Text) * Double.Parse(Label.Text)).ToString();
            }
            else if (str == "√x")
            {
                if (Label.Text == "")
                {
                    str = "";
                }
                else Label.Text = (Math.Sqrt(Double.Parse(Label.Text))).ToString();
            }
            else if (str == ",")
            {
                if (Label.Text == "")
                {
                    str = "";
                }
                else Label.Text += ".";
            }
            else if (str == "±")
            {
                if (Label.Text == "")
                {
                    str = "";
                }
                else Label.Text = (-Double.Parse(Label.Text)).ToString();
            }
            else if (str == "=")
            {
                string value = new DataTable().Compute(Label.Text, null).ToString();
                Label.Text = value;
            }
            else
            {
                Label.Text += str;
            }
        }
    }
}
