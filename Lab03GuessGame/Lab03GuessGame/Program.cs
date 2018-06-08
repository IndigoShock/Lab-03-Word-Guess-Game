using System;
using System.IO;
using System.Text;

namespace Lab03GuessGame
{
    class Program
    {
        static string path = "../../FileOfWords.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Word guessing game!\n" +
            "Choose the following options:\n" +
           "1. Play game!\n" +
           "2. Add a word!" +
           "3. See which words are available to guess.\n" +
           "4. Update a word. Maybe you misspelled it.\n" +
           "5. Delete a word.\n" +
           "6. Exit game.\n");
            MainMenu();
        }

        static void MainMenu()
        {
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
                throw (new FormatException(e.Message));
            }
        }

        /* 
         
         * TODO: Play Game. 
         * Read through the file with words in it and randomly choose one of the words. 
         * Iterate through the chosen word with each letter as a string. 
         * With each string, replace with a hyphen (" - "). 
         * Have user input guess with one letter. 
         * Check if the user inputted string is one character.
         * Iterate through whole word and fill in for each letter.
         * And if the character has been guessed already. 
         * After each guess, display what they have guessed so far.
         * Once all letters from the file have been filled in out for that word, they win. 
         * Return the full word. And return message stating they win.
         * Return to MainMenu. 
         
         */

            /// <summary>
            /// 
            /// </summary>
        static void PlayGame()
        {
            ReadWords();
            //TODO: Add randomizer to which word can be chosen
            //Random.
        }

        //TODO: Create word
        /// <summary>
        /// 
        /// </summary>
        static void CreateFile()
        {
            if (!File.Exists((path)))

            {

                using (StreamWriter sw = new StreamWriter(path))

                {
                    try
                    {
                    string userInput = Console.ReadLine(); 
                    sw.Write(userInput);
                    }
                    catch (Exception)
                    {
                    //if no text is typed or null, return message       saying they need to type something in.

                        
                    }

                }

            }
        }

        //TODO: Read aka Display available words.
        /// <summary>
        /// 
        /// </summary>
        static void ReadWords()
        {
            try

            {

                string[] myText = File.ReadAllLines(path);



                foreach (string value in myText)

                {

                    Console.WriteLine(value);

                }

            }

            catch (Exception e)

            {
                Console.WriteLine("Something went wrong");
            }
        }

        //TODO: Update word
        /// <summary>
        /// 
        /// </summary>
        static void UpdateWords()
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
        static void DeleteWords()
        {
            File.Delete(path);
        }

        //TODO: Exit game
        /// <summary>
        /// 
        /// </summary>
        static void ExitGame()
        {
            Console.ReadLine();
        }

        static void MenuErrorMessage()
        {
            Console.WriteLine("You gotta put in 1 through 6");
            MainMenu();
        }
    }
}
