using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace Model.DiarySDF.Tables
{
    [Table(Name = "records")]
    public class RecordTable
    {
        [Column(Name = "id", IsPrimaryKey = true, IsDbGenerated = true, DbType = "int Not Null IDENTITY")]
        public int Id { get; set; }

        [Column(Name = "categoryId", DbType = "int Not Null", CanBeNull = false)]
        public int CategoryId { get; set; }

        [Column(Name = "subjectId", DbType = "int Not Null", CanBeNull = false)]
        public int SubjectId { get; set; }

        [Column(Name = "toDoId", DbType = "int Not Null", CanBeNull = false)]
        public int ToDoId { get; set; }

        [Column(Name = "body", DbType = "ntext Not Null", CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public string Body { get; set; }
        
        [Column(Name = "dateTimeCreated", DbType = "DateTime Not Null", CanBeNull = false)]
        public DateTime DateTimeCreated { get; set; }
        
        [Column(Name = "timeSpent", DbType = "Decimal Not Null", CanBeNull = false)]
        public Decimal TimeSpent { get; set; }

        private EntityRef<Tables.SubjectTable> _subject;
        [Association(Name = "Subject", Storage = "_subject", ThisKey = "SubjectId", OtherKey = "Id")]
        public Tables.SubjectTable Subject
        {
            get { return this._subject.Entity; }
            set { this._subject.Entity = value; }
        }

        private EntityRef<Tables.CategoryTable> _category;
        [Association(Name = "Subject", Storage = "_category", ThisKey = "CategoryId", OtherKey = "Id")]
        public Tables.CategoryTable Category
        {
            get { return this._category.Entity; }
            set { this._category.Entity = value; }
        }


        public RecordTable()
        {
            _subject = new EntityRef<SubjectTable>();
            _category = new EntityRef<CategoryTable>();

        }
    }

}
