using System;

namespace CommandLineVideoStore
{
    public class RentalFactory
    {
        public static Rental ParseFrom(String input)
        {
            string[] rentalTokens = input.Split(' ');
            return new Rental(int.Parse(rentalTokens[0]), int.Parse(rentalTokens[1]));
        }
    }
}