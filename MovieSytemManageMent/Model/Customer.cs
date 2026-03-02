using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSytemManageMent.Model
{
    public class Customer : User
    {
        public Customer(int id, string name) : base(id, name) { }

        public override string GetRole()
        {
            return "Customer";
        }
    }
}
