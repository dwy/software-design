namespace CommandLineVideoStore
{
    public class Movie
    {
        private readonly string _title;
        private readonly string _type;
        private readonly int _number;

        public static Movie ParseFrom(string line, int movieNumber)
        {
            string[] movie = line.Split(';');
            return new Movie(movie[0], movie[1], movieNumber);
        }

        private Movie(string title, string type, int number)
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