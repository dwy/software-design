using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace CommandLineVideoStore
{
    public class UserInteraction
    {
        private readonly TextWriter _out;
        private readonly TextReader _in;
        private readonly RentalFactory _rentalFactory;

        public UserInteraction(TextReader @in, TextWriter @out, RentalFactory rentalFactory)
        {
            _out = @out;
            _in = @in;
            _rentalFactory = rentalFactory;
        }

        public void PrintMovies(List<Movie> movies)
        {
            foreach (var movie in movies)
            {
                _out.WriteLine("{0}: {1}", movie.Number, movie.Title);
            }
        }

        public string ReadCustomerName()
        {
            _out.Write("Enter customer name: ");
            return _in.ReadLine();
        }

        public List<Rental> ReadRentals()
        {
            _out.WriteLine("Choose movie by number followed by rental days, just ENTER for bill:");
            var rentals = new List<Rental>();
            while (true)
            {
                string input = _in.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    break;
                }
                Rental rental = _rentalFactory.CreateRental(input);
                rentals.Add(rental);
            }
            return rentals;
        }

        public void PrintRentals(Customer customer)
        {
            _out.WriteLine("Rental Record for {0}", customer.Name);
            foreach (var rental in customer.Rentals)
            {
                decimal thisAmount = rental.CalculateAmount();
                _out.WriteLine("\t{0}\t{1}", rental.Movie.Title, thisAmount.ToString("0.0", CultureInfo.InvariantCulture));
            }
        }

        public void PrintFooter(Customer customer)
        {   
            int frequentRenterPoints = customer.FrequentRenterPoints;
            decimal totalAmount = customer.TotalAmount;

            // add footer lines
            _out.Write("You owed {0}\n", totalAmount.ToString("0.0", CultureInfo.InvariantCulture));
            _out.WriteLine("You earned {0} frequent renter points", frequentRenterPoints);
        }
    }
}