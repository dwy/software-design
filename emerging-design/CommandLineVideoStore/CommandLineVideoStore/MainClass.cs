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
            PrintMovies(_out, _movieRepository);
            string customerName = ReadCustomerName(_out);
            List<Rental> rentals = ReadRentals(_in, _out, _rentalFactory);
            var customer = new Customer(customerName, rentals);
            PrintRentals(customer, _out);
            PrintFooter(customer, _out);
        }

        public void PrintFooter(Customer customer, TextWriter textWriter)
        {   
            int frequentRenterPoints = customer.FrequentRenterPoints;
            decimal totalAmount = customer.TotalAmount;

            // add footer lines
            textWriter.Write("You owed {0}\n", totalAmount.ToString("0.0", CultureInfo.InvariantCulture));
            textWriter.WriteLine("You earned {0} frequent renter points", frequentRenterPoints);
        }

        public void PrintRentals(Customer customer, TextWriter textWriter)
        {
            textWriter.WriteLine("Rental Record for {0}", customer.Name);
            foreach (var rental in customer.Rentals)
            {
                decimal thisAmount = rental.CalculateAmount();
                textWriter.WriteLine("\t{0}\t{1}", rental.Movie.Title, thisAmount.ToString("0.0", CultureInfo.InvariantCulture));
            }
        }

        public List<Rental> ReadRentals(TextReader textReader, TextWriter textWriter, RentalFactory rentalFactory)
        {
            textWriter.WriteLine("Choose movie by number followed by rental days, just ENTER for bill:");
            var rentals = new List<Rental>();
            while (true)
            {
                string input = textReader.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    break;
                }
                Rental rental = rentalFactory.CreateRental(input);
                rentals.Add(rental);
            }
            return rentals;
        }

        public string ReadCustomerName(TextWriter textWriter)
        {
            textWriter.Write("Enter customer name: ");
            string customerName = _in.ReadLine();
            return customerName;
        }

        public void PrintMovies(TextWriter textWriter, MovieRepository movieRepository)
        {
            List<Movie> movies = movieRepository.GetMovies();
            foreach (var movie in movies)
            {
                textWriter.WriteLine("{0}: {1}", movie.Number, movie.Title);
            }
        }
    }
}