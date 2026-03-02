using System.Collections.Generic;

namespace MovieManagementSystem.Patterns.Observer
{
    public class MovieNotifier : ISubject
    {
        private readonly List<IObserver> _observers = new List<IObserver>();

        public void Register(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unregister(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(string message)
        {
            foreach (var observer in _observers)
            {
                observer.Update(message);
            }
        }
    }
}