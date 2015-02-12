using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace BSP_Bücherei_Entities
{
    public class Buecherei
    {
        private List<Benutzer> _benutzer = new List<Benutzer>();
        private List<Buch> _buecher = new List<Buch>();
        private List<Admin> _admins = new List<Admin>();
        public List<Benutzer> Benutzer { get { return _benutzer;  } }

        public void LeiheBuchFuerBenutzerAus(Benutzer benutzer, Buch buch)
        {
            buch.Ausgeliehen = true;
            benutzer.LeiheBuchAus(buch);
        }

        public void ErzeugeBuecherVonDump(Mapper<Buch>  mapper)
        {
            _buecher = mapper.Wiederherstellen();
        }

        public void ErzeugeBenutzerVonDump(Mapper<Benutzer> mapper)
        {
            _benutzer = mapper.Wiederherstellen();
        }

        public void ErzeugeAdminsVonDump(Mapper<Admin> mapper)
        {
            _admins = mapper.Wiederherstellen();
        }

        public void SpeichereBuecherNachDump(Mapper<Buch> mapper)
        {
            mapper.Abbilden(_buecher);
        }

        public void SpeichereBenutzerNachDump(Mapper<Benutzer> mapper)
        {
            mapper.Abbilden(_benutzer);
        }

        public void SpeichereAdminsNachDump(Mapper<Admin> mapper)
        {
            mapper.Abbilden(_admins);
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
                                                && b.Passwort.Equals(password));
            return benutzer != null;
        }

        public bool PrüfeObAdministrator(string vorname, string nachname, string password)
        {
            var admin = _admins.First(b => b.Vorname.Equals(vorname)
                                    && b.Nachname.Equals(nachname)
                                    && b.Passwort.Equals(password));
            return admin != null;
        }
    }
}
