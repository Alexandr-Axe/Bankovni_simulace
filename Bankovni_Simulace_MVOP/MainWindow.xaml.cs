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

namespace Bankovni_Simulace_MVOP
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //public List<Ucet> NUcet = new List<Ucet>();
        public List<Sporici> SUcet = new List<Sporici>();
        public List<Studentsky> StUcet = new List<Studentsky>();
        public List<Kreditni> KUcet = new List<Kreditni>();
        VytvoritUcet VU = new VytvoritUcet();
        private void ShowBAccount_Click(object sender, RoutedEventArgs e)
        {
            MojeUcty MU = new MojeUcty();
            MU.Show();
            Close();
        }

        private void CreateDeposit_Click(object sender, RoutedEventArgs e)
        {
            VU.Show();
            Close();
        }
    }
   
}
