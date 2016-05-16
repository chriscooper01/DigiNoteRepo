using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Model.UniversalDataClasses;

namespace ToDoProject
{
    public class PanelMoving
    {
 
        /// <summary>
        /// This is the Column which is Given the focus from the Item Click event
        /// </summary>
        public static string FocusedColumn;

        private static Color hoverColour = Color.Aqua;
        private static Color defaultColour = Color.Transparent;
        private static Color itemMovingColour = Color.Turquoise;
        private static Color itemDefaultColour = Color.Transparent;

        private static string currentParentPanel;
        private static List<Panel> columnList;
        private static List<Panel> columnBounded;
        private static Panel itemPanel;
        private static Form frmControl;

        private static bool moving;

        /// <summary>
        /// This will make sure the Item panel has all the needed 
        /// events for the Hove logic
        /// </summary>
        /// <param name="item"></param>
        public static void SetItemEvents(Panel item)
        {

            item.Click += new System.EventHandler(Item_ClickEvent);
            item.MouseDown += new System.Windows.Forms.MouseEventHandler(item_MouseDown);
        //    item.GotFocus += new EventHandler(item_Focus);
      //      item.LostFocus += new EventHandler(item_Lost);
            item.MouseMove += new System.Windows.Forms.MouseEventHandler(Item_MouseMove);
            item.BringToFront();
            ControlExtension.Draggable(item, true);
        }//END METHOD SetItemEvents


        /// <summary>
        /// This event is Invoked once the Click has been released on the items panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void Item_ClickEvent(object sender, EventArgs e)
        {

            lockDownItem(sender);
        }


        public static void item_MouseDown(object sender, MouseEventArgs e)
        {
            setItemPanelToMove(sender);
        }


        public static void Item_MouseMove(object sender, MouseEventArgs e)
        {
            getFormControl(sender);
            getColumnPanels();

            
            itemPanel = (Panel)sender;
            if (itemPanel.Name.StartsWith("pnlItem"))
            {
                boundedColumns();
                removeHighlightColumns();
                highlightBoundedColumn(false);

            }


        }


        public static void item_Focus(object sender, EventArgs e)
        {
            setItemPanelToMove(sender);
        }

        public static void item_Lost(object sender, EventArgs e)
        {
            lockDownItem(sender); 
        }

        private static void setItemPanelToMove(object sender)
        {
            if (!moving)
            {

                var item = (Panel)sender;
                if(item != null)
                {
                    if (item.Name.StartsWith("pnlItem"))
                    {
                        var dataItem1 = (ItemDataClass)item.Tag;
                        if (String.IsNullOrEmpty(currentParentPanel))
                        {

                            currentParentPanel = dataItem1.ItemControlName.ToString();
                        }

                        getFormControl(sender);
                        getColumnPanels();
                        sendColumnsToBack();


                        Point point = item.PointToClient(Cursor.Position);
                        item.BringToFront();
                        item.Parent = FormComponents.MainControl.GetTaskTab();// itemPanel.Controls.Find("tabControl1", true)[0];
                        item.Location = point;
                        item.BackColor = itemMovingColour;
                        moving = true;

                        sendColumnsToBack();

                        Console.WriteLine(String.Format("Mouse down item name {0} parent column name (1)", item.Name, currentParentPanel));
                    }//END if(itemPanel.Name.StartsWith("pnlItem"))
                }
                

            }
        }

