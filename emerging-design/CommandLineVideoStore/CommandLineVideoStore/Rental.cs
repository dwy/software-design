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

        public static decimal CalculateRentalAmount(Movie movie, Rental rental)
        {
            decimal thisAmount = 0;
            switch (movie.Type)
            {
                case "REGULAR":
                    thisAmount += 2;
                    if (rental.DaysRented > 2)
                        thisAmount += (rental.DaysRented - 2)*1.5m;
                    break;
                case "NEW_RELEASE":
                    thisAmount += rental.DaysRented*3;
                    break;
                case "CHILDRENS":
                    thisAmount += 1.5m;
                    if (rental.DaysRented > 3)
                        thisAmount += (rental.DaysRented - 3)*1.5m;
                    break;
            }
            return thisAmount;
        }
    }
}