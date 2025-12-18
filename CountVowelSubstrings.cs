// Problem: Count Vowel Substrings of a String
// LeetCode: 2062

// Description:
// A vowel substring is a substring that contains only vowels
// ('a', 'e', 'i', 'o', 'u') and includes all five vowels at least once.
// Given a string word, return the number of vowel substrings.

// Approach (Brute Force + Hashing):
// 1. Fix a starting index i.
// 2. If word[i] is not a vowel, skip.
// 3. Expand substring while characters are vowels.
// 4. Track frequency of vowels using a dictionary.
// 5. If all 5 vowels are present, increment result.

// Example:
// Input: word = "aeiouu"
// Output: 2
// Explanation: "aeiou" and "aeiouu"

// Time Complexity: O(n²)
// Space Complexity: O(1)  (only 5 vowels stored)

using System;
using System.Collections.Generic;

public class Solution
{
    public int CountVowelSubstrings(string word)
    {
        int n = word.Length;
        int result = 0;

        HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };

        for (int i = 0; i < n; i++)
        {
            // start only if current char is vowel
            if (!vowels.Contains(word[i]))
                continue;

            Dictionary<char, int> freq = new Dictionary<char, int>();
            int unique = 0;

            for (int j = i; j < n && vowels.Contains(word[j]); j++)
            {
                if (!freq.ContainsKey(word[j]))
                {
                    freq[word[j]] = 0;
                    unique++;
                }

                freq[word[j]]++;

                // all 5 vowels present
                if (unique == 5)
                {
                    result++;
                }
            }
        }

        return result;
    }
}
