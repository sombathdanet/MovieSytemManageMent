
using MovieSytemManageMent.Model;

namespace MovieManagementSystem.Services
{
    public enum UserType
    {
        Admin,
        Customer
    }

    public class UserFactory
    {
        public static User CreateUser(UserType type, int id, string name)
        {
            switch (type)
            {
                case UserType.Admin:
                    return new Admin(id, name);

                case UserType.Customer:
                    return new Customer(id, name);

                default:
                    return null;
            }
        }
    }
}