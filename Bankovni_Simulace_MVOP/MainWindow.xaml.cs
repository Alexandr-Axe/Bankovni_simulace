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
            LoadMainWindow();
        }
        /*
        public static Sporici[] SporiciUcty = new Sporici[4];
        public static Kreditni[] KreditniUcty = new Kreditni[4];
        public static Studentsky[] StudentskySporici = new Studentsky[4];
        */
        List<Ucet> Ucty = new List<Ucet>();
        bool Zapsano = false;

        private void CreateDeposit_Click(object sender, RoutedEventArgs e)
        {
            LoadVytvoritUcet();
            // VU.Show();
            // Close();
        }
        #region
        void LoadMainWindow()
        {
            ZadejteNazev.Visibility = Visibility.Hidden;
            jmeno.Visibility = Visibility.Hidden;
            zkouska.Visibility = Visibility.Visible;
            UkazUcty.Visibility = Visibility.Visible;
            ZadejteZustatek.Visibility = Visibility.Hidden;
            zustatek.Visibility = Visibility.Hidden;
            VytvorUcet.Visibility = Visibility.Hidden;
            MoznostiUctu.Visibility = Visibility.Hidden;
            VypsaneUcty.Visibility = Visibility.Hidden;
            JdiZpet.Visibility = Visibility.Hidden;
        }
        void LoadVytvoritUcet()
        {
            ZadejteNazev.Visibility = Visibility.Visible;
            jmeno.Visibility = Visibility.Visible;
            ZadejteZustatek.Visibility = Visibility.Visible;
            zustatek.Visibility = Visibility.Visible;
            UkazUcty.Visibility = Visibility.Hidden;
            zkouska.Visibility = Visibility.Hidden;
            VytvorUcet.Visibility = Visibility.Visible;
            MoznostiUctu.Visibility = Visibility.Visible;
            VypsaneUcty.Visibility = Visibility.Hidden;
            JdiZpet.Visibility = Visibility.Hidden;
        }
        void LoadUkazUcty()
        {
            ZadejteNazev.Visibility = Visibility.Hidden;
            jmeno.Visibility = Visibility.Hidden;
            ZadejteZustatek.Visibility = Visibility.Hidden;
            zustatek.Visibility = Visibility.Hidden;
            UkazUcty.Visibility = Visibility.Hidden;
            zkouska.Visibility = Visibility.Hidden;
            VytvorUcet.Visibility = Visibility.Hidden;
            MoznostiUctu.Visibility = Visibility.Hidden;
            VypsaneUcty.Visibility = Visibility.Visible;
            JdiZpet.Visibility = Visibility.Visible;
        }
        #endregion

        private void VytvorUcet_Click(object sender, RoutedEventArgs e)
        {
            switch (MoznostiUctu.SelectionBoxItem.ToString())
            {
                case "Spořící":
                    Ucty.Add(new Sporici(jmeno.Text, Convert.ToDecimal(zustatek.Text), 2));
                    break;
                case "Studentský":
                    Ucty.Add(new Studentsky(jmeno.Text, Convert.ToDecimal(zustatek.Text), 0.1, 3000));
                    break;
                case "Kreditní":
                    Ucty.Add(new Kreditni(jmeno.Text, Convert.ToDecimal(zustatek.Text)));
                    break;
            }
            foreach (Ucet Item in Ucty)
            {
                VypsaneUcty.Items.Add(Item.Nazev.ToString());
            }
            LoadMainWindow();
        }

        private void UkazUcty_Click(object sender, RoutedEventArgs e)
        {
            LoadUkazUcty();
        }

        private void VypsaneUcty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Ucet Item in Ucty)
            {
                if (Item.Nazev == VypsaneUcty.SelectedItem.ToString())
                {
                    MessageBox.Show(Item.ToString());
                }
            }
        }

        private void JdiZpet_Click(object sender, RoutedEventArgs e)
        {
            LoadMainWindow();
        }
    }
}
