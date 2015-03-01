using System.Collections.Generic;
using System.Linq;

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

        public int FrequentRenterPoints
        {
            get
            {
                int frequentRenterPoints = 0;
                foreach (var rental in Rentals)
                {
                    frequentRenterPoints++;
                    if (rental.Movie.Type.Equals("NEW_RELEASE") && rental.DaysRented > 1)
                    {
                        frequentRenterPoints++;
                    }
                }
                return frequentRenterPoints;
            }
        }

        public decimal TotalAmount
        {
            get { return Rentals.Sum(rental => rental.CalculateAmount()); }
        }
    }
}