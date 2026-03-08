using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSytemManageMent.Model
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        protected User(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public abstract string GetRole();
    }
}
