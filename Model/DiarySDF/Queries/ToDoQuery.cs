using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DiarySDF.Queries
{
    public class ToDoQuery : Model.DiarySDF.Helpers.LinqContext    
    {

        public static List<Model.DiarySDF.Tables.ToDoTable> List(int catId)
        {
            using (var context = GetContext())
            {
                var model = context.GetTable<Tables.ToDoTable>();

                return model.Where(x => x.CategoryId.Equals(catId)).ToList();
            }

        }

        public static Model.DiarySDF.Tables.ToDoTable Single(int taskId)
        {
            using (var context = GetContext())
            {
                var model = context.GetTable<Tables.ToDoTable>();

                return model.FirstOrDefault(x => x.Id.Equals(taskId));
            }

        }
        public static void UpdateStatus(int toDoId, string status, bool startDate, bool completeDate)
        {
            using (var context = GetContext())
            {
                var model = context.GetTable<Tables.ToDoTable>();

                var item = model.FirstOrDefault(x => x.Id.Equals(toDoId));
                if(item !=null)
                {
                    item.Status = status.Trim();
                    if (startDate)
                        item.StartDateTimeTrue = DateTime.Now;
                    if (completeDate)
                        item.CompleteDateTimeTrue = DateTime.Now;

                    context.SubmitChanges();
                }
            }
        }
        

        public static int Insert(string title, string body, int catId, DateTime planStart, DateTime planComplete)
        {
            int id = 0;
            if (!String.IsNullOrEmpty(body) || !String.IsNullOrEmpty(title))
            {
                using (var context = GetContext())
                {
                    var model = context.GetTable<Tables.ToDoTable>();
                    var t = new Tables.ToDoTable()
                    {
                        Body = body,
                        Title = title,
                         Active =true,
                        Completed =false,
                         CategoryId = catId,
                         StartDateTimePlanned = planStart,
                         CompleteDateTimePlan = planComplete,
                          Status = Model.DiarySDF.ENUM.TODOStatus.Planning.ToString()
                          
                    };
                    model.InsertOnSubmit(t);
                    context.SubmitChanges();
                    id = t.Id;
                }
            }

            return id;
        }

        public static int Edit(int id, string title, string body, int catId, DateTime planStart, DateTime planComplete)
        {
            
            if (!String.IsNullOrEmpty(body) || !String.IsNullOrEmpty(title))
            {
                using (var context = GetContext())
                {
                    var model = context.GetTable<Tables.ToDoTable>();
                    var t = model.FirstOrDefault(x => x.Id.Equals(id));


                    t.Body = body;
                        t.Title = title;
                        t.Active = true;
                        t.Completed = false;
                        t.CategoryId = catId;
                        t.StartDateTimePlanned = planStart;
                        t.CompleteDateTimePlan = planComplete;
                     

                    
                    
                    context.SubmitChanges();
                    id = t.Id;
                }
            }

            return id;
        }


        public static List<Model.UniversalDataClasses.ItemDataClass> ItemDataList(int catId)
        {
            using (var context = GetContext())
            {
                var model = context.GetTable<Tables.ToDoTable>();

                return model.Where(x => x.CategoryId.Equals(catId)).Select(s=> new Model.UniversalDataClasses.ItemDataClass()
                {
                    Id = s.Id,
                     CompletionPlanned = (DateTime) s.CompleteDateTimePlan,
                      StartedPlan = (DateTime) s.StartDateTimePlanned,
                       Description = s.Body,
                        CurrentColumn = s.Status,
                         Name = s.Title
                }).ToList();
            }

        }

    }
}
