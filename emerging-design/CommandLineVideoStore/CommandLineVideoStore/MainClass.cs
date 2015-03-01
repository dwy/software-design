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

            string result = string.Format("Rental Record for {0}\n", customerName);
            foreach (var rental in rentals)
            {
                decimal thisAmount = rental.CalculateAmount();
                string rentalInfo = string.Format("\t{0}\t{1}\n", rental.Movie.Title, thisAmount.ToString("0.0", CultureInfo.InvariantCulture));
                result += rentalInfo;
            }

            int frequentRenterPoints = CalculateFrequentRenterPoints(rentals);
            decimal totalAmount = CalculateTotalAmount(rentals);

            // add footer lines
            result += string.Format("You owed {0}\n", totalAmount.ToString("0.0", CultureInfo.InvariantCulture));
            result += string.Format("You earned {0} frequent renter points\n", frequentRenterPoints);

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
                Rental rental1 = _rentalFactory.CreateRental(input);
                rentals.Add(rental1);
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

        private static int CalculateFrequentRenterPoints(List<Rental> rentals)
        {
            int frequentRenterPoints = 0;
            foreach (var rental in rentals)
            {
                frequentRenterPoints++;
                if (rental.Movie.Type.Equals("NEW_RELEASE") && rental.DaysRented > 1)
                {
                    frequentRenterPoints++;
                }
            }
            return frequentRenterPoints;
        }

        private static decimal CalculateTotalAmount(List<Rental> rentals)
        {
            return rentals.Sum(rental => rental.CalculateAmount());
        }
    }
}