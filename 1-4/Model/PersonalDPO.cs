using _1_4.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_4.Model
{
    public class PersonalDPO
    {

        public int ID { get; set; }

        public string Role { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public PersonalDPO() { }

        public PersonalDPO(int ID, string role, string firstName, string lastName, 
            DateTime birthday)
        {
            this.ID = ID;
            this.Role = role;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Birthday = birthday;
        }
        public PersonalDPO CopyFromPerson(Personal personal)
        {
            
            PersonalDPO perDPO = new PersonalDPO();
            RoleViewModel vmRole = new RoleViewModel();
            string role = string.Empty;
            foreach (var r in vmRole.ListRole)
            {
                if (r.ID == personal.RoleID)
                {
                    role = r.NameRole;
                    break;
                }
            }
            if (role != string.Empty)
            {
                perDPO.ID = personal.ID;
                perDPO.Role = role;
                perDPO.FirstName = personal.FirstName;
                perDPO.LastName = personal.LastName;
                perDPO.Birthday = personal.Birthday;
            }
            return perDPO;
        }
        public PersonalDPO ShallowCopy()
        {
            return (PersonalDPO)this.MemberwiseClone();
        }

    }

}
