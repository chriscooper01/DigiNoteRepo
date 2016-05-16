using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DiarySDF.Tables
{
    [Table(Name = "files")]
    public class FileTable
    {

        [Column(Name = "id", IsPrimaryKey = true, IsDbGenerated = true, DbType = "int Not Null IDENTITY")]
        public int Id { get; set; }

        [Column(Name = "recordId", DbType = "int Not Null", CanBeNull = false)]
        public int RecordId { get; set; }

        [Column(Name = "Name", DbType = "nvarchar(100) Not Null", CanBeNull = false)]
        public string Name { get; set; }

        [Column(Name = "theFIle", DbType = "image Not Null", CanBeNull = false)]
        public byte[] TheFile { get; set; }

        [Column(Name = "created", DbType = "DateTime Not Null", CanBeNull = false)]
        public DateTime Created { get; set; }

    }
}