        private static void lockDownItem(object sender)
        {
            getFormControl(sender);
            getColumnPanels();
            if (columnBounded.Count > 0)
            {
                currentParentPanel = String.Empty;
                itemPanel = (Panel)sender;


                //Set new Column as the Parent coloumn
                itemPanel.Parent = columnBounded[0];
                var dataItem = (Model.UniversalDataClasses.ItemDataClass)itemPanel.Tag;
                dataItem.ItemControlName = columnBounded[0].Name;
                itemPanel.Tag = dataItem;


                Tasks.UpdateTaskStatus(dataItem.Id, itemPanel.Parent.Name);
                PanelItemControl.OrderItemsWithinPanel(columnList.FirstOrDefault(x => x.Name.Equals(dataItem.ItemControlName)));

                //Set the new location for the item within the new column
                //Reset colours etc

                currentParentPanel = String.Empty;
                itemPanel.BackColor = itemDefaultColour;


            }
            //Wipe bounded list and rest all column colour to default
            columnBounded.Clear();
            removeHighlightColumns();
            moving = false;
            currentParentPanel = String.Empty;
            itemPanel.BackColor = itemDefaultColour;
            itemPanel = null;
        }

        /// <summary>
        /// This method will see which Columns that the Item panel is overlapping or over.
        /// </summary>
        private static void boundedColumns()
        {
            columnBounded = new List<Panel>();
            foreach (var column in columnList.Where(x=>x.Bounds.IntersectsWith(itemPanel.Bounds)).ToList())
            {
                columnBounded.Add(column);
                column.BackColor = hoverColour;
                Console.WriteLine("Column bound" + column.Name);
            
            }//END foreach(var column in columnList)
        }//END METHOD boundedColumns


        /// <summary>
        /// This method will set the Hove colour to the Column, which is within the bounded list, which is not the items parent
        /// </summary>
        private static void highlightBoundedColumn(bool reset)
        {
            foreach (var column in columnList)
            {
                if (columnBounded.FirstOrDefault(x => x.Name.Equals(column.Name)) == null)
                //{
                //    column.BackColor = hoverColour;
                //    Console.WriteLine("Hover colour set to: " + column.Name);
                //}else
                {
                    column.BackColor = defaultColour;
                    Console.WriteLine("Defult colour set to: " + column.Name);
                }
            }

        }//END METHOD highlightBoundedColumn

        /// <summary>
        /// This will make all other columns from the bounded list apart from the one which is being set to the hover colour
        /// to default colour
        /// </summary>
        private static void removeHighlightColumns()
        {
                //foreach (var column in columnList.Where(x => !columnBounded.Contains(x)))
                //{
                //    column.BackColor = defaultColour;
                //}//END foreach (var column in columnBounded.Where(x => !x.Name.Equals(notParentColumn.Name)))
            

        }//END METHOD removeHighlightColumns




        /// <summary>
        /// This method will make sure the Column panels are at the back of everything else
        /// This is so the item panel, moves over them and not behind them
        /// </summary>
        private static void sendColumnsToBack()
        {
            foreach (var column in columnList)
            {
                column.SendToBack();
            }//END foreach(var column in columnList)
        }//END METHOD sendColumnsToBack

        /// <summary>
        /// This will get and set the columnList global property with the 
        /// content of the sender Controls, which have a name starting with pnlColumn.          
        /// </summary>
        /// <param name="sender"></param>
        private static void getColumnPanels()
        {
            if(columnList == null || columnList.Count==0)
            {
                columnList = new List<Panel>();
                var tabpage = FormComponents.MainControl.GetTaskTab();
                var controls = tabpage.Controls.OfType<Panel>().Where(x => x.Name.StartsWith("pnlColum")).ToList();
                foreach (var control in controls)
                {
                    columnList.Add((Panel)control);
                }//END foreach(var control in controls)

            }//END if(columnList == null || columnList.Count==0)
            
        }//END METHOD getColumnPanels


        /// <summary>
        /// This will get and set the frmControl global property with the 
        /// content of the sender Controls
        /// **If property is null
        /// </summary>
        /// <param name="sender"></param>
        private static void getFormControl(object sender)
        {
            if (frmControl == null)
            {
                var panel = (Panel)sender;
                var icontrols = panel.GetContainerControl();
                frmControl = (Form)icontrols;


            }//END if(columnList == null)

        }//END METHOD getColumnPanels
    }
}
