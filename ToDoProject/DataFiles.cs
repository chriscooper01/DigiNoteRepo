using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoProject
{
    public class DataFiles
    {
        private static string fullPath { get; set; }
        private static string Name { get; set; }
        private static int currentRecordId { get; set; }
        public static void RichTextBox_DragDrop(object sender, DragEventArgs e)
        {
            fullPath = e.Data.GetData("FileDrop").ToString();
            if (fullPath != null && File.Exists(fullPath))
            {

                
                var file = getFile();
                Model.DiarySDF.Queries.FileQuery.Insert(currentRecordId, Name, file);

            }
        }


        private static byte[] getFile()
        {
            byte[] file;
            using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream))
                {
                    FileInfo info = new FileInfo(fullPath);
                    Name = info.Name;
                    file = reader.ReadBytes((int)stream.Length);           
                }
            }

            return file;
        }




        private static void recordId()
        {
            var mainForm = Application.OpenForms["frmMainScreen"];
            

           var label = mainForm.Controls.OfType<Label>().SingleOrDefault(x => x.Name.StartsWith("lblHidenRecordId"));
            if(label !=null)
            {
                int itemp = 0;
                int.TryParse(label.Text, out itemp);
                currentRecordId = itemp;
            }

        }
    }
}
