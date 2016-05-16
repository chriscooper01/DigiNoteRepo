using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace Model.DiarySDF.Tables
{
    [Table(Name = "categories")]
    public class CategoryTable
    {
        [Column(Name = "id", IsPrimaryKey = true, IsDbGenerated = true, DbType = "int Not Null IDENTITY")]
        public int Id { get; set; }


        [Column(Name = "body", DbType = "ntext Not Null", CanBeNull = false)]
        public string Body { get; set; }

        
        public CategoryTable()
        {
            //_subject = new EntitySet<SubjectTable>();
        }
    }
}
