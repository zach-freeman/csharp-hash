using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace hashstring
{
    class Program
    {
        static string letters = "acdegilmnoprstuw";
        static void Main(string[] args)
        {
            findAllPossibleStrings(letters);           
        }

        static bool testThisString(string stringToTest) 
        {
            bool foundTheMagicString = false;
            Int64 actualHashValue = hash(stringToTest);
            //Int64 expectedHashValue = 675202166929;
            Int64 expectedHashValue = 683122939450;
            if (actualHashValue == expectedHashValue)
            {
                Console.WriteLine("Success. hashValue: " + actualHashValue.ToString());
                Console.WriteLine("The magic string is " + stringToTest);
                foundTheMagicString = true;
            }
            return foundTheMagicString;

        }

        static Int64 hash(String s)
        {
            Int64 h = 7;
            String letters = "acdegilmnoprstuw";
            for (Int32 i = 0; i < s.Length; i++)
            {
                Char currentCharacter = s[i];
                Int32 letterIndexOfCurrentCharacter = letters.IndexOf(currentCharacter);
                h = h * 37 + letterIndexOfCurrentCharacter;
            }
            return h;
        }

        static void findAllPossibleStrings(string letters)
        {
            char[] testSet = letters.ToCharArray(0, letters.Length);
            int stringLength = 7;
            findAllKLengthStrings(testSet, stringLength);
        }

        static void findAllKLengthStrings(char[] set, int k) 
        {
            int n = set.Length;        
            findAllKLengthRecursive(set, "", n, k);
        }

        static void findAllKLengthRecursive(char[] set, string prefix, int n, int k)
        {
            // Base case: k is 0, print prefix
            if (k == 0) {
                bool foundString = testThisString(prefix);
                if (foundString == true)
                {
                    Console.ReadLine();
                }
                return;
            }
 
            // One by one add all characters from set and recursively 
            // call for k equals to k-1
            for (int i = 0; i < n; ++i) {
             
                // Next character of input added
                String newPrefix = prefix + set[i]; 
             
                // k is decreased, because we have added a new character
                findAllKLengthRecursive(set, newPrefix, n, k - 1); 
            }
        }
    }
}

