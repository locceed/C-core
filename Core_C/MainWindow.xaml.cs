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

namespace Core_C
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        double a1 = 0;
        double a2 = 0;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //fraction_b a = new fraction_b(Convert.ToDouble(ta1.Text),Convert.ToDouble(tb1.Text));
            listBox.Items.Clear();
            listBox.Items.Add(f1(Convert.ToDouble(textBox.Text), Convert.ToDouble(textBox1.Text)));
        }
        
        private string f1(double i1,double i2)//更相减损术
        {
            a1 = i1;
            a2 = i2;
            do
            {
                if (a1 > a2) { a1 = a1 - a2; }
                else if (a1 < a2) { a2 = a2 - a1; }
                else { break; }

            }
            while (true);
            return (i1 / a1).ToString() + "" + (i2 / a1).ToString();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();
        }
    }
}
