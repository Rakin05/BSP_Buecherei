using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSP_Bücherei_Entities
{
    [Serializable]
    public class Buch
    {
        public string Title { get; set; }
        public bool Ausgeliehen { get; set; }
        public DateTime AusgeliehenDatum { get; set; }
        public Benutzer AusleiheNutzer { get; set; }
    }
}
