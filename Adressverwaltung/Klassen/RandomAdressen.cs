using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Adressverwaltung.Klassen
{
    class RandomAdressen
    {

        public RandomAdressen()
        {
         
           
         

           

        }

        private static Random r = new Random(DateTime.Now.Second);


        public string getAdresse()
        {
            var webRequest = WebRequest.Create(@"https://api.mockaroo.com/api/ba04da60?count=1&key=e4db1a50");

            using (var response = webRequest.GetResponse())
            using (var content = response.GetResponseStream())
            using (var reader = new StreamReader(content))
            {
                var strContent = reader.ReadToEnd();
                return strContent;
            }
        }

        public string getAdressen()
        {
            string Vorname = "";
            string Nachname = "";
            string Email = "";
            string Telefonnummer = "";
            string Strasse = "";
            string Hausnummer = "";
            string Postleitzahl = "";
            string Avatar = "";
            string Land = "";
            string Ort = "";
            string Website = "";

            string Adresse;

            string Adressen = "";


           
                for (int i = 0; i < 999; i++)
                {
                    Vorname = getVorname();
                    Nachname = getNachname();
                    Website = EmailProvider();
                    Email = getEmail(Vorname, Nachname, Website);
                    Telefonnummer = getTelefonnummer();
                    Strasse = getStrasse();
                    Hausnummer = getHausnummer();
                    Postleitzahl = getPostleitzahl();
                    Ort = getOrt();
                    Avatar = getAvatar();
                    Land = getLand();
                   

                Adresse = Vorname + "," + Nachname + "," + Email + "," + Telefonnummer + "," + Strasse + "," + Hausnummer + "," + Postleitzahl + "," + Ort + "," + Avatar + "," + Land + Environment.NewLine;

                    Adressen = String.Concat(Adressen, Adresse);
                }
            
          

            return Adressen;
            /*
            for (int i = 0; i < 10000; i++)
            {
                Vorname = getVorname();
                Nachname = getNachname();
                Adresse.Append(Vorname);
                Adresse.Append(Nachname);
                Adresse.Append(getEmail(Vorname, Nachname, "Test"));
                Adresse.Append(getTelefonnummer());
                Adresse.Append(getStrasse());
                Adresse.Append(getHausnummer());
                Adresse.Append(getPostleitzahl());
                Adresse.Append(getAvatar());
                Adresse.Append(getLand());
                Adresse.Append(Environment.NewLine);

                //Adresse = Vorname + "," + Nachname + "," + Email + "," + Telefonnummer + "," + Strasse + "," + Hausnummer + "," + Postleitzahl + "," + Ort + "," + Avatar + "," + Land + Environment.NewLine;

                Adressen = String.Concat(Adressen, Adresse);
            }
            */
        }

        private string getVorname()
        {
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < r.Next(4, 8))
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;

        }
        private string getNachname()
        {

            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < r.Next(4, 8))
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }
            return Name;
        }

        private string EmailProvider()
        {
         
            string[] authors = { "gmx", "gmail", "mail", "Outlook"};

            int index = r.Next(authors.Length);

            return authors[index];
        }
        private string getEmail(string Vorname, string Nachname,string Webseite)
        {

            return Vorname + "." + Nachname + "@" + Webseite + ".de";
        }
        private string getTelefonnummer()
        {
          

            return "+49"+r.Next(100000, 999999).ToString();
        }
        private string getStrasse()
        {
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < r.Next(4, 8))
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }
            return Name;
        }
        private string getHausnummer()
        {
           

            return r.Next(1, 100).ToString();
        }
        private string getPostleitzahl()
        {
         

            return r.Next(1000, 10000).ToString();
        }
        private string getOrt()
        {

            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < r.Next(4, 8))
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }
            return Name;
        }
        private string getAvatar()
        {
            return "https://thispersondoesnotexist.com/image";
        }
        private string getLand()
        {
            return "Germany";
        }



    }
}
