using System;
using Xunit;
using Lab03GuessGame;
using System.IO;

namespace GuessGameUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void CanCreateFile()
        {
            Program.CreateFileFromString("look!");
            Assert.True(File.Exists(Program.path));
        }

        [Fact]
        public void CanReadFile()
        {
            string wordies = "Another Look!";
            Program.CreateFileFromString(wordies);
            var words = Program.ReadWordsFromFile();
            Assert.Equal(wordies, words[0]);
        }

    //[Fact]
    //public void CanUpdateFile()
    //{

    //}

    //[Fact]
    //public void CanDeleteFile()
    //{

    //}

    //[Fact]
    //public void LetterCanBeGuessed()
    //{

    //}
}
}
