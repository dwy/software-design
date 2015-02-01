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
            // read movies from file
            var movies = new List<Movie>();
            using (FileStream fs = File.Open(@"movies.cvs", FileMode.Open, FileAccess.Read))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader reader = new StreamReader(bs))
            {
                int movieNumber = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] movieStrings = line.Split(';');
                    var movie = new Movie(movieStrings[0], movieStrings[1], movieNumber);
                    movies.Add(movie);
                    _out.WriteLine(movie.Number + ": " + movie.Name);
                    movieNumber++;
                }
            }

            _out.Write("Enter customer name: ");
            string customerName = _in.ReadLine();

            _out.WriteLine("Choose movie by number followed by rental days, just ENTER for bill:");

            decimal totalAmount = 0;
            int frequentRenterPoints = 0;
            string result = "Rental Record for " + customerName + "\n";
            while (true)
            {
                string input = _in.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    break;
                }
                string[] rental = input.Split(' ');
                var index = int.Parse(rental[0]);
                var rentedMovie = movies[index];
                int daysRented = int.Parse(rental[1]);
                var rental2 = new Rental(rentedMovie, daysRented);
                decimal thisAmount = 0;

                //determine amounts for rental
                switch (rentedMovie.Category)
                {
                    case "REGULAR":
                        thisAmount += 2;
                        if (daysRented > 2)
                            thisAmount += (daysRented - 2)*1.5m;
                        break;
                    case "NEW_RELEASE":
                        thisAmount += daysRented*3;
                        break;
                    case "CHILDRENS":
                        thisAmount += 1.5m;
                        if (daysRented > 3)
                            thisAmount += (daysRented - 3)*1.5m;
                        break;
                }

                // add frequent renter points
                frequentRenterPoints++;
                // add bonus for a two day new release rental
                if (rentedMovie.Category.Equals("NEW_RELEASE") && daysRented > 1)
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
    }
}