using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model.UniversalDataClasses;

namespace ToDoProject
{
    public class PanelItemControl
    {
        private static string previousItemControlName;


        public static void PopulatePanel(ref Panel column, string controlName, List<ItemDataClass> items)
        {


            foreach (var data in items)
            {
                data.ItemControlName = controlName;
                var item = createItemPanel(data);
                PanelMoving.SetItemEvents(item);
                column.Controls.Add(item);

            }







        }

        /// <summary>
        /// This will go through the Column panel and reorder the order of each items by the Completion Planned date
        /// Re insert the item and return a new column panel
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public static Panel OrderItemsWithinPanel(Panel column)
        {

            var aa = column.Controls.OfType<Panel>().Where(x => x.Name.StartsWith("pnlItem")).ToList();
            List<ItemDataClass> itemsTag = column.Controls.OfType<Panel>().Where(x => x.Name.StartsWith("pnlItem")).Select(s => new ItemDataClass(s.Tag)).ToList();
            ToDoProject.PanelItemControl.RemoveItems(column);

            foreach (var item in itemsTag.OrderBy(o => o.CompletionPlanned))
            {
                var newItem = createItemPanel(item);
                newItem.Location = newLocation(column);
                PanelMoving.SetItemEvents(newItem);
                column.Controls.Add(newItem);

                previousItemControlName = newItem.Name;
            }//END foreach(var item in itemsTag.OrderBy(o=>o.CompletionPlanned))


            return column;
        }//END METHOD OrderItemsWithinPanel


        public static void RemoveItems(Panel panel)
        {

            var aa = panel.Controls.OfType<Panel>().Where(x => x.Name.StartsWith("pnlItem")).ToList();
            foreach (var a in aa)
                panel.Controls.Remove(a);
        }

        private static Panel createItemPanel(ItemDataClass item)
        {
            var newPanel = DefaultFormControls.GetItemPanel();
            newPanel.Name += item.Id;
            newPanel.Tag = item;
            newPanel.BringToFront();
            createLabel(DefaultFormControls.GetItemTitle(), item.Name, item.Name, newPanel);
            createLabel(DefaultFormControls.GetItemDescription(), item.Name, item.Description, newPanel);
            createLabel(DefaultFormControls.GetItemStartDateTime(), item.Name, item.CompletionPlanned.ToString("dd/MM/yyyy hh:mm:ss"), newPanel);


            return newPanel;

        }


        private static Point newLocation(Panel column)
        {
            if (!String.IsNullOrEmpty(previousItemControlName))
            {
                var prevpanel = column.Controls.OfType<Panel>().FirstOrDefault(x => x.Name.Equals(previousItemControlName));
                if (prevpanel != null)
                {
                    return new Point(0, prevpanel.Bottom + DefaultFormControls.EXTRABREAK);
                }//END if(prevpanel  != null)

            }//END if(!String.IsNullOrEmpty(previousItemControlName))

            return new Point(0, DefaultFormControls.GetItemColumnTitleBottom());
        }

        private static void createLabel(Label currentLabel, string name, string content, Panel newPanel)
        {
            currentLabel.Name += name;
            currentLabel.Text = content;
            currentLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(Label_mouseDown);
            currentLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(Label_mouseUp);
            newPanel.Controls.Add(currentLabel);
        }

         
        private static void Label_mouseDown(object sender, MouseEventArgs e)
        {
            Label label = (Label)sender;
            label.Parent.Focus();
        }


        private static void Label_mouseUp(object sender, MouseEventArgs e)
        {
            Label label = (Label)sender;
            label.Focus();
        }





    }
}


