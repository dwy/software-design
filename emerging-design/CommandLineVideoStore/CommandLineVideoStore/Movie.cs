namespace CommandLineVideoStore
{
    public class Movie
    {
        private readonly string _name;
        private readonly string _category;
        private readonly int _number;

        public Movie(string name, string category, int number)
        {
            _name = name;
            _category = category;
            _number = number;
        }

        public string Name
        {
            get { return _name; }
        }

        public string Category
        {
            get { return _category; }
        }

        public int Number
        {
            get { return _number; }
        }
    }
}