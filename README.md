# WordGameCheater

A console application written in C#, to find all English words within a given string ~~of up to 8 letters.~~

### Installation

Navigate to RecursiveAnagramFinder\bin\Debug\netcoreapp3.1\

Run RecursiveAnagramFinder.exe

**THIS PROGRAM IS WORK IN PROGRESS. LONGER STRINGS NATURALLY TAKE EXPONENTIALLY LONGER TO RETURN RESULTS.**

I've increased speed by using a recursive binary search. strings of 10 characters or more still take a loooong time to conclude though. 
I wonder if multi-threading would help. Need to research this.

### ChangeLog:

22 / 9 / 2020

- Recursive binary search used when comparing potential anagrams to the dictionary, speeding search up massively.

14 / 9 / 2020

- Code rewritten to use recursion, in order to dynamically react to input strings of different lengths without hardcoded limitations.

22 / 8 / 2020

- Initial Commit.

_Contact: Simonjordan557@aol.com_ 
