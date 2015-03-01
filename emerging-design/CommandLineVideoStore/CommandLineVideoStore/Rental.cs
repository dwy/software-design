using System;

namespace CommandLineVideoStore
{
    public class Rental
    {
        private readonly int _movieNumber;
        private readonly int _daysRented;

        public Rental(int movieNumber, int daysRented)
        {
            _movieNumber = movieNumber;
            _daysRented = daysRented;
        }

        public int MovieNumber
        {
            get { return _movieNumber; }
        }

        public int DaysRented
        {
            get { return _daysRented; }
        }
    }
}