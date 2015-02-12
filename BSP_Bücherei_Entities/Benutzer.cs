using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSP_Bücherei_Entities
{
    class Benutzer
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public List<Buch> AusgelieheneBuecher { get; set; }
        public string Password { get; set; }

        public void LeiheBuchAus(Buch buch)
        {
            
        }
    }
}
