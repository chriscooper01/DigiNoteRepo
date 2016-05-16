using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DiarySDF.Tables
{
    [Table(Name = "Versions")]
    public class VersionTable
    {

        [Column(Name = "id", IsPrimaryKey = true, IsDbGenerated = true, DbType = "int Not Null IDENTITY")]
        public int Id { get; set; }


        [Column(Name = "Version", DbType = "int  Not Null", CanBeNull = false)]
        public int Version { get; set; }


    }
}
