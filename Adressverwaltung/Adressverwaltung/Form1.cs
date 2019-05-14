using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Adressverwaltung
{
    
    public partial class Form1 : Form
    {
        Data Adressen = new Data();
       
        public Form1()
        {
            string[] SAdressen;
            InitializeComponent();
            SAdressen = Adressen.GetCurrentAdress();

            textBox1.Text = SAdressen[0];
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Adresse_entfernen_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Adresse_speichern_Click(object sender, EventArgs e)
        {
            var Mail = Convert.ToString(textBox3.Text);
            if (IsValidEmail(Mail))
            {
                label27.Text = Convert.ToString("Das ist eine valide E-Mail");
            }
            else
            {
                label27.Text = Convert.ToString("Nicht gültige Email adresse");
            }

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        public static bool IsValidEmail(string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            return regex.IsMatch(email);
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        public static bool CheckURLValid( string source)
        {
            Uri uriResult;
            return Uri.TryCreate(source, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp;
        }

        private void Bild_testen_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = Convert.ToString(textBox9.Text);
            var URL = Convert.ToString(textBox9.Text);
            if (CheckURLValid(URL))
            {
                label28.Text = Convert.ToString("Das ist eine valide URL");
            }
            else
            {
                label28.Text = Convert.ToString("Nicht gültige URL");
            }
        }

        private void Adresse_generieren_Click(object sender, EventArgs e)
        {
            

        }
        private void Zufällige_adresse_Click(object sender, EventArgs e)
        {
            Adressen.RandomAdress();
            UpdateUiOutput();
        }
        private void nächste_adresse_Click(object sender, EventArgs e)
        {
            Adressen.AdressForward();
            UpdateUiOutput();
        }

        private void vorherige_adresse_Click(object sender, EventArgs e)
        {
            Adressen.AdressBackward();
            UpdateUiOutput();
        }

        private void UpdateUiOutput()
        {
            string[] SAdressen;

            SAdressen = Adressen.GetCurrentAdress();

            textBox1.Text = SAdressen[0];
        }
        private void UpdateUiInput()
        {
            string[] SAdressen;

            SAdressen = Adressen.GetCurrentAdress();

            textBox1.Text = SAdressen[0];
        }


    }
}
