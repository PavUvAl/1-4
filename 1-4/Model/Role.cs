using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_4.Model
{
    public class Role
    {
        public int ID { get; set; }
        public string NameRole { get; set; }
        public Role() { }
        public Role(int ID, string nameRole)
        {
            this.ID = ID;
            this.NameRole = nameRole;
        }
        public Role ShallowCopy()
        {
            return (Role)this.MemberwiseClone();
        }


    }

}
