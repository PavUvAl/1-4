﻿using _1_4.View;
using _1_4.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _1_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Personal_OnClick(object sender, RoutedEventArgs e)
        {
            WindowPersonal wPersonal = new WindowPersonal();
            wPersonal.Show();
        }
        private void Role_OnClick(object sender, RoutedEventArgs e)
        {
            WindowRole wRole = new WindowRole();
            wRole.Show();
        }

    }
}
