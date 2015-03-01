using System;

namespace CommandLineVideoStore
{
    public class Rental
    {
        private readonly int _movieNumber;
        private readonly int _daysRented;
        private Movie _movie;

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

        public Movie Movie
        {
            get { return _movie; }
            set { _movie = value; }
        }

        public decimal CalculateAmount(Movie movie)
        {
            decimal thisAmount = 0;
            switch (movie.Type)
            {
                case "REGULAR":
                    thisAmount += 2;
                    if (DaysRented > 2)
                        thisAmount += (DaysRented - 2)*1.5m;
                    break;
                case "NEW_RELEASE":
                    thisAmount += DaysRented*3;
                    break;
                case "CHILDRENS":
                    thisAmount += 1.5m;
                    if (DaysRented > 3)
                        thisAmount += (DaysRented - 3)*1.5m;
                    break;
            }
            return thisAmount;
        }
    }
}