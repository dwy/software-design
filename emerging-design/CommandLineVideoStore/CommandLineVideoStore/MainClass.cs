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

        public static void Main()
        {
            new MainClass(Console.In, Console.Out).Run();
            Console.ReadLine();
        }

        public MainClass(TextReader @in, TextWriter @out)
        {
            _out = @out;
            _in = @in;
        }

        public void Run()
        {
            List<Movie> movies = new MoviesRepository(@"movies.cvs").LoadAll();
            PrintMovies(movies);

            _out.Write("Enter customer name: ");
            string customerName = _in.ReadLine();

            _out.WriteLine("Choose movie by number followed by rental days, just ENTER for bill:");

            decimal totalAmount = 0;
            int frequentRenterPoints = 0;
            string result = "Rental Record for " + customerName + "\n";
            var rentals = new List<Rental>();
            while (true)
            {
                string input = _in.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    break;
                }
                string[] rentalStrings = input.Split(' ');
                var index = int.Parse(rentalStrings[0]);
                var rentedMovie = movies[index];
                int daysRented = int.Parse(rentalStrings[1]);
                var rental = new Rental(rentedMovie, daysRented);
                rentals.Add(rental);

                decimal thisAmount = 0;

                //determine amounts for rental
                switch (rentedMovie.Category)
                {
                    case "REGULAR":
                        thisAmount += 2;
                        if (rental.DaysRented> 2)
                            thisAmount += (rental.DaysRented - 2) * 1.5m;
                        break;
                    case "NEW_RELEASE":
                        thisAmount += rental.DaysRented * 3;
                        break;
                    case "CHILDRENS":
                        thisAmount += 1.5m;
                        if (rental.DaysRented > 3)
                            thisAmount += (rental.DaysRented - 3) * 1.5m;
                        break;
                }

                // add frequent renter points
                frequentRenterPoints++;
                // add bonus for a two day new release rental
                if (rentedMovie.Category.Equals("NEW_RELEASE") && rental.DaysRented > 1)
                {
                    frequentRenterPoints++;
                }

                // show figures for this rental
                result += "\t" + rentedMovie.Name + "\t" + thisAmount.ToString("0.0", CultureInfo.InvariantCulture) + "\n";
                totalAmount += thisAmount;
            }

            // add footer lines
            result += "You owed " + totalAmount.ToString("0.0", CultureInfo.InvariantCulture) + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points\n";

            _out.Write(result);
        }

        private void PrintMovies(List<Movie> movies)
        {
            foreach (var movie in movies)
            {
                _out.WriteLine(movie.Number + ": " + movie.Name);
            }
        }
    }
}