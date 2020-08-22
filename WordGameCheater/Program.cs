using System;

namespace WordGameCheater
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, please enter the letters available");
            string inputString = Console.ReadLine();
            SolutionBuilder foo = new SolutionBuilder(inputString);
        }      
    }
}
