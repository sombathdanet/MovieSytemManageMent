using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementSystem.Patterns.Decorator
{
    public class PopcornAddon : TicketDecorator
    {
        public PopcornAddon(TicketComponent ticket) : base(ticket) { }

        public override double GetPrice()
        {
            return _ticket.GetPrice() + 2.0; // Popcorn = $2
        }

        public override string GetDescription()
        {
            return _ticket.GetDescription() + ", Popcorn";
        }
    }
}