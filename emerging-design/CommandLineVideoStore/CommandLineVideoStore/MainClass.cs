using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CommandLineVideoStore
{
    public class MainClass
    {
        private readonly TextReader _in;
        private readonly TextWriter _out;
        private readonly MovieRepository _movieRepository;
        private readonly RentalFactory _rentalFactory;

        public static void Main()
        {
            new MainClass(Console.In, Console.Out).Run();
            Console.ReadLine();
        }

        public MainClass(TextReader @in, TextWriter @out)
        {
            _out = @out;
            _in = @in;
            _movieRepository = new MovieRepository();
            _rentalFactory = new RentalFactory(_movieRepository);
        }

        public void Run()
        {
            PrintMovies();
            string customerName = ReadCustomerName();
            List<Rental> rentals = ReadRentals();
            var customer = new Customer(customerName, rentals);
            PrintRentals(customer);
            PrintFooter(customer);
        }

        private void PrintFooter(Customer customer)
        {   
            int frequentRenterPoints = customer.FrequentRenterPoints;
            decimal totalAmount = customer.TotalAmount;

            // add footer lines
            _out.Write("You owed {0}\n", totalAmount.ToString("0.0", CultureInfo.InvariantCulture));
            _out.WriteLine("You earned {0} frequent renter points", frequentRenterPoints);
        }

        private void PrintRentals(Customer customer)
        {
            _out.WriteLine("Rental Record for {0}", customer.Name);
            foreach (var rental in customer.Rentals)
            {
                decimal thisAmount = rental.CalculateAmount();
                _out.WriteLine("\t{0}\t{1}", rental.Movie.Title, thisAmount.ToString("0.0", CultureInfo.InvariantCulture));
            }
        }

        private List<Rental> ReadRentals()
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

        private string ReadCustomerName()
        {
            _out.Write("Enter customer name: ");
            string customerName = _in.ReadLine();
            return customerName;
        }

        private void PrintMovies()
        {
            List<Movie> movies = _movieRepository.GetMovies();
            foreach (var movie in movies)
            {
                _out.WriteLine("{0}: {1}", movie.Number, movie.Title);
            }
        }
    }
}