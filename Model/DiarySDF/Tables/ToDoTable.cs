using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace Model.DiarySDF.Tables
{
    [Table(Name = "toDos")]
    public class ToDoTable
    {
        [Column(Name = "id", IsPrimaryKey = true, IsDbGenerated = true, DbType = "int Not Null IDENTITY")]
        public int Id { get; set; }

        [Column(Name = "CategoryId", DbType = "int Not Null", CanBeNull = false)]
        public int CategoryId { get; set; }

        [Column(Name = "status", DbType = "nvarchar(250) Not Null", CanBeNull = false)]
        public string Status { get; set; }


        [Column(Name = "title", DbType = "nvarchar(250) Not Null", CanBeNull = false)]
        public string Title { get; set; }

        [Column(Name = "body", DbType = "ntext Not Null", CanBeNull = false,UpdateCheck =UpdateCheck.Never)]
        public string Body { get; set; }
                
        [Column(Name = "startDateTimePlanned", DbType = "DateTime  Null", CanBeNull = true)]
        public Nullable<DateTime> StartDateTimePlanned { get; set; }
        
        [Column(Name = "startDateTimeTrue", DbType = "DateTime  Null", CanBeNull = true)]
        public Nullable<DateTime>  StartDateTimeTrue { get; set; }

        [Column(Name = "completeDateTimePlan", DbType = "DateTime  Null", CanBeNull = true)]
        public Nullable<DateTime> CompleteDateTimePlan { get; set; }
        

        [Column(Name = "completeDateTimeTrue", DbType = "DateTime  Null", CanBeNull = true)]
        public Nullable<DateTime> CompleteDateTimeTrue { get; set; }


        [Column(Name = "Completed", DbType = "bit Not Null", CanBeNull = false)]
        public bool Completed { get; set; }


        [Column(Name = "Active", DbType = "bit Not Null", CanBeNull = false)]
        public bool Active { get; set; }

    }
}
