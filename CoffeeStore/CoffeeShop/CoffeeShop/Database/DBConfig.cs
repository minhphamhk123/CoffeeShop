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
        private static string dbInstanceName = "t1";
        private static string dataFolderpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string GetConnectionString()
        {
            return String.Format("Data Source=(LocalDb)\\{0};AttachDbFilename={1};", dbInstanceName, GetDBFilePath());
        }

        public static string GetDBFilePath()
        {
            // return Path.Combine(dataFolderpath, @"DemoDotNet\db\dietapp.mdf");
            return Path.GetFullPath("./CoffeeShopDB.mdf");
        }

        public static string GetDbLogFilePath()
        {
            return Path.GetFullPath("./CoffeeShopDB_log.ldf");
        }

        public static string GetInitSQLFilePath()
        {
            return Path.GetFullPath("./CoffeeShopDB.mdf.sql");
        }
        public static string GetInitBeverageFilePath()
        {
            return Path.GetFullPath("./BeverageName.sql");
        }

        public static bool EnsureSqlLocalDb(bool needRestart = false)
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
                else if(needRestart)
                {
                    manager.Restart();
                }
            }

            var fileFolderPath = Path.GetFullPath(Path.Combine(GetDBFilePath(), ".."));
            if (!Directory.Exists(fileFolderPath))
            {
                Directory.CreateDirectory(fileFolderPath);
            }

            return true;
        }

        public static void InitDB(DbContext context, bool force = false)
        {
            var db = context.Database;
            File.Delete(DBConfig.GetDbLogFilePath());
            db.Create();
            using (var transaction = db.BeginTransaction())
            {
                foreach (var sql in File.ReadLines(DBConfig.GetInitSQLFilePath(), Encoding.UTF8))
                {
                    db.ExecuteSqlCommand(sql);
                }
                foreach (var sql in File.ReadLines(DBConfig.GetInitBeverageFilePath(), Encoding.UTF8))
                {
                    db.ExecuteSqlCommand(sql);
                }
                transaction.Commit();
            }
        }
    }
}
