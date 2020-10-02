using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.CompilerServices;

namespace RecursiveAnagramFinder
{
    class Evaluator
    {

        char[] builderArray;
        int[] duplicateTestArray;
        bool skipThisLoop;
        string _inputWord;
        char[] inputWordArray;
        string builtString = "";
        List<string> resultList = new List<string>();
        List<string> engdicList = new List<string>();
        SortedSet<string> confirmedList = new SortedSet<string>();
        public Evaluator(string inputWord)
        {
            _inputWord = inputWord;
            Console.Clear();
            Console.WriteLine("\n\nPlease wait...");
            

            // This array tracks which character(s) are already used to avoid repeats
            duplicateTestArray = new int[inputWord.Length];
            for (int i = 0; i < duplicateTestArray.Length; i++)
            {
                duplicateTestArray[i] = -1;
            }

            // Starts the Anagram method, looping through all lengths of words. 
            // This loop starts the method outputting result strings of the same length as the input string.
            // This is used to test whether the search has been done before on this word (or its equal-length anagram). 
            // If it has, the previous results will be loaded back in, to avoid processing unnecessary anagrams.
            // If it hasn't, each loop returns strings of a shorter length.
            for (int i = 1; i < inputWord.Length; i++)
            {
                builderArray = new char[inputWord.Length - (i - 1)];
                Anagram(inputWord, 0, i);

                if (i == 1)
                {
                    
                    // Check to see if the inputWord or its equal-length anagram exists in the output of a previous search
                    foreach (string initialResult in resultList)
                    {
                        if (File.Exists($"{initialResult}.txt"))
                        {
                            // If so, load it in and display to the user.
                            SearchIsRepeated(initialResult);
                        }
                    }

                    // Load the dictionary and continue searching through progressively smaller words.
                    Console.WriteLine($"\n\nNow finding anagrams of {inputWord}. This may take a while.\n\n");
                    LoadDictionary();
                }

                foreach (var result in resultList)
                {
                    // Check the result is a valid word using binary search.
                    if (BinaryChop(result, 0, engdicList.Count - 1))
                    {
                        confirmedList.Add(result);
                    }

                    else
                    {
                        continue;
                    }
                }
            }
            OutputToFile();
            OutputToConsole();
        }
        /// <summary>
        /// Check if the string only contains letters
        /// </summary>
        /// <param name="testLetters">the string to test.</param>
        /// <returns>True or false, was it a valid string of letters</returns>
        public static bool ValidateFormat(string testLetters)
        {
            // Check user actually entered letters before instantiating object
            for (int i = 0; i < testLetters.Length; i++)
            {
                char testChar = testLetters[i];
                if (!(Char.IsLetter(testChar)))
                {
                    Console.WriteLine($"{testChar} is not valid. A to Z only.");
                    return false;
                }
            }
            return true;
        }

        // input is word to evaluate. number is which index the loop is up to (started at 0 when called). outer is how many characters in the output word. 
        public void Anagram(string input, int number, int outer)
        {
            inputWordArray = input.ToCharArray();

            for (int i = 0; i < input.Length; i++)
            {
                skipThisLoop = false;
                // track which 'i' each of the recursing loops is up to.
                // if a previous loop is on the same 'i', continue past.
                // this stops the same character index being re-used in the result.
                duplicateTestArray[0 + number] = i;

                for (int j = number - 1; j >= 0; j--)
                {
                    if (duplicateTestArray[j] == i)
                    {
                        skipThisLoop = true;
                    }
                }

                if (skipThisLoop)
                {
                    continue;
                }

                builderArray[0 + number] = inputWordArray[i];

                if (number == input.Length - outer)

                {
                    // If the word is complete, add it to results
                    builtString = new string(builderArray);
                    resultList.Add(builtString);
                }

                if (number < input.Length - outer)
                {
                    // If word is not complete, recurse again to fill the next index in the word
                    Anagram(input, number + 1, outer);
                }
            }
        }
        /// <summary>
        /// Searches a collection of strings for a given string, based on String.Compare(), narrowing down the range recursively
        /// </summary>
        /// <param name="test">The string to search for</param>
        /// <param name="low">lowest starting index of the collection (normally 0)</param>
        /// <param name="high">highest starting index of the collection (normally Count - 1)</param>
        /// <returns>true or false, was the string present in the collection</returns>
        private bool BinaryChop(string test, int low, int high)
        {
            int midPoint = (high + low) / 2;

            if (high == low)
            {
                return false;
            }

            else if (String.Compare(test, engdicList[midPoint]) < 0)
            {
                return BinaryChop(test, low, midPoint);
            }

            else if (String.Compare(test, engdicList[midPoint]) > 0)
            {
                return BinaryChop(test, midPoint + 1, high);
            }

            else
            {
                return true;
            }
        }
        /// <summary>
        /// Output the results of the search to a text file.
        /// </summary>
        private void OutputToFile()
        {
            FileStream fs = File.Open($"{_inputWord}.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            foreach (string item in confirmedList)
            {
                sw.WriteLine(item);
            }
            sw.Close();
        }
        /// <summary>
        /// Output the results of the search to the console.
        /// </summary>
        private void OutputToConsole()
        {
            Console.WriteLine($"\n\n****\tRESULTS FOR {_inputWord.ToUpper()}\t****\n\n");

            foreach (string item in confirmedList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"\n\nI HOPE YOU LOVE YOUR {confirmedList.Count} ANAGRAM RESULTS!!!\n\n");
            Console.WriteLine($"\n\nPRESS ANY KEY TO EXIT.");
            Console.ReadLine();
            Environment.Exit(0);
        }

        /// <summary>
        /// Check whether this exact search has been performed before, if so, skip the unnecessary processing.
        /// </summary>
        /// /// <param name="input">The string decribing the .txt file generated on a previous search</param>
        private void SearchIsRepeated(string input)
        {
            FileStream fr1 = File.OpenRead($"{input}.txt");
            StreamReader sr1 = new StreamReader(fr1);
            while (!sr1.EndOfStream)
            {
                confirmedList.Add(sr1.ReadLine());
            }

            sr1.Close();
            OutputToConsole();
        }
        /// <summary>
        /// Load in the English dictionary, to compare results against.
        /// </summary>
        private void LoadDictionary()
        {
            StreamReader sr2 = new StreamReader("_engdic.txt");
            while (!sr2.EndOfStream)
            {
                string dicString = sr2.ReadLine();
                engdicList.Add(dicString);
            }
            sr2.Close();
        }
    }
}
