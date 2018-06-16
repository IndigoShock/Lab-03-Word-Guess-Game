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


        [Fact]
        public void CanDeleteFile()
        {
            Program.DeleteFile();
            Assert.False(File.Exists(Program.path));
        }

        [Theory]
        [InlineData("john")]
        [InlineData("bill")]

        public void CanUpdateFile(string value)
        {
            Program.CreateFileFromString(value);
            Assert.Contains(value, Program.ReadWordsFromFile());
        }

        //[Fact]
        //public void LetterCanBeGuessed()
        //{

        //}
    }
}
