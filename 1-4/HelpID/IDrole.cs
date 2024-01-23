using _1_4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_4.HelpID
{
        public class Findrole
    {
        int ID;
        public Findrole(int ID)
        {
            this.ID = ID;
        }
        public bool RolePredicate(Role role)
        {
           return role.ID == ID;
        }
    }

    public class FindPersonal
    {
        int ID;
        public FindPersonal(int ID)
        {
            this.ID = ID;
        }
        public bool PersonalPredicate(Personal Personal)
        {
            return Personal.ID == ID;
        }
    }
}
