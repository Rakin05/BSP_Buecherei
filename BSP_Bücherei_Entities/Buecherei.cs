using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSP_Bücherei_Entities
{
    class Buecherei
    {
        private List<Benutzer> _benutzer = new List<Benutzer>();
        private List<Buch> _buecher = new List<Buch>();
        private List<Admin> _admins = new List<Admin>();

        public void LeiheBuchFuerBenutzerAus(Benutzer benutzer, Buch buch)
        {
            buch.Ausgeliehen = true;
            benutzer.LeiheBuchAus(buch);
        }

        public void ErzeugeNeuesBuch(Buch buch)
        {
            _buecher.Add(buch);
        }

        public void ErzeugeNeuenBenutzer(Benutzer benutzer)
        {
            _benutzer.Add(benutzer);
        }

        public bool PrüfePasswordFürNutzer(string vorname, string nachname, string password)
        {
            var benutzer = _benutzer.First(b => b.Vorname.Equals(vorname) 
                                                && b.Nachname.Equals(nachname)
                                                && b.Password.Equals(password));
            return benutzer != null;
        }
    }
}
