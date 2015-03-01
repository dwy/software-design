using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace CommandLineVideoStore
{
    public class UserInteraction
    {
        private TextWriter _textWriter;
        private TextReader _textReader;
        private RentalFactory _rentalFactory;

        public UserInteraction()
        {
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
            _rentalFactory = rentalFactory;
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

        public string ReadCustomerName(TextReader textReader, TextWriter textWriter)
        {
            _textReader = textReader;
            textWriter.Write("Enter customer name: ");
            string customerName = textReader.ReadLine();
            return customerName;
        }

        public void PrintMovies(TextWriter textWriter, MovieRepository movieRepository)
        {
            _textWriter = textWriter;
            List<Movie> movies = movieRepository.GetMovies();
            foreach (var movie in movies)
            {
                textWriter.WriteLine("{0}: {1}", movie.Number, movie.Title);
            }
        }
    }
}