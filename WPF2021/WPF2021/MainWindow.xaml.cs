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
    public partial class MainWindow : Window
    {
        string action1 = null;
        string action2 = null;
        double prev = 0;
        double next = 0;
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
            start = true;
        }
        private void Button_Click_CE(object sender, RoutedEventArgs e)
        {
            try
            {
                string txt = screen.Text;
                screen.Text = "";
                string txt_1 = screen_1.Text;
                screen_1.Text = txt_1.Remove(txt_1.Length - txt.Length);
            }
            catch
            {
                screen.Text = "";
                screen_1.Text = "";
                start = true;
            }
        }
        private void Button_Click_BS(object sender, RoutedEventArgs e)
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
                string txt_1 = screen_1.Text[screen_1.Text.Length-1].ToString();
                if(txt_1.Equals("+") || txt_1.Equals("/") || txt_1.Equals("x") || txt_1.Equals("-"))
                {
                    screen.Text = "";
                    screen_1.Text = "";
                    start = true;
                }
                else
                    screen_1.Text = screen_1.Text.Remove(screen_1.Text.Length - 1);
            }
        }
        private void Button_Click_Action(object sender, RoutedEventArgs e)
        {
            try
            {
                double number = double.Parse(screen.Text);
                if (start)
                {
                    next = number;
                    start = false;
                    Button bt = (Button)sender;
                    screen_1.Text += bt.Content.ToString();
                    screen.Text = "";
                    action2 = bt.Content.ToString();
                }
                else
                {
                    Button bt = (Button)sender;
                    screen_1.Text += bt.Content.ToString();
                    screen.Text = "";

                    action1 = action2;
                    action2 = bt.Content.ToString();

                    if (action2.Equals("+") || action2.Equals("-"))
                    {
                        if (action1.Equals("/"))
                        {
                            next /= number;
                            next += prev;
                            prev = 0;
                        }
                        else if (action1.Equals("+"))
                            next += number;
                        else if (action1.Equals("x"))
                        {
                            next *= number;
                            next += prev;
                            prev = 0;
                        }
                        else if (action1.Equals("-"))
                            next -= number;
                    }
                    else if (action2.Equals("x") || action2.Equals("/"))
                    {
                        if (action1.Equals("/"))
                            next /= number;
                        else if (action1.Equals("+"))
                        {
                            prev = next;
                            next = 0;
                            next += number;
                        }
                        else if (action1.Equals("x"))
                        {
                            next *= number;
                        }
                        else if (action1.Equals("-"))
                        {
                            prev = next;
                            next = 0;
                            next -= number;
                        }
                    }
                }
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
                    next = number;
                else
                {
                    action1 = action2;
                    if (action1.Equals("/"))
                    {
                        next /= number;
                        next += prev;
                    }
                    else if (action1.Equals("+"))
                        next += number;
                    else if (action1.Equals("x"))
                    {
                        next *= number;
                        next += prev;
                    }
                    else if (action1.Equals("-"))
                        next -= number;
                }
                screen.Text = next.ToString();
                screen_1.Text = next.ToString();
                start = true;
                next = 0;
                prev = 0;
            }
            catch
            {
                screen.Text = "Error";
                screen_1.Text = "Error";
            }
        }
    }
}