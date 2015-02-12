using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BSP_BuechereiMapper;
using BSP_Bücherei_Entities;
using Interfaces;

namespace BSP_Bücherei
{
    public partial class Form1 : Form
    {
        private readonly Mapper<Buch> _buchMapper = new BinaryMapper<Buch>(@"buecher.bin");
        private readonly Mapper<Benutzer> _benutzerMapper = new BinaryMapper<Benutzer>(@"benutzer.bin");
        private readonly Mapper<Admin> _adminMapper = new BinaryMapper<Admin>(@"admins.bin");

        private readonly Buecherei _buecherei = new Buecherei();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _buecherei.ErzeugeBuecherVonDump(_buchMapper);
            _buecherei.ErzeugeBenutzerVonDump(_benutzerMapper);
            _buecherei.ErzeugeAdminsVonDump(_adminMapper);

            lvBenutzer.DataSource = _buecherei.Benutzer;
        }

        private ListViewItem ListViewItemFürBenutzer(Benutzer b)
        {
            var ls = new ListViewItem();
            ls.SubItems.Add(b.Vorname);
            ls.SubItems.Add(b.Nachname);
            return ls;
        }

        private void erzeugenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BenutzerErstellenDialog(_buecherei).Show();
        }

        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _buecherei.SpeichereBuecherNachDump(_buchMapper);
            _buecherei.SpeichereBenutzerNachDump(_benutzerMapper);
            _buecherei.SpeichereAdminsNachDump(_adminMapper);
        }
    }
}
