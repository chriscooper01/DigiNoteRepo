using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace Model.DiarySDF.Tables
{
    [Table(Name = "subjects")]
    public class SubjectTable
    {
        [Column(Name = "id", IsPrimaryKey = true, IsDbGenerated = true, DbType = "int Not Null IDENTITY")]
        public int Id { get; set; }

        [Column(Name = "categoryId",  DbType = "int Not Null", CanBeNull =false)]
        public int CategoryId { get; set; }

        [Column(Name = "body", DbType = "ntext Not Null", CanBeNull = false)]
        public string Body { get; set; }

        

    }
}
