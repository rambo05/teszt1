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
using static Tesztv2.MainWindow;
using System.IO;

namespace Tesztv2
{
    /// <summary>
    /// Interaction logic for Regiz.xaml
    /// </summary>
    public partial class Regiz : Window
    {
        public struct adat
        {
            public string nv;
            public string js;
            public int win;
            public int los;
        }
        public adat[] Bevesz(string ut)
        {
            string[] t = File.ReadAllLines(ut);
            adat[] tt = new adat[t.Length];
            for (int i = 0; i < tt.Length; i++)
            {
                string[] ttt = t[i].Split(';');
                tt[i].nv = ttt[0];
                tt[i].js = ttt[1];
                tt[i].win = int.Parse(ttt[2]);
                tt[i].los = int.Parse(ttt[3]);
            }
            return tt;
        }

        public void Vane()
        {
            if (!File.Exists("save.txt"))
            {
                File.Create("save.txt");
            }
        }

        public Regiz()
        {
            InitializeComponent();
            Vane();
        }

        private void quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow maine = new MainWindow();
            maine.Show();
        }

        private void regg_Click(object sender, RoutedEventArgs e)
        {
            adat[] t = Bevesz("save.txt");
            string n = nam.Text;
            string p = pwb.Text;
            bool b = false;
            for (int i = 0; i < t.Length; i++)
            {
                if (n == t[i].nv)
                {
                    b = true;
                }
            }
            if (b)
            {
                MessageBox.Show("Már van ilyen felhasználó!");
                nam.Clear();
                pwb.Clear();
            }
            else
            {
                MessageBox.Show("Sikeres regisztráció!");
                File.AppendAllText("save.txt", n + ";" + p + ";" + "0;0\n");                
            }
        }
    }
}
