using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adressverwaltung.Klassen
{
    class FilePath
    {
       public string getFilePath()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string FilePath = "csv\\Adressverwaltung.csv";
            string marks = "\"";
            return projectDirectory + FilePath;     
        }
    }
}
