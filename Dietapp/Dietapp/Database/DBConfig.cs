using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using MartinCostello.SqlLocalDb;

namespace Dietapp.Database
{
    internal class DBConfig
    {
        public static string GetConnectionString()
        {
            //@"Data Source=.\sqlexpress;Initial Catalog=QuanLyKhachSan;Integrated Security=True";
            return String.Format("Data Source=(LocalDb)\\t1;AttachDbFilename={0};", GetDBFilePath()); // sqllocaldb start MSSQLLocalDB
            //return String.Format(@"Data Source=.\\SQLEXPRESS;AttachDbFilename={0};Integrated Security=True;Connect Timeout=30;User Instance=True", GetDBFilePath());

        }

        public static string GetDBFilePath()
        {
            string dataFolderpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return Path.Combine(dataFolderpath, @"DemoDotNet\db\dietapp.mdf");
        }

        public static bool EnsureSqlLocalDb()
        {

            ISqlLocalDbApi localDB = new SqlLocalDbApi();

            if (!localDB.IsLocalDBInstalled())
            {
                return false;
            }
            else
            {
                ISqlLocalDbInstanceInfo instance = localDB.GetInstanceInfo("t1");
                ISqlLocalDbInstanceManager manager = instance.Manage();

                if (!instance.Exists)
                {
                    localDB.CreateInstance("t1", "15.0.2000.5");
                }

                if (!instance.IsRunning)
                {
                    manager.Start();
                }
            }

            var fileFolderPath = Path.GetFullPath(Path.Join(GetDBFilePath(), ".."));
            if (!Directory.Exists(fileFolderPath)){
                Directory.CreateDirectory(fileFolderPath);
            }

            using (var db = DBContext.CreateInstance())
            {
                var dbTime = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").First();
                Debug.WriteLine("Database current time = " + dbTime.ToLongDateString());
            }

            return true;
        }
    }
}
