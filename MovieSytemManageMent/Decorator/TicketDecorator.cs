using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementSystem.Patterns.Decorator
{
    public abstract class TicketDecorator : TicketComponent
    {
        protected TicketComponent _ticket;

        protected TicketDecorator(TicketComponent ticket)
        {
            _ticket = ticket;
        }
    }
}
