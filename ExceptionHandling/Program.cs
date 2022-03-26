using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables
            string filePath;
            bool fileExists = false;
            bool formatValid = false;

            //Input users file path
            Console.WriteLine("Please enter a file path: ");
            filePath = @"" + Console.ReadLine();

            //Call Methods
            IsFormatValid(out formatValid, filePath); //pass formatValid as out paramters to return true value if it's valid

            if (formatValid) //Attempt to open file & count words only if file path format is valid
            {
                DoesFileExist(out fileExists, filePath); //pass fileExists as out parameter to return true value if it exists using the filePath
                
                if (fileExists) //Count the words in the file only if it exists
                {
                    CountWords(filePath);
                }
            }

        }

        //METHOD 1: Is file path format valid
        static void IsFormatValid(out bool fValid, string fPath)
        {
            //Variables
            var pathChecker = new Regex(@"^([A-Z]:/)+(\w+\s*)+(/*\w*\s*)+(\.txt)$");
            fValid = false;

            if (pathChecker.IsMatch(fPath)) //if file path matches regex pattern assign fValid to true
            {
                fValid = true;
                Console.WriteLine("File path is valid");
            }
            else
            {
                Console.WriteLine("Not a valid path!");
            }
        }

        //METHOD 2: Does file exist
        static void DoesFileExist(out bool fExists, string fPath)
        {
            //Variables
            fExists = false;

            //Exception handle opening the file
            try //if attempt works assign fExists to true
            {
                StreamReader file = new StreamReader(fPath);
                fExists = true;
                Console.WriteLine("Opening the file...\n");
            }
            catch
            {
                Console.WriteLine("Unfortunately, that file does not exist");
            }
        }

        //METHOD 3: Count the words
        static void CountWords(string fPath)
        {
            //Variables
            StreamReader file = new StreamReader(fPath);
            string currentLine = file.ReadLine();
            int wordCount = 0;

            while(currentLine != null) //iterate through each line in the file while there are lines to read
            {
                Console.WriteLine(currentLine);

                string[] words = currentLine.Split(' '); //split the current line into an array of words by removing any spaces
                wordCount += words.Length; //accumulate a running total by adding the number of elements in the array to wordCount
                
                currentLine = file.ReadLine(); //assign to the next line in the file at the end of each iteration
            }

            Console.WriteLine("\nThere are " + wordCount + " words in the file");
        }
    }
}
