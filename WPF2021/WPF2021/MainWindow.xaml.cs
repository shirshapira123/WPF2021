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

namespace WPF2021
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        string action = null;
        double solution;
        bool start = true;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click_0(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            screen.Text += bt.Content.ToString();
            screen_1.Text += bt.Content.ToString();
        }
        private void Button_Click_C(object sender, RoutedEventArgs e)
        {
            screen.Text = "";
            screen_1.Text = "";
        }
        private void Button_Click_CE(object sender, RoutedEventArgs e)
        {
            if (screen.Text.Equals("Error"))
                screen.Text = "";
            if (screen_1.Text.Equals("Error"))
                screen_1.Text = "";
            if (screen.Text != "")
            {
                string txt = screen.Text;
                screen.Text = txt.Remove(txt.Length - 1);
            }
            if (screen_1.Text != "")
            {
                string txt_1 = screen_1.Text;
                screen_1.Text = txt_1.Remove(txt_1.Length - 1);
            }
        }
        private void Button_Click_Action(object sender, RoutedEventArgs e)
        {
            try
            {
                double number = double.Parse(screen.Text);
                if (start)
                    solution = number;
                else
                {
                    if (action.Equals("/"))
                        solution /= number;
                    else if (action.Equals("+"))
                        solution += number;
                    else if (action.Equals("x"))
                        solution *= number;
                    else if (action.Equals("-"))
                        solution -= number;
                }
                start = false;
                Button bt = (Button)sender;
                screen_1.Text += bt.Content.ToString();
                action = bt.Content.ToString();
                screen.Text = "";
            }
            catch
            {
                screen.Text = "Error";
                screen_1.Text = "Error";
            }
        }
        private void Button_Click_Equal(object sender, RoutedEventArgs e)
        {
            try
            {
                double number = double.Parse(screen.Text);
                if (start)
                    solution = number;
                else
                {
                    if (action.Equals("/"))
                        solution /= number;
                    else if (action.Equals("+"))
                        solution += number;
                    else if (action.Equals("x"))
                        solution *= number;
                    else if (action.Equals("-"))
                        solution -= number;
                }
                start = true;
                screen.Text = solution.ToString();
                screen_1.Text = solution.ToString();
            }
            catch
            {
                screen.Text = "Error";
                screen_1.Text = "Error";

            }
        }
    }
}