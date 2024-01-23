using _1_4.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_4.ViewModel
{
    public class RoleViewModel
    {
        public ObservableCollection<Role> ListRole { get; set; } =
            new ObservableCollection<Role>();
        public RoleViewModel()
        {
            this.ListRole.Add(new Role
            {
                ID = 1,
                NameRole = "Директор"
            });

            this.ListRole.Add(new Role
            {
                ID = 2,
                NameRole = "Бухгалтер"
            });

            this.ListRole.Add(new Role
            {
                ID = 3,
                NameRole = "Менеджер"
            });

            this.ListRole.Add(new Role
            {
                ID = 4,
                NameRole = "Секретарь"
            });
        }

        public int MaxID()
        {
            int max = 0;
            foreach (var r in this.ListRole)
            {
                if (max < r.ID)
                {
                    max = r.ID;
                }
            }
            return max;
        }
    }
}
