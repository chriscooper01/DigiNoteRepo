using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PanelProject
{
    public class DefaultFormControls
    {
        public static int EXTRABREAK = 5;
        private static Form df;
        private static Panel pnlColumn;

        private static Form defaultForm 
        {
            get
            {
                if(df==null)
                {
                    df = new DefaultForm();
                }
                return df;
            }
        }



        

        public static Panel GetColumn()
        {
            pnlColumn = defaultForm.Controls.OfType<Panel>().SingleOrDefault(x => x.Name.StartsWith("pnlColumn"));
            return pnlColumn;
        }


        private static Panel pnlItem;
        
        public static Panel GetItemPanel()
        {

            if (pnlColumn == null)
                GetColumn();

            if(pnlItem == null)
                pnlItem = pnlColumn.Controls.OfType<Panel>().SingleOrDefault(x => x.Name.StartsWith("pnlItem"));

            var item = new Panel();
            item.Location = pnlItem.Location;
            item.Name = pnlItem.Name;
            item.Size = pnlItem.Size;
            item.AllowDrop = pnlItem.AllowDrop;
            item.BorderStyle = pnlItem.BorderStyle;
            item.AutoScroll = pnlItem.AutoScroll;
            return item;
        }


        public static Label GetItemTitle()
        {
            if (pnlColumn == null)
                GetColumn();

            if(pnlItem == null)
                pnlItem = pnlColumn.Controls.OfType<Panel>().SingleOrDefault(x => x.Name.StartsWith("pnlItem"));


            var title = pnlItem.Controls.OfType<Label>().SingleOrDefault(x => x.Name.StartsWith("lblItemTitle"));
            return createNewLabelInstance(title);
        }

        public static Label GetItemDescription()
        {
            
            if (pnlColumn == null)
                GetColumn();

            if (pnlItem == null)
                pnlItem = pnlColumn.Controls.OfType<Panel>().SingleOrDefault(x => x.Name.StartsWith("pnlItem"));


            var title = pnlItem.Controls.OfType<Label>().SingleOrDefault(x => x.Name.StartsWith("lblItemDesciption"));
            return createNewLabelInstance(title);
           
        }

        public static Label GetItemStartDateTime()
        {
          

            if (pnlColumn == null)
                GetColumn();

            if (pnlItem == null)
                pnlItem = pnlColumn.Controls.OfType<Panel>().SingleOrDefault(x => x.Name.StartsWith("pnlItem"));


            var title = pnlItem.Controls.OfType<Label>().SingleOrDefault(x => x.Name.StartsWith("lblItemStart"));
            return createNewLabelInstance(title);
            
        }


        public static int GetItemColumnTitleBottom()
        {
            if (pnlColumn == null)
                GetColumn();

            var n = pnlColumn.Controls.OfType<Label>().SingleOrDefault(x => x.Name.StartsWith("lblColumnTitle"));

            return n.Bottom + EXTRABREAK;
        }


        private static Label createNewLabelInstance(Label current)
        {
            var label = new Label();
            label.Name = current.Name;
            label.Font = current.Font;
            label.Size = current.Size;
            label.Location = current.Location;
            label.AutoSize = current.AutoSize;
            label.AutoEllipsis = current.AutoEllipsis;
            label.TextAlign = current.TextAlign;
            label.BorderStyle = current.BorderStyle;
            return label;
        }
    }
}
