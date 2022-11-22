using MartinCostello.SqlLocalDb;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Database
{
    internal class DBConfig
    {
        private static string dbInstanceName = "test1";
        public static string GetConnectionString()
        {
            return String.Format("Data Source=(LocalDb)\\{0};AttachDbFilename={1};", dbInstanceName, GetDBFilePath());
        }

        public static string GetDBFilePath()
        {
            string dataFolderpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            // return Path.Combine(dataFolderpath, @"DemoDotNet\db\dietapp.mdf");
            return Path.GetFullPath("./CoffeeShopDB.mdf");
        }

        public static string GetInitSQLFilePath()
        {
            return Path.GetFullPath("./CoffeeShopDB.mdf.sql");
        }

        public static string GetDbLogFilePath()
        {
            return Path.GetFullPath("./CoffeeShopDB_log.ldf");
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
                if (!localDB.InstanceExists(dbInstanceName))
                {
                    localDB.CreateInstance(dbInstanceName, localDB.LatestVersion);
                }

                ISqlLocalDbInstanceInfo instance = localDB.GetInstanceInfo(dbInstanceName);
                ISqlLocalDbInstanceManager manager = instance.Manage();
                if (!instance.IsRunning)
                {
                    manager.Start();
                }
                else
                {
                    manager.Restart();
                }
            }

            var fileFolderPath = Path.GetFullPath(Path.Combine(GetDBFilePath(), ".."));
            if (!Directory.Exists(fileFolderPath))
            {
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
