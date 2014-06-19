using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Hangman
{
    class Program
    {
        const string PATH_TO_DICTIONARY = "d:/data/dictionary.txt";
        const int MAX_ERRORS = 5;
        static void Main(string[] args)
        {
            run();
        }
        
        /// <summary>
        /// Entry point of Hangman
        /// </summary>
        static void run()
        {

            
            Console.CursorVisible = false;
            try
            {
                do
                {
                    string pickedWord = pickWord(PATH_TO_DICTIONARY);
                    Console.WriteLine(pickedWord);
                    play(pickedWord);
                    Console.WriteLine("\n[P]lay again:");                    
                } while ('P' == Console.ReadKey().KeyChar);
            }
            catch (Exception e)
            {

            }
        }

        /// <summary>
        /// Pick a random word
        /// </summary>
        /// <returns>picked string from file</returns>
        static string pickWord(string path2dictionary)
        {
            string s ="";
            int bound = 0;
            int picked;
            StreamReader sr = null;
            Random rand = new Random();
            try
            {
                sr = File.OpenText(path2dictionary);
                if (int.TryParse(sr.ReadLine(), out bound))
                {
                    picked = rand.Next(1, bound);
                    for (int i = 0; i < picked-1; ++i) sr.ReadLine();
                    s = sr.ReadLine();
                }
                else
                    throw new Exception("File format is not valid!!! (first line should have an integer that is the number of words )");
            }
            catch (Exception e)
            {
                throw e;
            }
	        finally
	        {
                if (null != sr) sr.Close();
	        }
            return s;
        }

        static char[,] initHangman(string word)
        {
            char[,] characters = new char[word.Length, 2];
            for (int i = 0; i < word.Length; ++i)
            {
                characters[i, 0] = word[i];
                characters[i, 1] = '0';
            }
            return characters;
        }

        static void play(string word)
        {
            int nbErrors = 0;
            char[,] characters = initHangman(word);
            int nbToDiscover = characters.GetLength(0); 
            do
            {

                displayHangmanPane(characters, nbErrors, nbToDiscover);

                if (!stroke(Console.ReadKey(true).KeyChar, characters,out nbToDiscover))
                {
                    nbErrors++;
                }

            } while (MAX_ERRORS > nbErrors && 0 < nbToDiscover );

            displayHangmanPane(characters, nbErrors, nbToDiscover);
        }

        static bool stroke(char c, char[,] characters, out int nbToDiscover)
        {
            bool found = false;
            nbToDiscover = 0;
            for (int i = 0; i < characters.GetLength(0); ++i)
            {
                if (c == characters[i, 0])
                {
                    characters[i, 1] = '1';
                    found = true;
                }
                else if ('0' == characters[i, 1]) nbToDiscover++; //count number of chars to discover left
            }
            return found;
        }

        static void displayHangmanPane(char[,] characters, int nbErrors, int nbToDiscovered)
        {
            bool lost = MAX_ERRORS <= nbErrors;
            
            Console.Clear();
            displayHangman(nbErrors);
            Console.WriteLine();
            
            for (int i=0; i < nbErrors; ++i)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("x");
                Console.ForegroundColor = ConsoleColor.White;
            }
            
            for (int i = nbErrors; i < MAX_ERRORS; ++i)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("o");
                Console.ForegroundColor = ConsoleColor.White;
            }
            displayWord(characters, lost);

            if (0 >= nbToDiscovered)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nYOU WIN !!!");
                Console.ForegroundColor = ConsoleColor.White;
            } else if(lost) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nMISSED !!!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        static void displayWord(char[,] characters,bool lost = false)
        {
            Console.Write("\nWord : ");
            for (int i = 0; i < characters.GetLength(0); ++i)
            {
                if ('1' == characters[i, 1])
                {
                    Console.Write(" " + characters[i,0].ToString() + " ");
                }
                else if (lost) // if lost we 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" " + characters[i, 0].ToString() + " ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write(" - ");
                }
            }

        }
        static void displayHangman(int error)
        {
            Console.WriteLine(error >= 3 ? "_____" : "");
            Console.WriteLine((error >= 2 ? "|" : "") + (error >= 4 ? "   |" : ""));
            Console.WriteLine((error >= 2 ? "|" : "") + (error >= 4 ? "   O" : ""));
            Console.WriteLine((error >= 2 ? "|" : "") + (error >= 5 ? @"  \|/" : ""));
            Console.WriteLine((error >= 2 ? "|" : "") + (error >= 5 ? @"  / \" : ""));
            Console.WriteLine((error >= 2 ? "|" : ""));
            Console.WriteLine((error >= 1 ? "-----" : ""));

        }
    }
}
