using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Model.UniversalDataClasses;

namespace PanelProject
{
    public class MovingPanel1
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
            getFormControl(sender);
            getColumnPanels();
            if (columnBounded.Count > 0)
            {
                itemPanel = (Panel)sender;

                if (String.IsNullOrEmpty(currentParentPanel))
                {
                    var dataItem1 = (Model.UniversalDataClasses.ItemDataClass)itemPanel.Tag;
                    currentParentPanel = dataItem1.ItemControlName.ToString();
                }


                //Set new Column as the Parent coloumn
                itemPanel.Parent = columnBounded[0];
                var dataItem = (Model.UniversalDataClasses.ItemDataClass)itemPanel.Tag;
                Model.DiarySDF.Queries.ToDoQuery.UpdateStatus(dataItem.Id, GetStatus(currentParentPanel));

                PanelItemControl.OrderItemsWithinPanel(columnList.FirstOrDefault(x => x.Name.Equals(dataItem.ItemControlName)));

                dataItem.ItemControlName = columnBounded[0].Name;
                itemPanel.Tag = dataItem;
                //Set the new location for the item within the new column
                PanelItemControl.OrderItemsWithinPanel(columnBounded[0]);

                //Reset colours etc
                moving = false;
                currentParentPanel = String.Empty;
                itemPanel.BackColor = itemDefaultColour;
                removeHighlightColumns();
            }
            moving = false;
            currentParentPanel = String.Empty;
            itemPanel.BackColor = itemDefaultColour;


        }


        public static void item_MouseDown(object sender, MouseEventArgs e)
        {
            if (!moving)
            {

                itemPanel = (Panel)sender;

                if (String.IsNullOrEmpty(currentParentPanel))
                {
                    var dataItem1 = (ItemDataClass)itemPanel.Tag;
                    currentParentPanel = dataItem1.ItemControlName.ToString();
                }

                getFormControl(sender);
                getColumnPanels();
                sendColumnsToBack();


                Point point = itemPanel.PointToClient(Cursor.Position);
                itemPanel.BringToFront();
                itemPanel.Parent = FormComponents.MainControl.GetTaskTab();// itemPanel.Controls.Find("tabControl1", true)[0];
                itemPanel.Location = point;
                itemPanel.BackColor = itemMovingColour;
                moving = true;

                sendColumnsToBack();
            }
        }


        public static void Item_MouseMove(object sender, MouseEventArgs e)
        {
            getFormControl(sender);
            getColumnPanels();



            if (itemPanel == null)
                itemPanel = (Panel)sender;

            if (String.IsNullOrEmpty(currentParentPanel))
            {
                var dataItem1 = (ItemDataClass)itemPanel.Tag;
                currentParentPanel = dataItem1.ItemControlName.ToString();
            }

            boundedColumns();
            highlightBoundedColumn(false);
            removeHighlightColumns();
        }

        /// <summary>
        /// This method will see which Columns that the Item panel is overlapping or over.
        /// </summary>
        private static void boundedColumns()
        {
            columnBounded = new List<Panel>();
            foreach (var column in columnList)
            {
                if (itemPanel.Bounds.IntersectsWith(column.Bounds) || itemPanel.Bounds.IntersectsWith(column.Bounds))
                {
                    columnBounded.Add(column);
                }//END if (itemPanel.Bounds.IntersectsWith(column.Bounds) || itemPanel.Bounds.IntersectsWith(column.Bounds))
            }//END foreach(var column in columnList)
        }//END METHOD boundedColumns


        /// <summary>
        /// This method will set the Hove colour to the Column, which is within the bounded list, which is not the items parent
        /// </summary>
        private static void highlightBoundedColumn(bool reset)
        {
            var notParentColumn = columnBounded.FirstOrDefault(x => !x.Name.Equals(currentParentPanel));
            if (columnBounded.Count > 1)
                Console.WriteLine();

            if (notParentColumn != null)
            {
                Console.WriteLine(currentParentPanel + " =  " + notParentColumn.Name);
                if (reset)
                    notParentColumn.BackColor = defaultColour;
                else
                    notParentColumn.BackColor = hoverColour;



            }//END if(notParentColumn !=null)



            // removeHighlightColumns();
        }//END METHOD highlightBoundedColumn

        /// <summary>
        /// This will make all other columns from the bounded list apart from the one which is being set to the hover colour
        /// to default colour
        /// </summary>
        private static void removeHighlightColumns()
        {
            var notParentColumn = columnList.FirstOrDefault(x => !x.Name.Equals(currentParentPanel));
            if (notParentColumn != null)
            {
                foreach (var column in columnList.Where(x => !x.Name.Equals(notParentColumn.Name)))
                {
                    column.BackColor = defaultColour;
                }//END foreach (var column in columnBounded.Where(x => !x.Name.Equals(notParentColumn.Name)))
            }//END if (notParentColumn != null)
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
        /// **If property is null
        /// </summary>
        /// <param name="sender"></param>
        private static void getColumnPanels()
        {
            columnList = new List<Panel>();
            var tabpage = FormComponents.MainControl.GetTaskTab();

            var controls  = tabpage.Controls.OfType<Panel>().Where(x => x.Name.StartsWith("pnlColum")).ToList();
            //.Controls.OfType<Panel>().Where(x => x.Name.StartsWith("pnlColum")).ToList();

            foreach (var control in controls)
            {
                columnList.Add((Panel)control);
            }//END foreach(var control in controls)

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
