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
using System.Data;
using System.Text.RegularExpressions;

namespace Inlämningsuppgift_1_WindowsProgrammering
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

        public string ValueHolder { get; set; }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            BoxValue.Text = "";
            BoxValue.FontSize = 42;
            BoxValue.TextAlignment = TextAlignment.Right;
            ValueHolder = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var lenght = sender.ToString().Length;
            BoxValue.Text += sender.ToString().Substring(lenght -1);
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            ValueHolder += BoxValue.Text;
            BoxValue.Text = "+";
        }

        private void ButtonSub_Click(object sender, RoutedEventArgs e)
        {
            ValueHolder += BoxValue.Text;
            BoxValue.Text = "-";
        }

        private void ButtonMulti_Click(object sender, RoutedEventArgs e)
        {
            ValueHolder += BoxValue.Text;
            BoxValue.Text = "*";
        }

        private void ButtonDevided_Click(object sender, RoutedEventArgs e)
        {
            ValueHolder += BoxValue.Text;
            BoxValue.Text = "/";
        }

        private void ButtonEquals_Click(object sender, RoutedEventArgs e)
        {
            ValueHolder += BoxValue.Text;

            var value = new DataTable().Compute(ValueHolder, null).ToString();
            if(value == "∞")
            {
                value = "Oobs, det går ej att dela på noll!";
                BoxValue.FontSize = 20;
                BoxValue.TextAlignment = TextAlignment.Left;
            }

            BoxValue.Text = value;
            ValueHolder = ""; //För att om vi lägger ett värde så kommer den att skriva ut fel tal
        }
    }
}
