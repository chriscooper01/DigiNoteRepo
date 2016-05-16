using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormComponents
{
    public class PopulateDefaultData
    {

        public static   void SetNoteCatList(int categoryId)
        {
            setComboBoxEditNew(Model.DiarySDF.Queries.CategoryQuery.List(),MainControl.cmbNotesCategory(), categoryId);

        }

        public static void SetNoteSubjectList(int selected, int categoryId, int subjectId)
        {
            ComboBox control = MainControl.cmbNotesSubject();
            setComboBoxEditNew(Model.DiarySDF.Queries.SubjectQuery.List(categoryId), control, subjectId);
            control.Enabled = (categoryId > 0);
            control.SelectedValue = subjectId;
            if(selected.Equals(-1))
                control.Text = "[Please Select]";
        }

        public static void SetHistoryCatList(int categoryId)
        {
            setComboBox(Model.DiarySDF.Queries.CategoryQuery.List(), MainControl.cmbHistoryCategory(), categoryId);

        }

        public static void SetHistorySubjectList(int selected, int categoryId, int subjectId)
        {
            ComboBox control = MainControl.cmbHistorySubject();
            setComboBox(Model.DiarySDF.Queries.SubjectQuery.List(categoryId), control, subjectId);
            control.Enabled = (categoryId > 0);
            control.SelectedValue = subjectId;
        }


        public static void SetToDoCatList(int toDoCategoryId)
        {
            setComboBoxEditNew(Model.DiarySDF.Queries.ToDoCategoryQuery.List(), MainControl.cmbToDoCategories(), toDoCategoryId);
        }



       
        private static void setComboBox(List<Model.UniversalDataClasses.ListItem> items, ComboBox controller, int id)
        {
            controller.Items.Clear();
            controller.SelectedIndex = -1;
            controller.SelectedItem = null;
            controller.SelectedText = String.Empty;
            controller.SelectedValue = String.Empty;
            foreach (var item in items)
            {
                controller.Items.Add(item);
            }
            controller.DisplayMember = "Text";
            controller.ValueMember = "Id";
            var indexFound = items.FirstOrDefault(x => x.Id.Equals(id));
            if (indexFound != null)
                controller.SelectedIndex = controller.Items.IndexOf(indexFound);



        }

        private static  void setComboBoxEditNew(List<Model.UniversalDataClasses.ListItem> items, ComboBox controller, int id)
        {
            setComboBox(items, controller, id);

            controller.Items.Add(new Model.UniversalDataClasses.ListItem() { Id = -2, Text = "[Edit]" });
            controller.Items.Add(new Model.UniversalDataClasses.ListItem() { Id = -1, Text = "[New]" });


        }
    }
}
