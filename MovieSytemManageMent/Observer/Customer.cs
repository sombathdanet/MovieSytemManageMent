using MovieManagementSystem.Patterns.Observer;
using MovieSytemManageMent.Model;
using System;
using System.Xml.Linq;

namespace MovieManagementSystem.Models
{
    public class Customer : User, IObserver
    {
        public Customer(int id, string name) : base(id, name) { }

        public override string GetRole()
        {
            return "Customer";
        }

        public void Update(string message)
        {
            Console.WriteLine($"Notification for {Name}: {message}");
        }
    }
}