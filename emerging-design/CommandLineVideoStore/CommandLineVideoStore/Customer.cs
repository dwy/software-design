using System.Collections.Generic;

namespace CommandLineVideoStore
{
    public class Customer
    {
        private readonly string _name;
        private readonly List<Rental> _rentals;

        public Customer(string name, List<Rental> rentals)
        {
            _name = name;
            _rentals = rentals;
        }

        public string Name
        {
            get { return _name; }
        }

        public List<Rental> Rentals
        {
            get { return _rentals; }
        }
    }
}