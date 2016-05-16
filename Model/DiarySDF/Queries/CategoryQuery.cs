using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DiarySDF.Queries
{
    public class CategoryQuery : Model.DiarySDF.Helpers.LinqContext
    {
        public static int Store(string body)
        {
            int id = 0;
            if (!String.IsNullOrEmpty(body))
            {
                using (var context = GetContext())
                {
                    var model = context.GetTable<Tables.CategoryTable>();
                    var t = new Tables.CategoryTable()
                    {
                        Body = body
                    };
                    model.InsertOnSubmit(t);
                    context.SubmitChanges();
                    id = t.Id;
                }
            }

            return id;
        }




        public static List<Model.UniversalDataClasses.ListItem> List()
        {
            using (var context = GetContext())
            {
                var model = context.GetTable<Tables.CategoryTable>();
                return model.Select(x => new Model.UniversalDataClasses.ListItem() { Id = x.Id, Text = x.Body }).ToList();
            }
        }

        public static string Single(int id)
        {


            try
            {

                using (var context = GetContext())
                {
                    var model = context.GetTable<Tables.CategoryTable>();
                    var item = model.FirstOrDefault(x => x.Id.Equals(id));
                    if (item != null)
                        return item.Body.Trim();

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
