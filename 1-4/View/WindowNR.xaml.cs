using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _1_4.View
{
    /// <summary>
    /// Логика взаимодействия для WindowNR.xaml
    /// </summary>
    public partial class WindowNR : Window
    {
        public WindowNR()
        {
            InitializeComponent();
        }
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
       
    }  
    
}
