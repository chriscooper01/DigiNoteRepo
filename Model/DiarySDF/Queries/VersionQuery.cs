using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DiarySDF.Queries
{
    public class VersionQuery : Model.DiarySDF.Helpers.LinqContext
    {

        public static int Latest()
        {
            try
            {

                using (var context = GetContext())
                {
                    var a = context.ExecuteQuery<string>("SELECT  * FROM Versions");

                    var dataContextTableNames = (from tables in context.Mapping.GetTables()
                                                 select tables.TableName).ToList();

                    var model = context.GetTable<Tables.VersionTable>();
                  return model.ToList().OrderByDescending(x => x.Version).ToList()[0].Version;
                    
                }
            }
            catch
            {

            }
            return 0;
            
        }

        public static void Insert(int number)
        {

            try
            {
                using (var context = GetContext())
                {

                    var model = context.GetTable<Tables.VersionTable>();

                    var item = new Tables.VersionTable() { Version = number };
                    model.InsertOnSubmit(item);
                    context.SubmitChanges();

                }

            }
            catch { }
        }
    }
}
