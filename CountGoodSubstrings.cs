// LeetCode 1876 - Substrings of Size Three with Distinct Characters
// https://leetcode.com/problems/substrings-of-size-three-with-distinct-characters/

// Problem:
// Given a string s, return the number of substrings of length 3
// that consist of distinct characters.

// Approach (Fixed Window of Size 3):
// - Traverse the string up to length - 3
// - For every index i, check characters at i, i+1, i+2
// - Count substring if all three characters are different

// Time Complexity: O(n)
// Space Complexity: O(1)

public class Solution {
    public int CountGoodSubstrings(string s) {

        int count = 0;

        for (int i = 0; i <= s.Length - 3; i++) {
            char a = s[i];
            char b = s[i + 1];
            char c = s[i + 2];

            if (a != b && a != c && b != c) {
                count++;
            }
        }

        return count;
    }
}
