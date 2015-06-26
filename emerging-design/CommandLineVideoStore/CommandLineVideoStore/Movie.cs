namespace CommandLineVideoStore
{
    using System;
    using System.Globalization;

    public class Movie
    {
        private const char Separator = ';';

        private readonly string _title;
        private readonly string _type;
        private readonly int _number;

        public static Movie ParseFrom(string line, int number)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                throw new ArgumentNullException();
            }
            if (!line.Contains(Separator.ToString(CultureInfo.InvariantCulture)))
            {
                throw new ArgumentException("line should contain ';'");
            }
            string[] movie = line.Split(';');
            string title = movie[0];
            string type = movie[1];
            return new Movie(title, type, number);
        }

        internal Movie(string title, string type, int number)
        {
            _title = title;
            _type = type;
            _number = number;
        }

        public string Title
        {
            get { return _title; }
        }

        public string Type
        {
            get { return _type; }
        }

        public int Number
        {
            get { return _number; }
        }
    }
}