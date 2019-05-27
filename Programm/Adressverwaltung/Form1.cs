
using Adressverwaltung.Klassen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Adressverwaltung
{
    
    public partial class Adressverwaltung : Form
    {
        /*
        * Konstruktor
        */
        Adresse _Adressen = new Adresse();
        RandomAdressen randAdressen = new RandomAdressen();
        bool run = false;
        public Adressverwaltung()
        {
         
            InitializeComponent();
            UpdateUiOutput(this._Adressen.GetCurrentAdress());
         


        }
        /*
        * GUI Funktionen
        */

       
        private void InputLöschen_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            label27.Text = "-";
            pictureBox1.ImageLocation = "";
        }
        /*
         * Adresse Löschen
         */
        private void Adresse_entfernen_Click(object sender, EventArgs e)
        {
            _Adressen.RemoveAdressbyEmail(label21.Text);
            UpdateUiOutput(this._Adressen.GetCurrentAdress());

        }
        /*
         * Adresse Speichern
         */
        private void Adresse_speichern_Click(object sender, EventArgs e)
        {
            _Adressen.AddAdresse(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, "Germany");

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            label27.Text = "-";
            label27.Text = "-";
            pictureBox1.ImageLocation = "";
        }
        /*
         * Adressen Generierung
         */
        private void Adresse_generieren_Click(object sender, EventArgs e)
        {
            run = true;
            while (run)
            {
                _Adressen.AddAdressen(randAdressen.getAdressen());
            }    
        }

        //Adresse Gen
        private void AdresseGennerien_Click(object sender, EventArgs e)
        {
            UpdateUiInput(randAdressen.getAdresse());
        }
        /**
        * Navigation
        */
        private void getID_Click(object sender, EventArgs e)
        {
            _Adressen.setCurrentAdressID(Convert.ToInt32(textBox12.Text));
            UpdateUiOutput(this._Adressen.GetCurrentAdress());
        }
        private void Zufällige_adresse_Click(object sender, EventArgs e)
        {
            _Adressen.RandomAdress();
            UpdateUiOutput(this._Adressen.GetCurrentAdress());
        }
        private void nächste_adresse_Click(object sender, EventArgs e)
        {
            _Adressen.AdressForward();
            UpdateUiOutput(this._Adressen.GetCurrentAdress());
        }
        private void vorherige_adresse_Click(object sender, EventArgs e)
        {
            _Adressen.AdressBackward();
            UpdateUiOutput(this._Adressen.GetCurrentAdress());
        }
        /*
         * Suche
         */
        private void button2_Click(object sender, EventArgs e)
        {
            _Adressen.LoadDictonary();
        }
        private void AdresseSuchen_Click(object sender, EventArgs e)
        {
            UpdateUiOutput(_Adressen.SearchValue(textBox11.Text));
        }
        private void EmailSuche_Click(object sender, EventArgs e)
        {
            UpdateUiOutput(_Adressen.SearchEmail(textBox10.Text));
        }
        /*
         * UI Update
         */
        private void UpdateUiOutput(string Adresse)
        {    
 
            string[] Adressen;

            Adressen = Adresse.Split(',');

            label19.Text = Adressen[0];
            label20.Text = Adressen[1];
            label21.Text = Adressen[2];
            label22.Text = Adressen[3];
            label23.Text = Adressen[4];
            label24.Text = Adressen[5];
            label25.Text = Adressen[6];
            label26.Text = Adressen[7];
            pictureBox2.ImageLocation = Adressen[8];

         
        }
        private void UpdateUiInput(string Adresse)
        {
            string[] Adressen;

            Adressen = Adresse.Split(',');

            textBox1.Text = Adressen[0];
            textBox2.Text = Adressen[1];
            textBox3.Text = Adressen[2];
            textBox4.Text = Adressen[3];
            textBox5.Text = Adressen[4];
            textBox6.Text = Adressen[5];
            textBox7.Text = Adressen[6];
            textBox8.Text = Adressen[7];
            textBox9.Text = Adressen[8];
            pictureBox1.ImageLocation = Adressen[8];
        }

        /*
        * INPUT Validation
        */
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (IsValidEmail(textBox3.Text))
            {
                label27.Text = Convert.ToString("Das ist eine valide E-Mail");
            }
            else
            {
                label27.Text = Convert.ToString("Nicht gültige Email adresse");
            }
        }

        public bool IsValidEmail(string email)
        {
           

            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            return regex.IsMatch(email);
        }

      
        public static bool CheckURLValid(string source)
        {
            Uri uriResult;
            return Uri.TryCreate(source, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps;
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

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            /*
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
            */
        }

        private void CopyEmail_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label21.Text);
        }
    }
}


