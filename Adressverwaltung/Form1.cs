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
using System.IO;


namespace Adressverwaltung
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //-------------------------//
        // VORHERIGE ADRESSE BUTTON//
        //-------------------------//
        private void Vorherige_adresse_Click(object sender, EventArgs e)
        {
            string filePath = @"C:\tmp\AddressTest.csv";

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;

                //Dadurch wird die Datei bis zum letzten Eintrag gelesen.
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();

                    //den letzten Eintrag in der Datei auswählen.
                    if (reader.Peek() == -1)
                    {
                        //die Werte in ein Array setzen
                        string[] company = new string[9];
                        company = line.Split(';');

                        //die eindeutige Mitarbeiter-ID überspringen
                        company = company.Skip(0).ToArray();
                        textBox10.Text = company[1];
                        textBox13.Text = company[2];
                        textBox12.Text = company[3];
                        textBox11.Text = company[4];
                        textBox17.Text = company[5];
                        textBox16.Text = company[6];
                        textBox15.Text = company[7];
                        textBox14.Text = company[8];
                    }
                }
            }
        }
        //-------------------------//
        // NÄCHSTE ADRESSE BUTTON  //
        //-------------------------//
        private void nächste_adresse_Click(object sender, EventArgs e)
        {
            //this is all being edited and will be fixed
            var filePath = @"C:\tmp\AddressTest.csv";

            string[] lines = File.ReadLines(@"C:\tmp\AddressTest.csv").ToArray();


            string vorname = textBox10.Text;
            string nachname = textBox13.Text;
            string email = textBox12.Text;
            int i = 0;

            using (StreamReader reader = new StreamReader(filePath))
            {
                string currentLine;

                //check to see if labels have value
                if (textBox12.Text != null)
                {
                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        try
                        {
                            //we then find the CSV line where the email exists
                            if (currentLine.IndexOf(email, StringComparison.CurrentCultureIgnoreCase) >= 0)
                            {
                                //skip all irrelvant lines
                                string line = lines.Skip(i + 1).Take(1).First();

                                string[] company = new string[9];
                                company = line.Split(';');
                                company = company.Skip(0).ToArray();
                                textBox10.Text = company[1];
                                textBox13.Text = company[2];
                                textBox12.Text = company[3];
                                textBox11.Text = company[4];
                                textBox17.Text = company[5];
                                textBox16.Text = company[6];
                                textBox15.Text = company[7];
                                textBox14.Text = company[8];
                            }
                            i++;
                        }
                        catch (InvalidOperationException exception)
                        {
                            return;
                        }

                    }
                }
            }

        }

        //-------------------------//
        // ADRESSE ENTFERNEN BUTTON//
        //-------------------------//
        private void Adresse_entfernen_Click(object sender, EventArgs e)
        {
            Reset();
            label27.Text = " ";
        }

        //-------------------------//
        // ADRESSE SPEICHERN BUTTON//
        //-------------------------//
        private void Adresse_speichern_Click(object sender, EventArgs e)
        {
            //überprufen, ob alle Felder ausgefüllt sind
            // wenn ja, geht weiter, wenn nein 'Fehlermeldung' kriegen
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

            //überprufen, ob die E-Mail gültig ist oder nicht
            var Mail = Convert.ToString(textBox3.Text);
            if (IsValidEmail(Mail))
            {
                label27.Text = Convert.ToString("Das ist eine valide E-Mail");
                label29.Text = Convert.ToString("Daten wurden gespeichert");


                //wenn Email ist gültig - Dateipfad erstellen
                var file = @"C:\tmp\AddressTest.csv";

                //wenn datei nicht existiert, wird es erstellt
                if (!File.Exists(file))
                {
                    //erstellen ein Array um ein Headerline in CSV datei zu schreiben
                    string[] header = new string[]
                    {
                                                "Company ID",
                                                "Vorname",
                                                "Nachname",
                                                "Email",
                                                "Telefon",
                                                "Strasse",
                                                "HausNummer",
                                                "PTZL",
                                                "Ort",
                    };


                    //headerline wird an CSV datei geschriebt
                    File.AppendAllText(file, string.Join(";", header) + Environment.NewLine);

                }
                //wenn Datei schon existiert
                if (File.Exists(file))
                {
                    //Array die TextBox Werte zu halten
                    string[] companyInfo = new string[9];

                    //Random ID wird generiert und an Eintrag zugewiesen
                    companyInfo[0] = RandomID();

                    //die andere kriegen GUI TextBox Einträge
                    companyInfo[1] = textBox1.Text;
                    companyInfo[2] = textBox2.Text;
                    companyInfo[3] = textBox3.Text;
                    companyInfo[4] = textBox4.Text;
                    companyInfo[5] = textBox5.Text;
                    companyInfo[6] = textBox6.Text;
                    companyInfo[7] = textBox7.Text;
                    companyInfo[8] = textBox8.Text;

                    //Array wird an CSV datei geschrieben.
                    File.AppendAllText(file, string.Join(";", companyInfo) + Environment.NewLine);
                }
            }
            else
            {
                label27.Text = Convert.ToString("Nicht gültige Email adresse");
            }

        }

        //-------------------------//
        // ZUFÄLLIGE ADRESSE BUTTON//
        //-------------------------//
        private void Zufällige_adresse_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadLines(@"C:\tmp\AddressTest.csv").ToArray();
            bool isEmpty = true;

            //get a random number
            var random = new Random();
            int randomNumber = random.Next(1, lines.Length);

            while (isEmpty) //während die Zeile leer ist.
            {
                //Zufällige Zeile lesen
                string line = lines.Skip(randomNumber - 1).Take(1).First();

                if (line != null)  //Zeile hat eine Zeile mit Werten gefunden
                {
                    //überprufen, ob Zeile ist headerline
                    if (line == "Company ID;Vorname;Nachname;Email;Telefon;Strasse;HausNummer;PTZL;Ort")
                    {
                        isEmpty = true;
                        line = string.Empty;
                        line = lines.Skip(randomNumber).Take(1).First();
                    }

                    string[] company = new string[9];
                    company = line.Split(';');
                    company = company.Skip(0).ToArray();
                    textBox10.Text = company[1];
                    textBox13.Text = company[2];
                    textBox12.Text = company[3];
                    textBox11.Text = company[4];
                    textBox17.Text = company[5];
                    textBox16.Text = company[6];
                    textBox15.Text = company[7];
                    textBox14.Text = company[8];

                    isEmpty = false;
                }
            }

        }

        //-------------------------//
        // ADDRESSE SUCHEN BUTTON  //
        //-------------------------//
        private void Adresse_suchen_Click(object sender, EventArgs e)
        {
            var filePath = @"C:\tmp\AddressTest.csv";
            string email = textBox18.Text;
            string[] csv = new string[9];
            string[] holder = new string[9]; //array to hold current line
            string emailCheck; //

            //check to see if there is anything in the textBox
            if (textBox18.Text != "")
            {
                //check to see if email entered is a valid email
                if (IsValidEmail(email))
                {
                    //get access to the file
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string currentLine;

                        //reads the file until currentLine is empty
                        while ((currentLine = reader.ReadLine()) != null)
                        {
                            holder = currentLine.Split(';');
                            emailCheck = Convert.ToString(holder.GetValue(3));

                            if (emailCheck == email)
                            {
                                csv = holder;
                                csv = csv.Skip(0).ToArray();
                                textBox10.Text = csv[1];
                                textBox13.Text = csv[2];
                                textBox12.Text = csv[3];
                                textBox11.Text = csv[4];
                                textBox17.Text = csv[5];
                                textBox16.Text = csv[6];
                                textBox15.Text = csv[7];
                                textBox14.Text = csv[8];
                            }


                        }
                    }
                }
                else
                {
                    textBox18.Text = "Ungültige E-mail";
                }
            }
        }


        public static bool IsValidEmail(string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            return regex.IsMatch(email);
        }




        public static bool CheckURLValid(string source)
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



        private static string RandomID()
        {
            Random random = new Random();
            int length = 6;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void Reset()
        {
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    ((TextBox)x).Clear();
                }
            }
        }
            
         }
    }



   






