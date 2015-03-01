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
            _userInteraction = new UserInteraction();
        }

        public void Run()
        {
            _userInteraction.PrintMovies(_out, _movieRepository);
            string customerName = _userInteraction.ReadCustomerName(_in, _out);
            List<Rental> rentals = _userInteraction.ReadRentals(_in, _out, _rentalFactory);
            var customer = new Customer(customerName, rentals);
            _userInteraction.PrintRentals(customer, _out);
            _userInteraction.PrintFooter(customer, _out);
        }
    }
}