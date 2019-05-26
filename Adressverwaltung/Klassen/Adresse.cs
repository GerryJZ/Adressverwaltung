using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Specialized;
using System.IO;

namespace Adressverwaltung.Klassen
{
   
    class Adresse
    {
        // Create a new dictionary of strings, with string keys.


        private int currentAdressID = 1;
        
        private bool UseDictonary = false;
        private int fileRows = 0;
        private static Random r = new Random(DateTime.Now.Second);
        private Dictionary<string, string> Adressen = new Dictionary<string, string>();
        private IList<string> ID = new List<string>();
        FilePath CSVFile = new FilePath();

        string CSVFilePath = "C:\\csv\\Adressverwaltung.csv";

        public Adresse()
        {
            //FilePath = CSVFile.getFilePath();

            fileRows = File.ReadLines(CSVFilePath).Count();




        }

        
        public void LoadDictonary()
        {  
          string[] columns;
          string Email;
          int i = 0;

          var lines = File.ReadLines(CSVFilePath);
          foreach (var line in lines)
          {
              columns = line.Split(',');
              Email = columns[2];
              if (!Adressen.ContainsKey(Email))
              {
                  Adressen.Add(Email, line);
                  ID.Add(Email);
              }
              else
              {

              }
              i++;

          }

            UseDictonary = true;
        }

        public void SaveDictonary()
        {
          
            var csv = new StringBuilder();

            foreach (var Adresse in Adressen)
            {
                csv.AppendLine(Adresse.Value);
            }

           File.WriteAllText(CSVFilePath, csv.ToString());
         
        }

        public string getAdressCount()
        {
            return ID.Count().ToString();
        }

        public string getCurrentAdressID()
        {
            return currentAdressID.ToString();
        }

        public bool AdressForward()
        {
            int i = 1 + currentAdressID;
            if (i < fileRows)
            {
                currentAdressID++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AdressBackward()
        {
            int i = 1 - currentAdressID;
            if (i < 0)
            { 
                currentAdressID--;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveAdressbyEmail(string Email)
        {
            LoadDictonary();
            Adressen.Remove(Email);
            ID.Remove(Email);
            SaveDictonary();
        
        }
        
        public void AddAdresse(string Vorname, string Nachname, string Email, string Telefonnummer, string Strasse, string Hausnummer,string Postleitzahl,string Ort, string Avatar, string Land)
        {
            string Adresse;
            Adresse = Vorname + "," + Nachname + "," + Email + "," + Telefonnummer + "," + Strasse + "," + Hausnummer + "," + Postleitzahl + "," + Ort + "," + Avatar + "," + Land + Environment.NewLine;

           File.AppendAllText(CSVFilePath, Adresse);
        }

        public void AddAdressen(string Adressen)
        {
           File.AppendAllText(CSVFilePath, Adressen);
        }

        public string SearchEmail(string Email)
        {
            if (Adressen.ContainsKey(Email))
            {
                return Adressen[Email];
            }
            else
            {
                return "";
            }
            
        }

        public string SearchValue(string Value)
        {
         
            var lines = File.ReadLines(CSVFilePath);

            return lines.FirstOrDefault(x => x.Contains(Value));
        }

        public void RandomAdress()
        {
            if (UseDictonary)
            {
                currentAdressID = r.Next(ID.Count);
            }
            else
            {
              
                currentAdressID = r.Next(1, fileRows);
            }
           
        }

        public string GetCurrentAdress()
        {
            if (UseDictonary)
            {
              
                if (currentAdressID >= 1 && currentAdressID <= fileRows)
                {
                    return Adressen[ID[currentAdressID]];
                }
                else
                {
                    return Adressen[ID[currentAdressID]];
                }
               
            }
            else
            {
                if (currentAdressID >= 1 && currentAdressID <= fileRows)
                {
                    var lines = File.ReadLines(CSVFilePath);
                    string line = lines.ElementAtOrDefault(currentAdressID);

                    return line;
                }
                else
                {
                    return Adressen[ID[currentAdressID]];
                }
                
            }
           
           
        }

        public void setCurrentAdressID(int ID)
        {
            currentAdressID = ID;
        }

        public void LastAdress()
        {
            currentAdressID = File.ReadLines(CSVFilePath).Count();
        }
    }
}
