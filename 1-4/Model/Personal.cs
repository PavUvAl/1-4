using _1_4.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_4.Model
{
    public class Personal
    {
        public int ID { get; set; }

        public int RoleID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public static int IDPersonal { get; set; }

        public Personal() { }
        public Personal(int ID, int roleID, string firstName,
        string lastName, DateTime birthday)
        {
            this.ID = ID;
            this.RoleID = roleID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Birthday = birthday;
        }
        public Personal CopyFromPersonDPO(PersonalDPO p)
        {
            RoleViewModel vmRole = new RoleViewModel();
            int roleId = 0;
            foreach (var r in vmRole.ListRole)
            {
                if (r.NameRole == p.Role)
                {
                    roleId = r.ID;
                    break;
                }
            }
            if (roleId != 0)
            {
                this.ID = p.ID;
                this.RoleID = roleId;
                this.FirstName = p.FirstName;
                this.LastName = p.LastName;
                this.Birthday = p.Birthday;
            }
            return this;
        }
    }
   
}
