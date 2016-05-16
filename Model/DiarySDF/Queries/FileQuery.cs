using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DiarySDF.Queries
{
    public class FileQuery : Model.DiarySDF.Helpers.LinqContext
    {
        public static void Insert(int recordId, string name, byte[] file)
        {
            using (var context = GetContext())
            {
                var model = context.GetTable<Tables.FileTable>();
                var data = new Tables.FileTable()
                {
                    RecordId = recordId,
                    Created = DateTime.Now,
                    Name = name,
                    TheFile = file
                };
                model.InsertOnSubmit(data);
                context.SubmitChanges();
                
            }
        }

        public static Tuple<string,byte[]> GetFile(int recordId)
        {
            using (var context = GetContext())
            {
                var model = context.GetTable<Tables.FileTable>();
                var data = model.FirstOrDefault(x => x.Id.Equals(recordId));
                if(data!=null)
                {
                    return  new Tuple<string, byte[]>(data.Name, data.TheFile);
                    

                }
                return null;
            }
        }
    }
}
