using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementSystem.Patterns.Decorator
{
    // Base Component
    public abstract class TicketComponent
    {
        public abstract double GetPrice();
        public abstract string GetDescription();
    }
}