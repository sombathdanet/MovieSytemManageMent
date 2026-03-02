//using MovieManagementSystem.Models;
//using MovieManagementSystem.Patterns.Decorator;
//using MovieManagementSystem.Patterns.Observer;
//using MovieSytemManageMent.Model;
//using MovieSytemManageMent.Strategy;
//using MovieSytemManageMent.SystemData;

//namespace MovieManagementSystem.Services
//{
//    public class BookingService
//    {
//        private readonly SystemData _data;
//        private readonly MovieNotifier _notifier;

//        public BookingService(MovieNotifier notifier)
//        {
//            _data = SystemData.Instance;
//            _notifier = notifier;
//        }

//        public Ticket CreateBooking(
//            Movie movie,
//            User customer,
//            int seat,
//            bool addPopcorn,
//            bool addDrink,
//            IPaymentStrategy paymentStrategy)
//        {
//            // 1️⃣ Base ticket
//            TicketComponent ticketComponent =
//                new BasicTicket(movie.Title, movie.Price);

//            // 2️⃣ Apply Decorators
//            if (addPopcorn)
//                ticketComponent = new PopcornAddon(ticketComponent);

//            if (addDrink)
//                ticketComponent = new DrinkAddon(ticketComponent);

//            double finalPrice = ticketComponent.GetPrice();

//            // 3️⃣ Payment using Strategy
//            PaymentContext payment = new PaymentContext();
//            payment.SetStrategy(paymentStrategy);
//            string paymentResult = payment.ExecutePayment(finalPrice);

//            // 4️⃣ Create Ticket Model
//            Ticket ticket = new Ticket(
//                _data.Tickets.Count + 1,
//                movie,
//                customer,
//                seat,
//                finalPrice);

//            _data.Tickets.Add(ticket);

//            // 5️⃣ Notify observers
//            _notifier.Notify(
//                $"Booking completed for {movie.Title} | Seat {seat} | {finalPrice}$");

//            return ticket;
//        }
//    }
//}