using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementSystem.Patterns.Decorator
{
    public class DrinkAddon : TicketDecorator
    {
        public DrinkAddon(TicketComponent ticket) : base(ticket) { }

        public override double GetPrice()
        {
            return _ticket.GetPrice() + 1.5; // Drink = $1.5
        }

        public override string GetDescription()
        {
            return _ticket.GetDescription() + ", Drink";
        }
    }
}