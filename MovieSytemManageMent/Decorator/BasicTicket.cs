using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementSystem.Patterns.Decorator
{
    public class BasicTicket : TicketComponent
    {
        private double _price;
        private string _movieTitle;

        public BasicTicket(string movieTitle, double price)
        {
            _movieTitle = movieTitle;
            _price = price;
        }

        public override double GetPrice()
        {
            return _price;
        }

        public override string GetDescription()
        {
            return $"Ticket for {_movieTitle}";
        }
    }
}