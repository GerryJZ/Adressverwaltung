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
        public Form1()
        {
            InitializeComponent();
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
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    TextBox textBox = c as TextBox;
                    if (textBox.Text == string.Empty)
                    {
                        label29.Text = Convert.ToString("Es fehlen Daten");
                    }
                    else
                    {
                        label29.Text = Convert.ToString("");
                    }
                }
            }
            var Mail = Convert.ToString(textBox3.Text);
            if (IsValidEmail(Mail))
            {
                label27.Text = Convert.ToString("Das ist eine valide E-Mail");

                string[] array1 = new string[8];
                array1[0]= textBox1.Text;
                array1[1] = textBox2.Text;
                array1[2] = textBox3.Text;
                array1[3] = textBox4.Text;
                array1[4] = textBox5.Text;
                array1[5] = textBox6.Text;
                array1[6] = textBox7.Text;
                array1[7] = textBox8.Text;
                label29.Text = Convert.ToString("Daten wurden gespeichert");
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

                string pattern = @"^(http|ftp|https|www)://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?$";

            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            return regex.IsMatch(source);

        }

        private void Bild_testen_Click(object sender, EventArgs e)
        {
            var URL = Convert.ToString(textBox9.Text);
            if (CheckURLValid(URL))
            {
                label28.Text = Convert.ToString("Das ist eine valide URL");
                pictureBox1.ImageLocation = Convert.ToString(textBox9.Text);
            }
            else
            {
                label28.Text = Convert.ToString("Nicht gültige URL");
                pictureBox1.ImageLocation = Convert.ToString(textBox9.Text);
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
