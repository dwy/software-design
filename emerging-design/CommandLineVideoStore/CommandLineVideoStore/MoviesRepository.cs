using System.Collections.Generic;
using System.IO;

namespace CommandLineVideoStore
{
    public class MoviesRepository
    {
        public static List<Movie> LoadAll()
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