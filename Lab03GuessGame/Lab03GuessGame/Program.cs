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
                if (userValue == "2") CreateFile();
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
            ReadWords();
            //TODO: Add randomizer to which word can be chosen
            //Random.
            MainMenu();
        }

        //TODO: Create word
        /// <summary>
        /// 
        /// </summary>
        public static void CreateFile()
        {

            using (StreamWriter sw = new StreamWriter(path))

            {
                try
                {
                    string userInput = Console.ReadLine();
                    sw.Write(userInput);
                    Console.WriteLine($"You added {userInput}!");
                    MainMenu();
                }
                catch (Exception)
                {
                    //if no text is typed or null, return message saying they need to type something in.
                    Console.WriteLine("Something went wrong");

                }

            }

        }

        //TODO: Read aka Display available words.
        /// <summary>
        /// 
        /// </summary>
        public static void ReadWords()
        {
            try

            {

                string[] myText = File.ReadAllLines(path);



                foreach (string value in myText)

                {
                    Console.WriteLine(value);
                MainMenu();
                }

            }

            catch (Exception)

            {
                Console.WriteLine("Something went wrong");
            }
        }

        //TODO: Update word
        /// <summary>
        /// 
        /// </summary>
        public static void UpdateWords()
        {
            using (StreamWriter sw = File.AppendText(path))

            {
                sw.WriteLine("Its Wed!!");
            }
        }

        //TODO: Delete word 
        /// <summary>
        /// 
        /// </summary>
        public static void DeleteWords()
        {
            File.Delete(path);
            Console.WriteLine("File has been deleted.");
            MainMenu();
        }

        //TODO: Exit game
        /// <summary>
        /// 
        /// </summary>
        public static void ExitGame()
        {
            Console.WriteLine("Thanks for playing!");
        }

        public static void MenuErrorMessage()
        {
            Console.WriteLine("You gotta put in 1 through 6");
            MainMenu();
        }
    }
}

