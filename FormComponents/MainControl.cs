using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormComponents
{
    public class MainControl
    {

        private static Form mainForm;
        public static Form MainForm { get
            {
                if(mainForm == null)
                    mainForm = Application.OpenForms["frmMainScreen"];
                return mainForm;
                
            }
        }

        private static TabPage taskTab;
        private static TabPage NotesTab;
        private static TabPage historyTab;

        public static TabPage GetTaskTab()
        {
            getTaskControls();
            return taskTab;
        }




        public static ComboBox cmbNotesCategory()
        {

            getTabNoteControls();
            var item = NotesTab.Controls.OfType<ComboBox>().SingleOrDefault(x => x.Name.StartsWith("cmbNotesCategory"));
            return item;
        }

        public static ComboBox cmbNotesSubject()
        {
            getTabNoteControls();
            var item = NotesTab.Controls.OfType<ComboBox>().SingleOrDefault(x => x.Name.StartsWith("cmbNotesSubject"));
            return item;
        }


        public static ComboBox cmbHistoryCategory()
        {

            getHistoryControls();
            var item = historyTab.Controls.OfType<ComboBox>().SingleOrDefault(x => x.Name.StartsWith("cmbHistoryCategory"));
            return item;
        }

        public static ComboBox cmbHistorySubject()
        {
            getHistoryControls();
            var item = historyTab.Controls.OfType<ComboBox>().SingleOrDefault(x => x.Name.StartsWith("cmbHistorySubject"));
            return item;
        }




        public static ComboBox cmbToDoCategories()
        {
            getTaskControls();
            var item = taskTab.Controls.OfType<ComboBox>().SingleOrDefault(x => x.Name.StartsWith("cmbToDoCategories"));
            return item;
        }




     


        private static void getTaskControls()
        {



            //Tab3 the name has not yet been set
            var c = MainForm.Controls.Find("tabTasks", true);
            if (c != null)
            {
                taskTab = (TabPage)c[0];
                //   var taskTab = mainTabControl.it
            }


        }



          private static void getTabNoteControls()
        {



            //Tab3 the name has not yet been set
            var c = MainForm.Controls.Find("tbpNotes", true);
            if (c != null)
            {
                NotesTab = (TabPage)c[0];
                //   var taskTab = mainTabControl.it
            }
            

        }

        private static void getControls()
        {
      


              //Tab3 the name has not yet been set
                var c = MainForm.Controls.Find("tabTasks", true);
                if(c !=null)
                {
                    taskTab = (TabPage)c[0];
                 //   var taskTab = mainTabControl.it
                }
            

        }


        private static void getHistoryControls()
        {



            //Tab3 the name has not yet been set
            var c = MainForm.Controls.Find("tbpHistory", true);
            if (c != null)
            {
                historyTab = (TabPage)c[0];
                //   var taskTab = mainTabControl.it
            }


        }
    }
}
