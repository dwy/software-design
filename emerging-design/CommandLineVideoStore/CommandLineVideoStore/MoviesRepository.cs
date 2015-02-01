using System.Collections.Generic;
using System.IO;

namespace CommandLineVideoStore
{
    public class MoviesRepository
    {
        private readonly List<Movie> _movies;

        public MoviesRepository(string fileName)
        {
            _movies = LoadAll(fileName);
        }

        public List<Movie> GetAll()
        {
            return _movies;
        }

        public Movie GetBy(int number)
        {
            return _movies[number];
        }

        private List<Movie> LoadAll(string fileName)
        {
            var movies = new List<Movie>();
            using (FileStream fs = File.Open(fileName, FileMode.Open, FileAccess.Read))
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