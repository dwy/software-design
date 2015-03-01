using System.Collections.Generic;
using System.IO;

namespace CommandLineVideoStore
{
    public class MovieRepository
    {
        private readonly List<Movie> _movies;

        public MovieRepository()
        {
            _movies = LoadMovies();
        }

        public List<Movie> GetMovies()
        {
            return _movies;
        }

        public Movie GetMovieBy(int number)
        {
            return _movies[number];
        }

        private List<Movie> LoadMovies()
        {
            var movies = new List<Movie>();
            using (FileStream fs = File.Open(@"movies.cvs", FileMode.Open, FileAccess.Read))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader reader = new StreamReader(bs))
            {
                int movieNumber = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    var movie = Movie.ParseFrom(line, movieNumber);
                    movies.Add(movie);
                    movieNumber++;
                }
            }
            return movies;
        }
    }
}