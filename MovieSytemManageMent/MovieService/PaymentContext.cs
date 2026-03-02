using MovieSytemManageMent.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieManagementSystem.Services
{
    public class PaymentContext
    {
        private IPaymentStrategy _strategy;

        public void SetStrategy(IPaymentStrategy strategy)
        {
            _strategy = strategy;
        }

        public string ExecutePayment(double amount)
        {
            if (_strategy == null)
                return "Payment method not selected.";

            return _strategy.Pay(amount);
        }
    }
}