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

namespace Bankovni_Simulace_MVOP
{
    /// <summary>
    /// Interakční logika pro MojeUcty.xaml
    /// </summary>
    public partial class MojeUcty : Window
    {
        MainWindow MW = new MainWindow();
        public MojeUcty()
        {
            InitializeComponent();
            //sporici.Content = MW.SUcet[0].ToString(); Z nějakého důvodu nefunguje
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MW.Show();
            Close();
        }
    }
}
