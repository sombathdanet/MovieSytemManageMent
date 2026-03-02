using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSytemManageMent.Strategy
{
    public class CardPayment : IPaymentStrategy
    {
        public string Pay(double amount)
        {
            return $"Paid {amount}$ using Credit Card.";
        }
    }
}
