using _1_4.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_4.ViewModel
{
    public class PersonalViewModel
    {
        public ObservableCollection<Personal> ListPersonal { get; set; } =
            new ObservableCollection<Personal>();

        public PersonalViewModel()
        {
            this.ListPersonal.Add(
            new Personal
            {
                ID = 1,
                RoleID = 1,
                FirstName = "Алексей",
                LastName = "Беркутов",
                Birthday = new DateTime(2000, 05, 05)
            });

            this.ListPersonal.Add(
            new Personal
            {
                ID = 2,
                RoleID = 2,
                FirstName = "Егор",
                LastName = "Красюков",
                Birthday = new DateTime(2000, 09, 28)
            });

            this.ListPersonal.Add(
            new Personal
            {
                ID = 3,
                RoleID = 3,
                FirstName = "Максим",
                LastName = "Губарев",
                Birthday = new DateTime(2000, 10, 30)
            });

            this.ListPersonal.Add(
            new Personal
            {
                ID = 4,
                RoleID = 4,
                FirstName = "Старченко",
                LastName = "Анастасия",
                Birthday = new DateTime(2001, 07, 15)
            });
        }
        public int MaxID()
        {
            int max = 0;
            foreach (var r in this.ListPersonal)
            {
                if (max < r.ID)
                {
                    max = r.ID;
                };
            }
            return max;
        }
    }

}
