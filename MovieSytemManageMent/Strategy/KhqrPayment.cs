using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSytemManageMent.Strategy
{
    public class KhqrPayment : IPaymentStrategy
    {
        public string Pay(double amount)
        {
            return $"Paid {amount}$ using KHQR / ABA transfer.";
        }
    }
}
