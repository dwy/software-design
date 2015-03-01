﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

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
            List<Movie> movies = _movieRepository.GetMovies();
            foreach (var movie in movies)
            {
                _out.WriteLine("{0}: {1}", movie.Number, movie.Title);
            }

            _out.Write("Enter customer name: ");
            string customerName = _in.ReadLine();

            _out.WriteLine("Choose movie by number followed by rental days, just ENTER for bill:");

            decimal totalAmount = 0;
            int frequentRenterPoints = 0;
            var rentals = new List<Rental>();
            string result = "Rental Record for " + customerName + "\n";
            while (true)
            {
                string input = _in.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    break;
                }
                Rental rental = CreateRental(_movieRepository, _rentalFactory, input);
                rentals.Add(rental);

                decimal thisAmount = rental.CalculateAmount(rental.Movie);

                // add frequent renter points
                frequentRenterPoints++;
                // add bonus for a two day new release rental
                if (rental.Movie.Type.Equals("NEW_RELEASE") && rental.DaysRented > 1)
                {
                    frequentRenterPoints++;
                }
                // show figures for this rental
                result += "\t" + rental.Movie.Title + "\t" + thisAmount.ToString("0.0", CultureInfo.InvariantCulture) + "\n";
                totalAmount += thisAmount;
            }

            // add footer lines
            result += "You owed " + totalAmount.ToString("0.0", CultureInfo.InvariantCulture) + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points\n";

            _out.Write(result);
        }

        private static Rental CreateRental(MovieRepository movieRepository, RentalFactory rentalFactory, string input)
        {
            var rental = rentalFactory.ParseFrom(input);
            rental.Movie = movieRepository.GetMovieBy(rental.MovieNumber);
            return rental;
        }
    }
}