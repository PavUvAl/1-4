using _1_4.HelpID;
using _1_4.Model;
using _1_4.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для WindowPersonalal.xaml
    /// </summary>
    public partial class WindowPersonal : Window
    {

        ObservableCollection<PersonalDPO> PersonalDPO = new ObservableCollection<PersonalDPO>();
        PersonalViewModel vmPersonal = new PersonalViewModel();
        RoleViewModel vmRole = new RoleViewModel();
        List<Role> roles = new List<Role>();

        public WindowPersonal()

        {
            InitializeComponent();

            foreach (Role r in vmRole.ListRole)
            {
                roles.Add(r);
            }

            foreach (var Personal in vmPersonal.ListPersonal)
            {
                PersonalDPO p = new PersonalDPO();
                p = p.CopyFromPerson(Personal);
                PersonalDPO.Add(p);
            }
            lvPersonal.ItemsSource = PersonalDPO;
        }
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNP wnPersonal = new WindowNP
            {
                Title = "Новый сотрудник",
                Owner = this
            };
            // формирование кода нового собрудника
            int maxIdPersonal = vmPersonal.MaxID() + 1;
            PersonalDPO per = new PersonalDPO
            {
                ID = maxIdPersonal,
                Birthday = DateTime.Now
            };
            wnPersonal.DataContext = per;
            wnPersonal.CbRole.ItemsSource = roles;

            if (wnPersonal.ShowDialog() == true)
            {
                Role r = (Role)wnPersonal.CbRole.SelectedValue;
                per.Role = r.NameRole;
                PersonalDPO.Add(per);
                Personal p = new Personal();
                p = p.CopyFromPersonDPO(per);
                vmPersonal.ListPersonal.Add(p);
            }
        }
        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNP wnPersonal = new WindowNP
            {
                Title = "Редактирование данных",
                Owner = this
            };
            PersonalDPO perDPO = (PersonalDPO)lvPersonal.SelectedValue;
            PersonalDPO tempPerDPO; 
            if (perDPO != null)
            {
                tempPerDPO = perDPO.ShallowCopy();
                wnPersonal.DataContext = tempPerDPO;
                wnPersonal.CbRole.ItemsSource = roles;
                wnPersonal.CbRole.Text = tempPerDPO.Role;
                if (wnPersonal.ShowDialog() == true)
                {
                    
                    Role r = (Role)wnPersonal.CbRole.SelectedValue;
                    perDPO.Role = r.NameRole;
                    perDPO.FirstName = tempPerDPO.FirstName;
                    perDPO.LastName = tempPerDPO.LastName;
                    perDPO.Birthday = tempPerDPO.Birthday;
                    lvPersonal.ItemsSource = null;
                    lvPersonal.ItemsSource = PersonalDPO;
                    
                    FindPersonal finder = new FindPersonal(perDPO.ID);
                    List<Personal> listPerson = vmPersonal.ListPersonal.ToList();
                    Personal p = listPerson.Find(new Predicate<Personal>(finder.PersonalPredicate));
                    p = p.CopyFromPersonDPO(perDPO);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать сотрудника для редактированния",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            PersonalDPO personal = (PersonalDPO)lvPersonal.SelectedItem;
            if (personal != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные этого сотрудника: \n" + personal.LastName +" "+personal.FirstName,
               
                "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    
                    PersonalDPO.Remove(personal);
                    Personal per = new Personal();
                    per = per.CopyFromPersonDPO(personal);
                    vmPersonal.ListPersonal.Remove(per);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать данные по сотруднику для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}