using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace RecursiveAnagramFinder
{
    class Evaluator
    {

        char[] builderArray;
        int[] duplicateTestArray;
        bool skipThisLoop;
        char[] inputWordArray;
        string builtString = "";
        List<string> resultList = new List<string>();
        List<string> engdicList = new List<string>();
        public List<string> confirmedList = new List<string>();

        public Evaluator(string inputWord)
        {
            
            Console.Clear();
            Console.WriteLine($"\n\nPlease wait, finding anagrams of {inputWord}. This may take a while.\n\n");

            // If it is, load in the English dictionary
            using (StreamReader sr = new StreamReader("engdic.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string dicString = sr.ReadLine();
                    engdicList.Add(dicString);
                }
                sr.Close();
            }

            // This array tracks which character(s) are already used to avoid repeats
            duplicateTestArray = new int[inputWord.Length];
            for (int i = 0; i < duplicateTestArray.Length; i++)
            {
                duplicateTestArray[i] = -1;
            }

            // Starts the Anagram function looping through all possibilities, and all lengths of words. 
            // Recursion within the function itself will automate the results.
            // This loop starts the function outputting result strings of the same length as the input string.
            // Each loop returns strings of a shorter length.
            for (int i = 1; i < inputWord.Length; i++)
            {
                
                builderArray = new char[inputWord.Length - (i - 1)];
                Anagram(inputWord, 0, i);

                foreach (var result in resultList)
                {
                    // Check the result is a valid word
                    if (engdicList.IndexOf(result) < 0)
                    {
                        continue;
                    }

                    else
                    {
                        confirmedList.Add(result);
                    }
                }
            }

            // Print results, removing duplicated items (repeated characters i.e. 'ball' and 'ball')
            Console.WriteLine("\n\n****\tRESULTS:\t****\n\n");

            for (int j = 0; j < confirmedList.Count; j++)
            {
                string item = new string(confirmedList[j]);

                bool duplicatedItem = false;

                for (int k = j + 1; k < confirmedList.Count; k++)
                {
                    if (item.Equals(confirmedList[k]))
                    {

                        duplicatedItem = true;
                    }
                }

                if (duplicatedItem == false)
                {
                    Console.WriteLine(item);
                }
            }

            Console.WriteLine($"\n\nI HOPE YOU LOVE YOUR ANAGRAM RESULTS!!!\n\n");
            Console.WriteLine($"\n\nPRESS ANY KEY TO EXIT.");
            Console.ReadLine();
        }

        // Check an input is a word
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
    }
}
