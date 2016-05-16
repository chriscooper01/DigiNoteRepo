using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Extended.mainWindow
{
    public class MainMenuCategories
    {
        public static void buildMenu(ref System.Windows.Controls.Menu mainMenu)
        {
            mainMenu.Items.Clear();
            mainMenu.Items.Add(setMenuItem());
        }


        private static System.Windows.Controls.MenuItem setMenuItem()
        {
            var item = new System.Windows.Controls.MenuItem();
            item.Name = "mitCat";
            item.Header = "Category";
            foreach (var content in Model.DiarySDF.Queries.CategoryQuery.List())
            {
                item.Items.Add(setItem(content,true));
            }


            return item;
        }





        private static List<System.Windows.Controls.MenuItem> setCategoryItems()
        {
            var items = new List<System.Windows.Controls.MenuItem>();
            foreach(var item in Model.DiarySDF.Queries.CategoryQuery.List())
            {
                items.Add(setItem(item,true));
            }



            return items;
        }



        private static System.Windows.Controls.MenuItem setItem(Model.UniversalDataClasses.ListItem content, bool child)
        {
            var item = new System.Windows.Controls.MenuItem();
            item.Name = "mitCat"+ content.Id.ToString();
            item.Header = content.Text;
            if(child)
                item.Items.Add(setItem(new Model.UniversalDataClasses.ListItem() { Id = content.Id * 2, Text = "New" }, false));
            else
                item.Click += new System.Windows.RoutedEventHandler(MainWindow.menuItemClick_Item);


            return item;
        }



        private static System.Windows.Controls.Button setButtonItem()
        {
            var item = new System.Windows.Controls.Button();
            item.Name = "btnCatNew";
            item.Content = "New";
            item.Tag = "New";
            item.ClickMode = System.Windows.Controls.ClickMode.Press;
            item.Click += new System.Windows.RoutedEventHandler(MainWindow.menuItemClick_Item);


            return item;
        }

    }
}
