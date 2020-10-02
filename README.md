# WordGameCheater

A console application written in C#, to find all English words within a given string ~~of up to 8 letters.~~

### Installation

Navigate to RecursiveAnagramFinder\bin\Debug\netcoreapp3.1\

Run RecursiveAnagramFinder.exe

**THIS PROGRAM IS WORK IN PROGRESS. LONGER STRINGS NATURALLY TAKE EXPONENTIALLY LONGER TO RETURN RESULTS.**

I've increased speed by using a recursive binary search. strings of 10 characters or more still take a loooong time to conclude though. 
I wonder if multi-threading would help. Need to research this.

### ChangeLog:

2 / 10 / 2020

- Outputs results to .txt file as well as the Console.
- Checks to see if the input word, or its equal-length anagram, has previously been searched. If so, use that previous output instead of reprocessing the same data.
- Removed need to check for duplicate results by storing results in a hashset instead of a list (Automatically ignores duplicate entries).
- States how many results were found in the Console output.
- Made the dictionary readonly to avoid accidental overwriting in edge case of user searching the string 'engdic'!

22 / 9 / 2020

- Recursive binary search used when comparing potential anagrams to the dictionary, speeding search up massively.

14 / 9 / 2020

- Code rewritten to use recursion, in order to dynamically react to input strings of different lengths without hardcoded limitations.

22 / 8 / 2020

- Initial Commit.

_Contact: Simonjordan557@aol.com_ 
