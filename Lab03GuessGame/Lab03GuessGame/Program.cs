using System;
using System.IO;
using System.Text;

namespace Lab03GuessGame
{
    public class Program
    {
        public static string path = "../../../MyFile.txt";

        public static void Main(string[] args)
        {
            string[] starterWords = new string[] { "Out", "Broskie", "Cat", "Salmon" };

            CreateFile(starterWords);

            MainMenu();
        }

        public static void MainMenu()
        {
            Console.WriteLine(" \n" +
                "Welcome to Word guessing game!\n" +
            "Choose the following options:\n" +
           "1. Play game!\n" +
           "2. Add a word!\n" +
           "3. See which words are available to guess.\n" +
           "4. Update a word. Maybe you misspelled it.\n" +
           "5. Delete a word.\n" +
           "6. Exit game.\n");

            string userValue = Console.ReadLine();

            try
            {
                if (userValue == "1") PlayGame();
                if (userValue == "2") CreateFileWithNewWord();
                if (userValue == "3") ReadWords();
                if (userValue == "4") UpdateWords();
                if (userValue == "5") DeleteWords();
                if (userValue == "6") ExitGame();
            }
            catch (Exception e)
            {
                MenuErrorMessage();
                throw (new Exception(e.Message));
            }
        }

        /* 
         
         * TODO: Play Game. 
         * Read through the file with words in it and randomly choose one of the words. 
         * Add each in as an array.
         * Iterate through the chosen word with each letter as a string. 
         * With each string, replace with a hyphen (" - "). 
         * Have user input guess with one letter. 
         * Check if the user inputted string is one character.
         * Iterate through whole word and fill in for each letter guessed with the user input.
         * And if the character has been guessed already (bool). 
         * After each guess, display what they have guessed so far.
         * Once all letters from the file have been filled out for that word, they win. 
         * Return the full word. And return message stating they win.
         * Return to MainMenu. 
         
         */

        /// <summary>
        /// 
        /// </summary>
        public static void PlayGame()
        {
            //ReadWords();
            Random randm = new Random();
            string[] myWords = ReadWordsFromFile();
            int ran = randm.Next(0, myWords.Length);
            string word = myWords[ran];
            Console.WriteLine($"random word is {word}");
            //TODO: Add randomizer to which word can be chosen
            //Random.
            //Look up: ToCharArray, foreach (char c in TestString)
            //
            MainMenu();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="words"></param>
        public static void CreateFile(string[] words)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                try
                {
                    foreach (string s in words)
                    {
                        sw.WriteLine(s);
                    }
                }
                finally
                {
                    Console.Clear();
                }

            }

        }

        //TODO: Create new word
        /// <summary>
        /// 
        /// </summary>
        public static void CreateFileWithNewWord()
        {
            try
            {
                Console.WriteLine("Type in the word you would like to add: ");
                string userInput = Console.ReadLine();
                CreateFileFromString(userInput);
                if (userInput.Length < 1)
                {
                    Console.WriteLine("You didn't write anything. Try again from Main Menu");
                    MainMenu();
                }
                else
                {

                    Console.WriteLine($"You added {userInput}!");
                    MainMenu();
                }
            }
            catch (Exception)
            {
                //if no text is typed or null, return message saying they need to type something in.
                Console.WriteLine("Something went wrong");

            }

        }

        /// <summary>
        /// Unit testing for New Word
        /// </summary>
        /// <param name="k"></param>
        public static string CreateFileFromString(string k)
        {
            using (StreamWriter sw = File.AppendText(path))

            {
                sw.WriteLine(k);
                return k;
            };

        }

        //TODO: Read aka Display available words.
        /// <summary>
        /// 
        /// </summary>
        public static void ReadWords()
        {
            try

            {
                var words = ReadWordsFromFile();
                foreach (string value in words)
                {
                    Console.WriteLine(value);
                }
                MainMenu();

            }

            catch (Exception)

            {
                Console.WriteLine("Something went wrong");
            }
        }

        /// <summary>
        /// Unit Testing Read Words
        /// </summary>
        public static string[] ReadWordsFromFile()
        {
            string[] lines = File.ReadAllLines(path);
            return lines;
        }

        //TODO: Update word
        /// <summary>
        /// This updates the word
        /// </summary>
        public static void UpdateWords()
        {
            using (StreamWriter sw = File.AppendText(path))

            {
                string userInput = Console.ReadLine();
                sw.WriteLine(userInput);
            }
        }

        /// <summary>
        /// This method deletes the entire file, states it has been deleted and brings back to the main menu.
        /// </summary>
        public static void DeleteWords()
        {
            DeleteFile();
            Console.WriteLine("File has been deleted.");
            MainMenu();
        }

        /// <summary>
        /// Unit testing functionality for deleting file
        /// </summary>
        public static void DeleteFile()
        {
            File.Delete(path);
        }

        //TODO: Exit game
        /// <summary>
        /// This method exits the game
        /// </summary>
        public static void ExitGame()
        {
            Console.WriteLine("Thanks for playing!");
            Environment.Exit(0);
        }

        public static void MenuErrorMessage()
        {
            Console.WriteLine("You gotta put in 1 through 6");
            MainMenu();
        }
    }
}

