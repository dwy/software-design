namespace CommandLineVideoStore
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class MovieTest
    {
        [Test]
        public void ParseFrom_NullInput_Throws()
        {
            const string nullInput = null;
            Assert.Throws<ArgumentNullException>(() => Movie.ParseFrom(nullInput, 1));
        }

        [Test]
        public void ParseFrom_EmptyInput_Throws()
        {
            const string emptyInput = " ";
            Assert.Throws<ArgumentNullException>(() => Movie.ParseFrom(emptyInput, 1));
        }

        [Test]
        public void ParseFrom_InvalidInput_Throws()
        {
            const string invalidInput = "invalîd";
            Assert.Throws<ArgumentException>(() => Movie.ParseFrom(invalidInput, 1));
        }

        [Test]
        public void ParseFrom_ValidInput_MovieIsParsed()
        {
            const string validInput = "title;REGULAR";

            Movie movie = Movie.ParseFrom(validInput, 1);

            Assert.AreEqual("title", movie.Title);
            Assert.AreEqual("REGULAR", movie.Type);
            Assert.AreEqual(1, movie.Number);
        }
    }
}