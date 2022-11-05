using Dietapp.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Dietapp.Database;
using TodoApp1;

namespace Dietapp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (!DBConfig.EnsureSqlLocalDb())
            {
                var window = new MissingFeatureWindow();
                window.Closed += (s, e) =>
                {
                    this.Show();
                    MainWindow_Loaded(this, new RoutedEventArgs());
                };
                this.Hide();
                window.ShowDialog();
            }
        }
    }
}
