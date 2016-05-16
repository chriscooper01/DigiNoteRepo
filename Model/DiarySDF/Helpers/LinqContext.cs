using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Model.DiarySDF.Helpers
{
    public class LinqContext
    {

        public static string DBLocation { get
            {

                string sdfLocation = "DigitalDiary.sdf";
                try
                {
                    sdfLocation = Path.Combine(MainTempFolder(), "DigitalDiary.sdf");
                    if (!File.Exists(sdfLocation))
                       Update.CreateDatabase(sdfLocation);

                }
                catch { }

                var applicationLocation = System.Windows.Forms.Application.StartupPath;
                

                return Path.Combine(applicationLocation, sdfLocation);
            }
        }
        /// <summary>
        /// This looks for the HealthOptions folder within the Application Folder
        /// If not present it will create a new folder and return the full path
        /// </summary>
        /// <returns></returns>
        public static string MainTempFolder()
        {
            string location = String.Empty;

            location = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            location = Path.Combine(location, "DigiNote");

            if (!Directory.Exists(location))
                Directory.CreateDirectory(location);

            return location;
        }


        public static string ConnectionString
        {
            get
            {
              
                string password = String.Empty;
                string condet = String.Empty;

                string DbConnection = @"Data Source={0};{1}";

              

                if (File.Exists(DBLocation))
                {
                    password = "mypassword";
                    condet = String.Format(DbConnection, DBLocation, String.Format("Password={0}", password));

                }


                return condet;

            }
        }

        protected static DataContext GetContext()
        {

            try
            {
              
                DataContext ContextDatabase = new DataContext(ConnectionString);
                return ContextDatabase;


            }
            catch (Exception e)
            {

            }
            return null;
        }

        public static void CreateTable(Type linqTableClass)
        {
            using (var tempDc = GetContext())
            {
                var metaTable = tempDc.Mapping.GetTable(linqTableClass);
                var typeName = "System.Data.Linq.SqlClient.SqlBuilder";
                var type = typeof(DataContext).Assembly.GetType(typeName);
                var bf = BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.InvokeMethod;
                var sql = type.InvokeMember("GetCreateTableCommand", bf, null, null, new[] { metaTable });
                var sqlAsString = sql.ToString();
                tempDc.ExecuteCommand(sqlAsString);
            }
        }

        public static void DeleteTable(string name)
        {
            using (var tempDc = GetContext())
            {
                
                tempDc.ExecuteCommand(String.Format("DROP Table {0}",name));
            }
        }

        public static void RunSQL(string sql)
        {
            using (var tempDc = GetContext())
            {

                tempDc.ExecuteCommand(sql);
            }
        }

       

    }
}
