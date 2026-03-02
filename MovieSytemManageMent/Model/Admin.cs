using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSytemManageMent.Model
{
    public class Admin : User
    {
        public Admin(int id, string name) : base(id, name) { }

        public override string GetRole()
        {
            return "Admin";
        }
    }
}
