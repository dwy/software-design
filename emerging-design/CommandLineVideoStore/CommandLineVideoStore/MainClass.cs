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

            _out.WriteLine("Choose movie by number followed by rental days, just ENTER for bill:");

            string result = "Rental Record for " + customerName + "\n";
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

                decimal thisAmount = rental.CalculateAmount();

                // show figures for this rental
                result += "\t" + rental.Movie.Name + "\t" + thisAmount.ToString("0.0", CultureInfo.InvariantCulture) + "\n";
            }

            int frequentRenterPoints = CalculateFrequentRenterPoints(rentals);
            decimal totalAmount = CalculateTotalAmount(rentals);

            // add footer lines
            result += "You owed " + totalAmount.ToString("0.0", CultureInfo.InvariantCulture) + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points\n";

            _out.Write(result);
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