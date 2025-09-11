// Problem: Longest Substring With At Most K Distinct Characters (Sliding Window)

// Question:
// Write a program to find the length of the longest substring 
// that contains at most K distinct characters.

// Input:
// - A string (e.g., "eceba")
// - An integer K (maximum number of distinct characters allowed)

// Output:
// - An integer representing the length of the longest valid substring

// Example:
// Input: "eceba", K = 2
// Output: 3   ("ece")
//
// Input: "aa", K = 1
// Output: 2   ("aa")
//
// Input: "abcadcacacaca", K = 3
// Output: 11  ("cadcacacaca")

// Notes:
// - Use a sliding window with two pointers (start, end).
// - Use a Dictionary to track character frequencies in the current window.
// - If distinct characters exceed K, shrink the window from the left.
// - Update maxLength whenever a larger valid window is found.

// Complexity:
// Time Complexity: O(n) (each character processed at most twice)
// Space Complexity: O(k) (dictionary stores at most K characters)

using System;
using System.Collections.Generic;

public class LongestSubstringKDistinct
{
    public static void Main(string[] args)
    {
        Console.Write("Enter a string: ");
        string s = Console.ReadLine();

        Console.Write("Enter value of K: ");
        int k = int.Parse(Console.ReadLine());

        int length = LengthOfLongestSubstringKDistinct(s, k);
        Console.WriteLine("Length of Longest Substring With At Most " + k + " Distinct Characters: " + length);
    }

    public static int LengthOfLongestSubstringKDistinct(string s, int k)
    {
        if (k == 0 || string.IsNullOrEmpty(s))
            return 0;

        Dictionary<char, int> charFrequency = new Dictionary<char, int>();
        int maxLength = 0, start = 0;

        for (int end = 0; end < s.Length; end++)
        {
            char c = s[end];
            if (charFrequency.ContainsKey(c))
                charFrequency[c]++;
            else
                charFrequency[c] = 1;

            // If distinct characters exceed K → shrink from left
            while (charFrequency.Count > k)
            {
                char startChar = s[start];
                charFrequency[startChar]--;

                if (charFrequency[startChar] == 0)
                    charFrequency.Remove(startChar);

                start++;
            }

            maxLength = Math.Max(maxLength, end - start + 1);
        }

        return maxLength;
    }
}