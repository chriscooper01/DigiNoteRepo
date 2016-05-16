using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DiarySDF.Tables
{
    [Table(Name = "toDo_Categories")]
    public class ToDo_CategoryTable
    {
        [Column(Name = "id", IsPrimaryKey = true, IsDbGenerated = true, DbType = "int Not Null IDENTITY")]
        public int Id { get; set; }


        [Column(Name = "body", DbType = "ntext Not Null", CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public string Body { get; set; }


        [Column(Name = "deadLine", DbType = "DateTime Null", CanBeNull = true)]
        public Nullable<DateTime> DeadLine { get; set; }

    }
}
