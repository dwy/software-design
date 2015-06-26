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
            new MainClass(Console.In, Console.Out, new MovieRepository(@"movies.cvs")).Run();
            Console.ReadLine();
        }

        public MainClass(TextReader @in, TextWriter @out, MovieRepository movieRepository)
        {
            this._movieRepository = movieRepository;
            var rentalFactory = new RentalFactory(this._movieRepository);
            this._userInteraction = new UserInteraction(@in, @out, rentalFactory);
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