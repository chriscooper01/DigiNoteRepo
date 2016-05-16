using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DiarySDF.Helpers
{
    public class Update
    {

        public static void CreateDatabase(string location)
        {
            if(!File.Exists(location))
            {
                string connectionString = String.Format("DataSource=\"{0}\"; Password=\"mypassword\"",location);
                System.Data.SqlServerCe.SqlCeEngine en = new System.Data.SqlServerCe.SqlCeEngine(connectionString);
                en.CreateDatabase();

                createDBTables();

                Model.DiarySDF.Queries.VersionQuery.Insert(3);
            }
            
        }

        private static void createDBTables()
        {
            Model.DiarySDF.Helpers.LinqContext.CreateTable(typeof(Model.DiarySDF.Tables.RecordTable));
            Model.DiarySDF.Helpers.LinqContext.CreateTable(typeof(Model.DiarySDF.Tables.CategoryTable));
            Model.DiarySDF.Helpers.LinqContext.CreateTable(typeof(Model.DiarySDF.Tables.SubjectTable));
            Model.DiarySDF.Helpers.LinqContext.CreateTable(typeof(Model.DiarySDF.Tables.ToDoTable));
            Model.DiarySDF.Helpers.LinqContext.CreateTable(typeof(Tables.VersionTable));
            Model.DiarySDF.Helpers.LinqContext.CreateTable(typeof(Tables.ToDo_CategoryTable));
        }


        public static void UpdateDatabase()
        {
            int latestVersion = 4;
            int versionNumber = Model.DiarySDF.Queries.VersionQuery.Latest();
            if (versionNumber ==0)
            {
                //Model.DiarySDF.Helpers.LinqContext.CreateTable(typeof(Tables.VersionTable));
                Model.DiarySDF.Queries.VersionQuery.Insert(latestVersion);
                versionNumber = latestVersion;
            }
            if (versionNumber < 1)
            {
                
                //Model.DiarySDF.Helpers.LinqContext.DeleteTable("toDo_Categories");
                Model.DiarySDF.Helpers.LinqContext.CreateTable(typeof(Tables.ToDo_CategoryTable));
                Model.DiarySDF.Queries.VersionQuery.Insert(1);
            }
            if (versionNumber < 2)
            {
                Model.DiarySDF.Helpers.LinqContext.DeleteTable("toDos");
                Model.DiarySDF.Queries.VersionQuery.Insert(2);
            }
            if (versionNumber < 3)
            {
                Model.DiarySDF.Helpers.LinqContext.CreateTable(typeof(Tables.ToDoTable));
                Model.DiarySDF.Queries.VersionQuery.Insert(3);
            }
            if (versionNumber < 4)
            {
                Model.DiarySDF.Helpers.LinqContext.RunSQL("ALTER TABLE toDo_Categories ADD deadLine DATETIME NOT NULL DEFAULT(GETDATE())");
                Model.DiarySDF.Queries.VersionQuery.Insert(4);
            }

        }

    }
}
