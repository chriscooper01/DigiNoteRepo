using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DiarySDF.Tables
{
   public  class DataTable
    {

        public int Id { get; set; }
        public int RecordId { get; set; }
        public string Name { get; set; }
        public string FullPath { get; set; }
        public byte[] File { get; set; }
        public DateTime Created { get; set; }
    }
}
