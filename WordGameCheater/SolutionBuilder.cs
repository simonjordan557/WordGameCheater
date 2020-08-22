using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WordGameCheater
{
    class SolutionBuilder
    {
        string keyLetters = "";
        int keyLettersLength;
        char[] keyLettersArray;
        char[] builderArray;
        List<string> resultsList = new List<string>();
        List<string> confirmedList = new List<string>();
        List<string> engdicList = new List<string>();

        public SolutionBuilder(string str)
        {
            if ((ValidateInput(str)) && (ValidateFormat(str)))
            {
                using (StreamReader sr = new StreamReader("engdic.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        string dicString = sr.ReadLine();
                        if (dicString.Length <= 8)
                        {
                            engdicList.Add(dicString);
                        }


                    }
                    sr.Close();
                }

                keyLetters = str.ToLower();

                keyLettersLength = keyLetters.Length;

                keyLettersArray = keyLetters.ToCharArray();

                switch (keyLettersLength)
                {
                    case 3:
                        {
                            ThreeLetters();
                            break;
                        }

                    case 4:
                        {
                            FourLetters();
                            break;
                        }

                    case 5:
                        {
                            FiveLetters();
                            break;
                        }

                    case 6:
                        {
                            SixLetters();
                            break;
                        }

                    case 7:
                        {
                            SevenLetters();
                            break;
                        }

                    case 8:
                        {
                            EightLetters();
                            break;
                        }
                }

            }

           

        }
        private bool ValidateInput(string testLetters)
        {



            if (testLetters.Length < 3 || testLetters.Length > 8)
            {

                Console.WriteLine($"{testLetters.Length} letters is not a valid amount - enter between 3 to 8 letters.\n");
                return false;

            }

            else
            {
                return true;
            }

        }

        private bool ValidateFormat(string testLetters)
        {



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

            

            public void ThreeLetters()
            {

                builderArray = new char[3];

                resultsList.Add("\n3 LETTER WORDS:\n");

                for (int i = 0; i < keyLettersArray.Length; i++)
                {
                    builderArray[0] = keyLettersArray[i];

                    for (int j = 0; j < keyLettersArray.Length; j++)
                    {
                        if (j == i) continue;
                        builderArray[1] = keyLettersArray[j];

                        for (int k = 0; k < keyLettersArray.Length; k++)
                        {
                            if ((k == j) || (k == i)) continue;
                            builderArray[2] = keyLettersArray[k];

                            string builtString = new string(builderArray);

                            resultsList.Add(builtString);
                        }
                    }
                }

                CompareStrings();
            }

            public void FourLetters()
            {

                builderArray = new char[4];

                resultsList.Add("\n4 LETTER WORDS:\n");

                for (int i = 0; i < keyLettersArray.Length; i++)
                {
                    builderArray[0] = keyLettersArray[i];

                    for (int j = 0; j < keyLettersArray.Length; j++)
                    {
                        if (j == i) continue;
                        builderArray[1] = keyLettersArray[j];

                        for (int k = 0; k < keyLettersArray.Length; k++)
                        {
                            if ((k == j) || (k == i)) continue;
                            builderArray[2] = keyLettersArray[k];

                            for (int l = 0; l < keyLettersArray.Length; l++)
                            {
                                if ((l == k) || (l == j) || (l == i)) continue;
                                builderArray[3] = keyLettersArray[l];

                                string builtString = new string(builderArray);

                                resultsList.Add(builtString);
                            }
                        }
                    }
                }


                ThreeLetters();
            }

            public void FiveLetters()
            {

                builderArray = new char[5];

                resultsList.Add("\n5 LETTER WORDS:\n");

                for (int i = 0; i < keyLettersArray.Length; i++)
                {
                    builderArray[0] = keyLettersArray[i];

                    for (int j = 0; j < keyLettersArray.Length; j++)
                    {
                        if (j == i) continue;
                        builderArray[1] = keyLettersArray[j];

                        for (int k = 0; k < keyLettersArray.Length; k++)
                        {
                            if ((k == j) || (k == i)) continue;
                            builderArray[2] = keyLettersArray[k];

                            for (int l = 0; l < keyLettersArray.Length; l++)
                            {
                                if ((l == k) || (l == j) || (l == i)) continue;
                                builderArray[3] = keyLettersArray[l];

                                for (int m = 0; m < keyLettersArray.Length; m++)
                                {
                                    if ((m == l) || (m == k) || (m == j) || (m == i)) continue;
                                    builderArray[4] = keyLettersArray[m];

                                    string builtString = new string(builderArray);

                                    resultsList.Add(builtString);
                                }
                            }
                        }
                    }
                }


                FourLetters();
            }

            public void SixLetters()
            {

                resultsList.Add("\n6 LETTER WORDS:\n");

                builderArray = new char[6];

                for (int i = 0; i < keyLettersArray.Length; i++)
                {
                    builderArray[0] = keyLettersArray[i];

                    for (int j = 0; j < keyLettersArray.Length; j++)
                    {
                        if (j == i) continue;
                        builderArray[1] = keyLettersArray[j];

                        for (int k = 0; k < keyLettersArray.Length; k++)
                        {
                            if ((k == j) || (k == i)) continue;
                            builderArray[2] = keyLettersArray[k];

                            for (int l = 0; l < keyLettersArray.Length; l++)
                            {
                                if ((l == k) || (l == j) || (l == i)) continue;
                                builderArray[3] = keyLettersArray[l];

                                for (int m = 0; m < keyLettersArray.Length; m++)
                                {
                                    if ((m == l) || (m == k) || (m == j) || (m == i)) continue;
                                    builderArray[4] = keyLettersArray[m];

                                    for (int n = 0; n < keyLettersArray.Length; n++)
                                    {
                                        if ((n == m) || (n == l) || (n == k) || (n == j) || (n == i)) continue;
                                        builderArray[5] = keyLettersArray[n];

                                        string builtString = new string(builderArray);

                                        resultsList.Add(builtString);
                                    }
                                }
                            }
                        }
                    }
                }


                FiveLetters();
            }

            public void SevenLetters()
            {

                resultsList.Add("\n7 LETTER WORDS:\n");

                builderArray = new char[7];

                for (int i = 0; i < keyLettersArray.Length; i++)
                {
                    builderArray[0] = keyLettersArray[i];

                    for (int j = 0; j < keyLettersArray.Length; j++)
                    {
                        if (j == i) continue;
                        builderArray[1] = keyLettersArray[j];

                        for (int k = 0; k < keyLettersArray.Length; k++)
                        {
                            if ((k == j) || (k == i)) continue;
                            builderArray[2] = keyLettersArray[k];

                            for (int l = 0; l < keyLettersArray.Length; l++)
                            {
                                if ((l == k) || (l == j) || (l == i)) continue;
                                builderArray[3] = keyLettersArray[l];

                                for (int m = 0; m < keyLettersArray.Length; m++)
                                {
                                    if ((m == l) || (m == k) || (m == j) || (m == i)) continue;
                                    builderArray[4] = keyLettersArray[m];

                                    for (int n = 0; n < keyLettersArray.Length; n++)
                                    {
                                        if ((n == m) || (n == l) || (n == k) || (n == j) || (n == i)) continue;
                                        builderArray[5] = keyLettersArray[n];

                                        for (int o = 0; o < keyLettersArray.Length; o++)
                                        {
                                            if ((o == n) || (o == m) || (o == l) || (o == k) || (o == j) || (o == i)) { continue; }
                                            builderArray[6] = keyLettersArray[o];

                                            string builtString = new string(builderArray);

                                            resultsList.Add(builtString);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }


                SixLetters();
            }

            public void EightLetters()
            {

                resultsList.Add("\n8 LETTER WORDS:\n");

                builderArray = new char[8];

                for (int i = 0; i < keyLettersArray.Length; i++)
                {
                    builderArray[0] = keyLettersArray[i];

                    for (int j = 0; j < keyLettersArray.Length; j++)
                    {
                        if (j == i) continue;
                        builderArray[1] = keyLettersArray[j];

                        for (int k = 0; k < keyLettersArray.Length; k++)
                        {
                            if ((k == j) || (k == i)) continue;
                            builderArray[2] = keyLettersArray[k];

                            for (int l = 0; l < keyLettersArray.Length; l++)
                            {
                                if ((l == k) || (l == j) || (l == i)) continue;
                                builderArray[3] = keyLettersArray[l];

                                for (int m = 0; m < keyLettersArray.Length; m++)
                                {
                                    if ((m == l) || (m == k) || (m == j) || (m == i)) continue;
                                    builderArray[4] = keyLettersArray[m];

                                    for (int n = 0; n < keyLettersArray.Length; n++)
                                    {
                                        if ((n == m) || (n == l) || (n == k) || (n == j) || (n == i)) continue;
                                        builderArray[5] = keyLettersArray[n];

                                        for (int o = 0; o < keyLettersArray.Length; o++)
                                        {
                                            if ((o == n) || (o == m) || (o == l) || (o == k) || (o == j) || (o == i)) { continue; }
                                            builderArray[6] = keyLettersArray[o];

                                            for (int p = 0; p < keyLettersArray.Length; p++)
                                            {
                                                if ((p == o) || (p == n) || (p == m) || (p == l) || (p == k) || (p == j) || (p == i)) continue;
                                                builderArray[7] = keyLettersArray[p];

                                                string builtString = new string(builderArray);

                                                resultsList.Add(builtString);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }


                SevenLetters();

            }

            
            private void CompareStrings()
            {
                foreach (var item in resultsList)
                {
                    if (engdicList.IndexOf(item) < 0)
                    {
                        continue;
                    }

                    else
                    {
                        confirmedList.Add(item);
                    }
                }

            Console.WriteLine("\n\n****\tRESULTS:\t****\n\n");

                for (int j = 0; j < confirmedList.Count; j++)
                {
                string item = new string(confirmedList[j]);
                
                bool duplicatedItem = false;

                for (int i = j + 1; i < confirmedList.Count; i++)
                {
                    if (item.Equals(confirmedList[i]))
                        {
                        
                        duplicatedItem = true;
                        }
                }

                if (duplicatedItem == false)
                {
                    Console.WriteLine(item);
                }
                    

                }

                Console.ReadLine();

            }

        }
    }
