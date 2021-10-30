using System;
using System.Diagnostics;
using System.Linq;

namespace IsPalindrome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("enter a word or phrase to see if its a palindrome: ");
            var input = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine(IsPalindromeNotLinq(input));
        }

        static bool IsEven(string word)
        {
            return word.Length % 2 == 0;
        }

        static bool HasDouble(string word, char letter)
        {
            var letters = word.Where(x => x.Equals(letter));

            return letters.Count() % 2 == 0;
        }

        static bool RearrangedPalindrome (string word)
        {
            var allowedNonMatched = 0;
            var nonMatches = 0;

            if (!IsEven(word))
            {
                allowedNonMatched = 1;
            }

            foreach (var letter in word)
            {
                if(HasDouble(word, letter))
                {
                    continue;
                }
                nonMatches++;
                
                if(nonMatches > allowedNonMatched)
                {
                    return false;
                }
            }

            return true;
        }


        static bool IsPalindromeNotLinq (string word)
        {
            for (int i = 0; i < word.Length / 2; i++)
            {
                if (word[i] == word[(word.Length-1) - i])
                {
                    continue; // carrace | racecar
                }

                return RearrangedPalindrome(word);
            }

            return true;
        }
    }
}


//static bool IsPalindromeLinq (string word)
//{
//    var reverseWord = string.Join("", word.Reverse());

//    return word.Equals(reverseWord);
//}
