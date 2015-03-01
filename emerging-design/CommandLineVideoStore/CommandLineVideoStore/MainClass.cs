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
        private readonly UserInteraction _userInteraction;

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
            _userInteraction = new UserInteraction(@in, @out, _rentalFactory);
        }

        public void Run()
        {
            _userInteraction.PrintMovies(_movieRepository.GetMovies());
            string customerName = _userInteraction.ReadCustomerName();
            List<Rental> rentals = _userInteraction.ReadRentals();
            var customer = new Customer(customerName, rentals);
            _userInteraction.PrintRentals(customer);
            _userInteraction.PrintFooter(customer);
        }
    }
}