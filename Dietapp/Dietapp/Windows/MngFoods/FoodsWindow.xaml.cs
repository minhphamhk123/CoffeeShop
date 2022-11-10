using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Dietapp.Windows
{
    /// <summary>
    /// Interaction logic for FoodsWindow.xaml
    /// </summary>
    public partial class FoodsWindow : Window
    {
        public FoodsWindow()
        {
            InitializeComponent();
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            wEditFood edit = new wEditFood();
            edit.ShowDialog();
        }
    }
}
