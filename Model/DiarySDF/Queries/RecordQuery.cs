using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DiarySDF.Queries
{
   public class RecordQuery : Model.DiarySDF.Helpers.LinqContext
    {
        public static int Create(int catId, int subId)
        {
            int id = 0;
            if (catId > 0 && subId >0)
            {
                using (var context = GetContext())
                {
                    var model = context.GetTable<Tables.RecordTable>();
                    var t = new Tables.RecordTable()
                    {
                        CategoryId = catId,
                         SubjectId = subId,
                          DateTimeCreated = DateTime.Now,
                           ToDoId = 0,
                            Body = String.Empty                             
                    };
                    model.InsertOnSubmit(t);
                    context.SubmitChanges();
                    id = t.Id;
                }
            }

            return id;
        }

        public static void Update(int recordId, string body, decimal timeTakenSoFarInMilliseconds)
        {
            using (var context = GetContext())
            {
                var model = context.GetTable<Tables.RecordTable>();
                var r = model.SingleOrDefault(x => x.Id.Equals(recordId));
                if(r != null)
                {
                    r.Body = body;
                    r.TimeSpent = timeTakenSoFarInMilliseconds;
                    context.SubmitChanges();
                }
                
                
            }
        }

        public static List<Tables.RecordTable> List(int subjectId, int categoryId)
        {

            using (var context = GetContext())
            {
                var model = context.GetTable<Tables.RecordTable>();
                return model.Where(x => x.SubjectId.Equals(subjectId) && x.CategoryId.Equals(categoryId)).OrderBy(x=>x.DateTimeCreated).ToList();              

            }

        }


        public static List<Tables.RecordTable> List(DateTime date)
        {

            using (var context = GetContext())
            {
                var model = context.GetTable<Tables.RecordTable>();
                var i =model.Where(x => x.DateTimeCreated >= date).OrderBy(x => x.DateTimeCreated).ToList();
                return i;
            }

        }
    }
}
