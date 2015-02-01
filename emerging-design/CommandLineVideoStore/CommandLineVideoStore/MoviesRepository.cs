using System.Collections.Generic;
using System.IO;

namespace CommandLineVideoStore
{
    public class MoviesRepository
    {
        private readonly string _fileName;
        private readonly List<Movie> _movies;

        public MoviesRepository(string fileName)
        {
            _fileName = fileName;
            _movies = LoadAll();
        }

        public List<Movie> GetAll()
        {
            return _movies;
        }

        public Movie GetBy(int number)
        {
            return _movies[number];
        }

        private List<Movie> LoadAll()
        {
            var movies = new List<Movie>();
            using (FileStream fs = File.Open(_fileName, FileMode.Open, FileAccess.Read))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader reader = new StreamReader(bs))
            {
                int movieNumber = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] movieStrings = line.Split(';');
                    var movie = new Movie(movieStrings[0], movieStrings[1], movieNumber);
                    movies.Add(movie);
                    movieNumber++;
                }
            }
            return movies;
        }
    }
}