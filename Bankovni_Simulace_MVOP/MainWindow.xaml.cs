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
using System.Timers;

using System.Text.RegularExpressions;
using System.Windows.Threading; //REGEX

namespace Bankovni_Simulace_MVOP
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DateTime CasProgramu = DateTime.Now;
        public MainWindow()
        {
            InitializeComponent();
            LoadMainWindow();
            ZrychlenyCas(CasProgramu);
        }

        public bool placeno;
        List<Ucet> Ucty = new List<Ucet>();

        private void CreateDeposit_Click(object sender, RoutedEventArgs e)
        {
            LoadVytvoritUcet();
        } //Vytvoření účtu
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
            VratitSeZpet.Visibility = Visibility.Hidden;
            Kalendar.Visibility = Visibility.Hidden;
            PlusMesic.Visibility = Visibility.Hidden;

            jmeno.Text = "";
            zustatek.Text = "";
            MoznostiUctu.SelectedValue = null;
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
            VratitSeZpet.Visibility = Visibility.Visible;
            Kalendar.Visibility = Visibility.Hidden;
            PlusMesic.Visibility = Visibility.Hidden;
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
            VratitSeZpet.Visibility = Visibility.Hidden;
            Kalendar.Visibility = Visibility.Visible;
            PlusMesic.Visibility = Visibility.Visible;
        }
        #endregion
        //Loading oken

        private void VytvorUcet_Click(object sender, RoutedEventArgs e)
        {
            if (zustatek.Text == "") zustatek.Text = "0";
            if (MoznostiUctu.SelectedValue != null)
            {
                if (jmeno.Text != "")
                {
                        switch (MoznostiUctu.SelectionBoxItem.ToString())
                        {
                            case "Spořící":
                                Ucty.Add(new Sporici(jmeno.Text, Convert.ToDouble(zustatek.Text), 2, CasProgramu));
                                break;
                            case "Studentský":
                                Ucty.Add(new Studentsky(jmeno.Text, Convert.ToDouble(zustatek.Text), 0.1, 3000, CasProgramu));
                                break;
                            case "Kreditní":
                                Ucty.Add(new Kreditni(jmeno.Text, Convert.ToDouble(zustatek.Text), 20, CasProgramu));
                                break;
                        }
                        foreach (Ucet Item in Ucty)
                        {
                            VypsaneUcty.Items.Add(Item.Nazev.ToString());
                        }
                        LoadMainWindow();
                }
                else MessageBox.Show("Zadejte název účtu", "CHYBA", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else MessageBox.Show("Vyberte typ účtu, který si chcete založit", "CHYBA", MessageBoxButton.OK, MessageBoxImage.Information);
        } //Vytvoření účtu


        private void UbehlMesic(List<Ucet> ucty)
        {
            
            try
            {
                foreach (Sporici Item in ucty)
            {
                TimeSpan rozdil = CasProgramu - Item.DatumZalozeni;
                if (rozdil == TimeSpan.FromDays(31))
                {
                    Item.Zustatek *= Item.Urok / 100 + 1;
                }
            }
            }
            catch(Exception)
            {
            }

            try
            {
                foreach (Studentsky Item in ucty)
                {
                    TimeSpan rozdil = CasProgramu - Item.DatumZalozeni;
                    if (rozdil == TimeSpan.FromDays(31))
                    {
                        Item.Zustatek *= Item.Urok / 100 + 1;
                    }
                }
            }
            catch (Exception )
            {
                
            }

            try
            {
                foreach (Kreditni Item in ucty)
                {
                    TimeSpan rozdil = CasProgramu - Item.DatumZalozeni;

                    if(rozdil == TimeSpan.FromDays(31) && placeno == true)
                    {
                        Item.ChybiSplatit *= Item.Urok / 100 + 1;
                    }

                }
            }
            catch (Exception )
            {
                
            }
            
        }
        private void UkazUcty_Click(object sender, RoutedEventArgs e)
        {
            LoadUkazUcty();
            
        } //Načtení okna, kde se zobrazují účty

        private void VypsaneUcty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Ucet Item in Ucty)
            {
                if (Item.Nazev == VypsaneUcty.SelectedItem.ToString())
                {
                    MessageBox.Show(Item.ToString());
                }
            }
        } //Zobrazení podrobností o účtu

        private void JdiZpet_Click(object sender, RoutedEventArgs e)
        {
            LoadMainWindow();
        } //Načtení hlavního okna

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        } //Vklad pouze číselný

        private void Kalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PlusMesic_Click(object sender, RoutedEventArgs e)
        {
           CasProgramu = CasProgramu.AddMonths(1);
        }
        public void ZrychlenyCas(DateTime casProgramu)
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0,0,1);
            dispatcherTimer.Start();


            void dispatcherTimer_Tick(object sender, EventArgs e)
            {
                casProgramu = casProgramu.AddDays(1);
                CasProgramu = casProgramu;
                Kalendar.SelectedDate = CasProgramu;
                UbehlMesic(Ucty);
                //MessageBox.Show(casProgramu.ToString());}}
            }
        }
    }
}