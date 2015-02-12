using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BSP_Bücherei_Entities;

namespace BSP_Bücherei
{
    public partial class BenutzerErstellenDialog : Form
    {
        private readonly Buecherei _buecherei;

        public BenutzerErstellenDialog(Buecherei buecherei)
        {
            _buecherei = buecherei;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!txtPasswort.Text.Equals(txtPasswortBestätigung.Text))
                return;
            var benutzer = new Benutzer
            {
                Vorname = txtVorname.Text,
                Nachname = txtNachname.Text,
                Passwort = txtPasswort.Text
            };

            _buecherei.ErzeugeNeuenBenutzer(benutzer);

            Close();
        }
    }
}
