using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DiarySDF.Queries
{
    public class SubjectQuery : Model.DiarySDF.Helpers.LinqContext
    {

        public static int Store(string body, int categoryId)
        {
            int id = 0;
            if (!String.IsNullOrEmpty(body))
            {
                using (var context = GetContext())
                {
                    var model = context.GetTable<Tables.SubjectTable>();
                    var t = new Tables.SubjectTable()
                    {
                        Body = body, CategoryId = categoryId

                    };
                    model.InsertOnSubmit(t);
                    context.SubmitChanges();
                    id = t.Id;
                }
            }

            return id;
        }

        public static List<Model.UniversalDataClasses.ListItem> List(int categoryId)
        {
            using (var context = GetContext())
            {
                var model = context.GetTable<Tables.SubjectTable>();
                return model.Where(x=>x.CategoryId.Equals(categoryId)).Select(x => new Model.UniversalDataClasses.ListItem() { Id = x.Id, Text = x.Body }).ToList();
            }
        }



        public static string Single(int id)
        {
            try
            {

                using (var context = GetContext())
                {
                    var model = context.GetTable<Tables.SubjectTable>();
                    var i =  model.Select(x => new Model.UniversalDataClasses.ListItem() { Id = x.Id, Text = x.Body }).FirstOrDefault(x => x.Id.Equals(id));

                    
                    if (i!= null)
                        return i.Text.Trim();

                    return String.Empty;
                }
            }
            catch
            {

            }

            return id.ToString();

            
           
            
        }
    }
}
