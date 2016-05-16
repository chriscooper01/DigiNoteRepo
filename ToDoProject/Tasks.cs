using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoProject
{
    public class Tasks
    {
        public static void LoadTasks(int catId, ref Panel start, ref Panel workingOn, ref Panel testing, ref Panel completed)
        {


           
            var items = Model.DiarySDF.Queries.ToDoQuery.ItemDataList(catId);
            foreach (var item in items.GroupBy(x => x.CurrentColumn).ToList())
            {


                switch(item.First().CurrentColumn)
                {
                    case "WorkingOn":
                        
                        ToDoProject.PanelItemControl.PopulatePanel(ref workingOn, "pnlColumWorkingOn", item.ToList());
                        ToDoProject.PanelItemControl.OrderItemsWithinPanel(workingOn);
                        break;
                    case "Planning":
                        ToDoProject.PanelItemControl.PopulatePanel(ref start, "pnlColumPlanning", item.ToList());
                        ToDoProject.PanelItemControl.OrderItemsWithinPanel(start);
                        break;
                    case "Testing":
                        ToDoProject.PanelItemControl.PopulatePanel(ref testing, "pnlColumTesting", item.ToList());
                        ToDoProject.PanelItemControl.OrderItemsWithinPanel(testing);
                        break;
                    case "Completed":
                        ToDoProject.PanelItemControl.PopulatePanel(ref completed, "pnlColumCompleted", item.ToList());
                        ToDoProject.PanelItemControl.OrderItemsWithinPanel(completed);
                        break;

                }






                Console.WriteLine("Current Column " + item.First().CurrentColumn);
            }
        }

        public static void UpdateTaskStatus(int taskId, string columnName)
        {


            

                switch (columnName.Trim().ToLower())
                {
                    case "pnlcolumworkingon":
                        Model.DiarySDF.Queries.ToDoQuery.UpdateStatus(taskId, "WorkingOn", true, false);                        
                        break;
                    case "pnlcolumplanning":
                        Model.DiarySDF.Queries.ToDoQuery.UpdateStatus(taskId, "Planning", false, false);                        
                        break;
                    case "pnlcolumtesting":
                        Model.DiarySDF.Queries.ToDoQuery.UpdateStatus(taskId, "Testing", false, false);
                        break;
                    case "pnlcolumcompleted":
                        Model.DiarySDF.Queries.ToDoQuery.UpdateStatus(taskId, "Completed", false, true);
                        break;

                }






             
        }

    }
}
