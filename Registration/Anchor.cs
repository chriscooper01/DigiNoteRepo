using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationProject
{
    public class Anchor
    {

        public static string Collect()
        {

            string folderLocation = MainTempFolder();
            string fileLocation = Path.Combine(folderLocation, "anchor.tkn");
            if(File.Exists(fileLocation))
            {
                string[] lines = System.IO.File.ReadAllLines(fileLocation);

                return string.Join("", lines).Trim();
            }

            return String.Empty;
        }


        public static void Create(string content)
        {
            string folderLocation = MainTempFolder();
            if (!Directory.Exists(folderLocation))
                Directory.CreateDirectory(folderLocation);

            string fileLocation = Path.Combine(folderLocation, "anchor.tkn");
            using (System.IO.StreamWriter file =  new System.IO.StreamWriter(fileLocation))
            {
                file.WriteLine(content);
            }
        }


        public static string MainTempFolder()
        {
            string location = String.Empty;

            location = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            location = Path.Combine(location, "DigiNote");

            
            return location;
        }
    }
}
