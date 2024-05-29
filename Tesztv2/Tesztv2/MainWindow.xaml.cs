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
using System.IO;

namespace Tesztv2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string felh;
        
        public struct adat {
            public string nv;
            public string js;
            public int win;
            public int los;
        }


        public MainWindow()
        {
            InitializeComponent();
            if (!File.Exists("save.txt"))
            {
                MessageBox.Show("Első játék! Nincs mentés! Kérlek regisztrálj!");
                Regiz ablak = new Regiz();
                ablak.Show();
                this.Close();
            }
        }

        public adat[] Bevesz(string ut)
        {
            string[] t=File.ReadAllLines(ut);
            adat[] tt = new adat[t.Length];
            for (int i = 0; i < tt.Length; i++)
            {
                string[] ttt = t[i].Split(';');
                tt[i].nv = ttt[0];
                tt[i].js = ttt[1];
                tt[i].win = int.Parse(ttt[2]);
                tt[i].los= int.Parse(ttt[3]);
            }
            return tt;
        } 


        private void login_Click(object sender, RoutedEventArgs e)
        {
            adat[] t = Bevesz("save.txt");
            string n = nam.Text;
            string p = pwb.Password;
            bool b = false;
            for (int i = 0; i < t.Length; i++)
            {
                if (n == t[i].nv && p == t[i].js)
                {
                    b = true;
                }
            }
            if (b)
            {
                MessageBox.Show("Sikeres bejelentkezés!");
                Teszt1 ablak = new Teszt1();
                felh = n;
                ablak.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sikertelen bejelentkezés!");
                nam.Clear();
                pwb.Clear();
            }
        }

        private void regi_Click(object sender, RoutedEventArgs e)
        {
            Regiz ablak = new Regiz();
            ablak.Show();
            this.Close();
        }

        private void quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
