using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSytemManageMent.ApplicationForm.LoginForm
{
    // Singleton Login Manager
    public class LoginManager
    {
        private static LoginManager _instance;
        private LoginManager() { } // private constructor

        public static LoginManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new LoginManager();
                return _instance;
            }
        }

        // Factory method to create users
        public IUser CreateUser(string username)
        {
            if (username == "admin")
                return new AdminUser();
            // can add more user types later
            return null;
        }

        // Login logic
        public bool Login(string username, string password)
        {
            IUser user = CreateUser(username);
            if (user == null) return false;
            return user.ValidatePassword(password);
        }
    }

    // User Interface
    public interface IUser
    {
        bool ValidatePassword(string password);
    }

    // Concrete Admin User
    public class AdminUser : IUser
    {
        private string password = "123";
        public bool ValidatePassword(string password)
        {
            return this.password == password;
        }
    }

}
