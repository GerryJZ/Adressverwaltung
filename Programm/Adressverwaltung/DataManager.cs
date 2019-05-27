using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adressverwaltung
{
    public class Data
    {
        // Create a new dictionary of strings, with string keys.
        //


        private int CurrentAdressID = 1;

        //FirstName,LastName,E-mail,Tel,Straße,Hausnummer,Postleitzahl,Ort
        Dictionary<int, string[]> Adress = new Dictionary<int, string[]>();

        public Data()
        {
            Adress.Add(1, new string[] { "FirstName1", "LastName", "E-mail", "Tel", "Strasse", "Hausnummer", "Postleitzahl", "Ort" });
            Adress.Add(2, new string[] { "FirstName2", "LastName", "E-mail", "Tel", "Strasse", "Hausnummer", "Postleitzahl", "Ort" });
            Adress.Add(3, new string[] { "FirstName3", "LastName", "E-mail", "Tel", "Strasse", "Hausnummer", "Postleitzahl", "Ort" });
            Adress.Add(4, new string[] { "FirstName4", "LastName", "E-mail", "Tel", "Strasse", "Hausnummer", "Postleitzahl", "Ort" });
        }
            
        public bool AdressForward()
        {
            CurrentAdressID++;
            return true;
        }

        public bool AdressBackward()
        {
            CurrentAdressID--;
            return true;
        }

        public bool RemoveAdressbyEmail(string Email)
        {
            return true;
        }

        public bool AddAdress(string FirstName,string LastName)
        {

          
            //Add Adress to csv
            return true;
        }

        public string[] SearchAdress(string Email)
        {
            String[] Adresse = new String[] { "a", "b", "c", "d" };
            return Adresse;
        }





        public void AddRandomAdress()
        {
            Adress.Add(1, new string[] { "FirstName", "LastName", "E-mail", "Tel", "Strasse", "Hausnummer", "Postleitzahl", "Ort" });
        }

        public void RandomAdress()
        {
            CurrentAdressID = 3;
        }

        public string[] GetCurrentAdress()
        {
            return Adress[CurrentAdressID];
        }

     
    

    }
}
