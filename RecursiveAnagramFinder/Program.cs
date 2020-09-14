using System;
using System.Collections.Generic;

namespace RecursiveAnagramFinder
{
    class Program
    {
        static void Main(string[] args)
        {

            string inputWord;

            // Check user actually entered letters before instantiating object
            
            {
                while (true)
                {
                    Console.WriteLine($"\nPlease enter the word for which you require anagrams:");
                    inputWord = Console.ReadLine();

                    if (Evaluator.ValidateFormat(inputWord))
                    {
                        break;
                    }
                }
            }

            Evaluator go = new Evaluator(inputWord);
        }
    }
}
