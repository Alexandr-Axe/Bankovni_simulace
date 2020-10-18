using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankovni_Simulace_MVOP
{
    public class Ucet
    {
        public decimal Zustatek { get; set; }
        public string Nazev { get; set; }
        public Ucet(string nazev, decimal zustatek)
        {
            Zustatek = zustatek;
            Nazev = nazev;
        }
    }
    public class Sporici : Ucet
    {
        public double Urok { get; set; }
        public Sporici(string nazev, decimal zustatek, double urok) : base(nazev, zustatek)
        {
            Nazev = nazev;
            Zustatek = zustatek;
            Urok = urok;
        }
        public override string ToString() => $"Název účtu : {Nazev}\nZůstatek na účtě : {Zustatek} Kč\nMěsíční úrok : {Urok}%";
    }
    public class Studentsky : Sporici
    {
        public int MaxVyber { get; set; }
        public Studentsky(string nazev, decimal zustatek, double urok, int maxVyber) : base(nazev, zustatek, urok)
        {
            MaxVyber = maxVyber;
            Urok = urok;
        }
        public override string ToString() => $"Název účtu : {Nazev}\nZůstatek na účtě : {Zustatek} Kč\nMěsíční úrok : {Urok}%\nMaximální výběr : {MaxVyber}Kč";
    }

    public class Kreditni : Ucet
    {
        //Nula je maximální hodnota, pokud přelezu nulu, banka mi peníze vrátí
        //Při koupi budu mít hodnotu < 0
        //Další měsíc mám základ < 0 (mínus, kde jsem skončil)
        //Možnost zaplatit peníze, abych se dostal z mínusu

        public double Urok { get; set; }
        public DateTime DatumZalozeni { get; set; }
        public Kreditni(string nazev, decimal zustatek, double urok, DateTime dz) : base(nazev, zustatek)
        {
            Urok = urok;
            DatumZalozeni = dz.Date.AddMonths(1);
        }
        public override string ToString() => $"Název účtu : {Nazev}\nMaximální půjčka : {Zustatek} Kč\nMěsíční úrok : {Urok}%\nDatum splátky : {DatumZalozeni.ToString("dd/MM/yyyy")}";
    }
}
