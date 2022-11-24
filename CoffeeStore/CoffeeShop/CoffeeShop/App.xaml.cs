using CoffeeShop.Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CoffeeShop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            using (var context = DBContext.CreateInstance())
            {
                if (!context.Database.Exists())
                {
                    DBConfig.InitDB(context);
                }
            }
        }
    }
}
