using System.Collections.Generic;

namespace CommandLineVideoStore
{
    public class Customer
    {
        private readonly string _customerName;
        private readonly List<Rental> _rentals;

        public Customer(string customerName, List<Rental> rentals)
        {
            _customerName = customerName;
            _rentals = rentals;
        }

        public string Name
        {
            get { return _customerName; }
        }

        public List<Rental> Rentals
        {
            get { return _rentals; }
        }
    }
}