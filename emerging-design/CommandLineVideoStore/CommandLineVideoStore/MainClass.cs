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
            string result = PrintRentalRecord(customer);
            int frequentRenterPoints = CalculateFrequentRenterPoints(rentals);
            decimal totalAmount = CalculateTotalAmount(rentals);

            result += PrintFooter(totalAmount, frequentRenterPoints);

            _out.Write(result);
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

        private static string PrintRentalRecord(Customer customer)
        {
            string result = "Rental Record for " + customer.Name + "\n";
            foreach (var rental in customer.Rentals)
            {
                // show figures for this rental
                result += "\t" + rental.Movie.Name + "\t" +
                          rental.CalculateAmount().ToString("0.0", CultureInfo.InvariantCulture) + "\n";
            }
            return result;
        }

        private static string PrintFooter(decimal totalAmount, int frequentRenterPoints)
        {
            string footer = "You owed " + totalAmount.ToString("0.0", CultureInfo.InvariantCulture) + "\n";
            footer += "You earned " + frequentRenterPoints + " frequent renter points\n";
            return footer;
        }

        private static decimal CalculateTotalAmount(List<Rental> rentals)
        {
            decimal totalAmount = 0;
            foreach (var rental in rentals)
            {
                totalAmount += rental.CalculateAmount();
            }
            return totalAmount;
        }

        private static int CalculateFrequentRenterPoints(List<Rental> rentals)
        {
            int frequentRenterPoints = 0;
            foreach (var rental in rentals)
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