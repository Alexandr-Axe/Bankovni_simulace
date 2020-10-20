using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankovni_Simulace_MVOP
{
    public class Ucet
    {
        public double Zustatek { get; set; }
        public double Urok { get; set; }
        public string Nazev { get; set; }
        public DateTime DatumZalozeni { get; set; }
        public string TypUctu { get; set; }
        public Ucet(string nazev, double zustatek, double urok, DateTime datumZalozeni)
        {
            Zustatek = zustatek;
            Urok = urok;
            Nazev = nazev;
            DatumZalozeni = datumZalozeni;
        }
    }
    public class Sporici : Ucet
    {
        public Sporici(string nazev, double zustatek, double urok, DateTime datumZalozeni) : base(nazev, zustatek, urok, datumZalozeni)
        {
            TypUctu = "Spořící";
        }
        public override string ToString() => $"Název účtu : {Nazev}\nTyp : {TypUctu}\nZůstatek na účtě : {Zustatek} Kč\nMěsíční úrok : {Urok}%\nDatum splátky : {DatumZalozeni.ToString("dd/MM/yyyy")}\nDatum úročení : {DatumZalozeni.AddMonths(1).ToString("dd/MM/yyyy")}";
    }
    public class Studentsky : Sporici
    {
        public int MaxVyber { get; set; }
        public Studentsky(string nazev, double zustatek, double urok, int maxVyber, DateTime datumZalozeni) : base(nazev, zustatek, urok, datumZalozeni)
        {
            MaxVyber = maxVyber;
            TypUctu = "Spořící studentský";
        }
        public override string ToString() => $"Název účtu : {Nazev}\nTyp : {TypUctu}\nZůstatek na účtě : {Zustatek} Kč\nMěsíční úrok : {Urok}%\nMaximální výběr : {MaxVyber}Kč\nDatum splátky : {DatumZalozeni.ToString("dd/MM/yyyy")}\nDatum úročení : {DatumZalozeni.AddMonths(1).ToString("dd/MM/yyyy")}";
    }

    public class Kreditni : Ucet
    {
        //Nula je maximální hodnota, pokud přelezu nulu, banka mi peníze vrátí
        //Při koupi budu mít hodnotu < 0
        //Další měsíc mám základ < 0 (mínus, kde jsem skončil)
        //Možnost zaplatit peníze, abych se dostal z mínusu
        
        public double ChybiSplatit { get; set; }
       
        public Kreditni(string nazev, double zustatek, double urok, DateTime datumZalozeni) : base(nazev, zustatek, urok, datumZalozeni)
        {
            TypUctu = "Kreditní";
        }
        public override string ToString() => $"Název účtu : {Nazev}\nTyp : {TypUctu}\nMaximální půjčka : {Zustatek} Kč\nMěsíční úrok : {Urok}%\nDatum splátky : {DatumZalozeni.ToString("dd/MM/yyyy")}\nDatum úročení : {DatumZalozeni.AddMonths(1).ToString("dd/MM/yyyy")}";
    }
}