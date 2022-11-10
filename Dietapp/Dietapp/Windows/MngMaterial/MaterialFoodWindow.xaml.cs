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
    /// Interaction logic for MaterialFoodWindow.xaml
    /// </summary>
    public partial class MaterialFoodWindow : Window
    {
        public MaterialFoodWindow()
        {
            InitializeComponent();
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            wEditMaterialFood edit = new wEditMaterialFood();
            edit.ShowDialog();
        }
    }
}
