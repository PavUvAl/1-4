using _1_4.Model;
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
using System.Windows.Shapes;

namespace _1_4.View
{
    /// <summary>
    /// Логика взаимодействия для WindowRole.xaml
    /// </summary>
    public partial class WindowRole : Window
    {
        RoleViewModel vmRole;
        public WindowRole()
        {
            InitializeComponent();
            vmRole = new RoleViewModel();
            lvRole.ItemsSource = vmRole.ListRole;
        }

        private void lvRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNR wnRole = new WindowNR
            {
                Title = "Новая должность",
                Owner = this
            };

            int maxIDRole = vmRole.MaxID() + 1;
            Role role = new Role
            {
                ID = maxIDRole
            };

            wnRole.DataContext = role;
            if (wnRole.ShowDialog() == true)
            {
                vmRole.ListRole.Add(role);
            }
        }
        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNR wnRole = new WindowNR
            {
                Title = "Редактирование должности",
                Owner = this
            };

            Role role = lvRole.SelectedItem as Role;
            if (role != null)
            {
                Role tempRole = role.ShallowCopy();
                wnRole.DataContext = tempRole;
                if (wnRole.ShowDialog() == true)
                {
                    role.NameRole = tempRole.NameRole;
                    lvRole.ItemsSource = null;
                    lvRole.ItemsSource = vmRole.ListRole;
                }
            }
            else
            {
                MessageBox.Show("Для выполнения действия нужно выбрать должность, которую вы хотите редактировать", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Role role = (Role)lvRole.SelectedItem;
            if (role != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные по должности: " +
                role.NameRole, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    vmRole.ListRole.Remove(role);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать должность для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}
