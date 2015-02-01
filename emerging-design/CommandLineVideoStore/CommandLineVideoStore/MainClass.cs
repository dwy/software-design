using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace CommandLineVideoStore
{
    public class MainClass
    {
        private readonly TextReader _in;
        private readonly TextWriter _out;
        private readonly MoviesRepository _moviesRepository;
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
            _moviesRepository = new MoviesRepository(@"movies.cvs");
            _rentalFactory = new RentalFactory(_moviesRepository);
        }

        public void Run()
        {
            PrintMovies();

            string customerName = ReadCustomerName();
            List<Rental> rentals = ReadRentals();
            var customer = new Customer(customerName, rentals);

            PrintRentalRecord(customer);
            PrintFooter(customer);
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
                var rental = _rentalFactory.CreateRentalFrom(input);
                rentals.Add(rental);
            }
            return rentals;
        }

        private void PrintRentalRecord(Customer customer)
        {
            _out.WriteLine("Rental Record for " + customer.Name);
            foreach (var rental in customer.Rentals)
            {
                // show figures for this rental
                _out.WriteLine("\t" + rental.Movie.Name + "\t" + rental.CalculateAmount().ToString("0.0", CultureInfo.InvariantCulture));
            }
        }

        private void PrintFooter(Customer customer)
        {
            _out.WriteLine("You owed " + customer.TotalAmount().ToString("0.0", CultureInfo.InvariantCulture));
            _out.WriteLine("You earned " + CalculateFrequentRenterPoints(customer) + " frequent renter points");
        }

        private static int CalculateFrequentRenterPoints(Customer customer)
        {
            int frequentRenterPoints = 0;
            foreach (var rental in customer.Rentals)
            {
                // add frequent renter points
                frequentRenterPoints++;
                // add bonus for a two day new release rental
                if (rental.Movie.Category.Equals("NEW_RELEASE") && rental.DaysRented > 1)
                {
                    frequentRenterPoints++;
                }
            }
            return frequentRenterPoints;
        }

        private string ReadCustomerName()
        {
            _out.Write("Enter customer name: ");
            return _in.ReadLine();
        }

        private void PrintMovies()
        {
            var movies = _moviesRepository.GetAll();
            foreach (var movie in movies)
            {
                _out.WriteLine(movie.Number + ": " + movie.Name);
            }
        }
    }
}