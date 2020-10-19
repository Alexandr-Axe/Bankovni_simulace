using System;
using System.Timers;
using System.Windows.Threading;

namespace Bankovni_Simulace_MVOP
{
    public class Cas
    {

        public void ZrychlenyCas(DateTime casProgramu)
        { 
            casProgramu = new DateTime();
           DispatcherTimer dispatcherTimer = new DispatcherTimer();
           dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
           dispatcherTimer.Interval = new TimeSpan(0,0,1);
           dispatcherTimer.Start();


           void dispatcherTimer_Tick(object sender, EventArgs e)
           {
               casProgramu.AddDays(1);
           }
        }
    }
}