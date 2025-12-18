// Problem: Longest Substring Without Repeating Characters
// LeetCode: 3

// Description:
// Given a string s, find the length of the longest substring
// without repeating characters.

// Approach (Sliding Window + HashMap):
// 1. Use two pointers (start, end) to represent the window.
// 2. Store the last index of each character in a dictionary.
// 3. If a character repeats, move the start pointer to
//    max(lastIndex + 1, current start).
// 4. Update max length at each step.

// Example:
// Input: s = "abcabcbb"
// Output: 3  ("abc")

// Time Complexity: O(n)
// Space Complexity: O(min(n, charset))

using System;
using System.Collections.Generic;

public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        Dictionary<char, int> map = new Dictionary<char, int>();
        int maxLength = 0;
        int start = 0;

        for (int end = 0; end < s.Length; end++)
        {
            char current = s[end];

            // If character already exists in window
            if (map.ContainsKey(current))
            {
                // Move start only forward
                start = Math.Max(map[current] + 1, start);
            }

            // Update last seen index
            map[current] = end;

            // Update maximum length
            maxLength = Math.Max(maxLength, end - start + 1);
        }

        return maxLength;
    }
}
