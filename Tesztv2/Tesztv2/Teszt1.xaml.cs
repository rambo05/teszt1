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

namespace Tesztv2
{
    /// <summary>
    /// Interaction logic for Teszt1.xaml
    /// </summary>
    public partial class Teszt1 : Window
    {
        public int gval = -1;
        public int win = 0;
        public int los = 0;
        public string fe;
        
        public Teszt1()
        {
            InitializeComponent();
            fe=MainWindow.felh;
            neves.Text = "Szia " + fe + "! Mehet a játék?";
        }

        private void quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void go_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            int gtipp=r.Next(0, 4);
            for (int i = 0; i < 3; i++)
            {
                int szam = r.Next(1, 11);
                szamok.Items.Add(szam);
                if (i == gtipp)
                    gval = szam;
            }
            tipp.IsEnabled = true;
            szamok.IsEnabled = true;            
        }

        private void tipp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Amire gondoltam: " + gval);
            int tp = Convert.ToInt32(szamok.Text);
            if (tp == gval)
            {
                win++;
                ere.Text = "Nyertél!\nEddig nyertél: " + win + "x\nVesztettél: " + los + "x";
            }
            else
            {
                los++;
                ere.Text = "Vesztettél!\nEddig nyertél: " + win + "x\nVesztettél: " + los + "x";
            }
            tipp.IsEnabled = false;
            szamok.IsEnabled = false;
            szamok.Items.Clear();
        }
    }
}
