using System;
using System.Collections.Generic;
using System.IO;

namespace CommandLineVideoStore
{
    public class MainClass
    {
        private readonly MovieRepository _movieRepository;
        private readonly UserInteraction _userInteraction;

        public static void Main()
        {
            new MainClass(Console.In, Console.Out).Run();
            Console.ReadLine();
        }

        public MainClass(TextReader @in, TextWriter @out)
        {
            _movieRepository = new MovieRepository(@"movies.cvs");
            var rentalFactory = new RentalFactory(_movieRepository);
            _userInteraction = new UserInteraction(@in, @out, rentalFactory);
        }

        public void Run()
        {
            _userInteraction.PrintMovies(_movieRepository.GetMovies());

            string customerName = _userInteraction.ReadCustomerName();
            List<Rental> rentals = _userInteraction.ReadRentals();
            var customer = new Customer(customerName, rentals);

            _userInteraction.PrintRentalRecordFor(customer);
            _userInteraction.PrintFooterFor(customer);
        }
    }
}