using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DiarySDF.Queries
{
    public class ToDoCategoryQuery : Model.DiarySDF.Helpers.LinqContext    
    {

        public static List<Model.UniversalDataClasses.ListItem> List()
        {
            using (var context = GetContext())
            {
                var model = context.GetTable<Tables.ToDo_CategoryTable>();
                return model.Select(x => new Model.UniversalDataClasses.ListItem() { Id = x.Id, Date = x.DeadLine, Text = x.Body }).ToList();
            }
        }


        public static void Update(UniversalDataClasses.ListItem record)
        {
            using (var context = GetContext())
            {
                var model = context.GetTable<Tables.ToDo_CategoryTable>();
                var f = model.FirstOrDefault(x => x.Id.Equals(record.Id));
                if(f !=null)
                {
                    f.Body = record.Text;
                    f.DeadLine = record.Date;
                    context.SubmitChanges();
                }
                
            }
        }



        public static int Store(string body, DateTime deadLine)
        {
            int id = 0;
            if (!String.IsNullOrEmpty(body))
            {
                using (var context = GetContext())
                {
                    var model = context.GetTable<Tables.ToDo_CategoryTable>();
                    var t = new Tables.ToDo_CategoryTable()
                    {
                        Body = body,
                        DeadLine = deadLine
                    };
                    model.InsertOnSubmit(t);
                    context.SubmitChanges();
                    id = t.Id;
                }
            }

            return id;
        }

    }
}
