// LeetCode 424 - Longest Repeating Character Replacement
// https://leetcode.com/problems/longest-repeating-character-replacement/

// Problem:
// You are given a string s consisting of uppercase English letters
// and an integer k. You can replace at most k characters in the string
// so that the resulting substring contains only one repeating character.
// Return the length of the longest such substring.

// Approach (Sliding Window + Frequency Count):
// - Use a sliding window with two pointers (left, right).
// - Maintain a frequency array of size 26 for characters.
// - Track the maximum frequency (maxFreq) of any character
//   in the current window.
// - Window is valid if:
//     windowLength - maxFreq <= k
// - If invalid, shrink the window from the left.
// - Update the maximum valid window length.

// Key Insight:
// We do NOT decrease maxFreq when shrinking the window.
// This works because maxLen is only updated for valid windows,
// and an overestimated maxFreq does not affect correctness.

// Time Complexity: O(n)
// Space Complexity: O(1)  (26-sized array)

public class Solution {
    public int CharacterReplacement(string s, int k) {

        int[] freq = new int[26];
        int left = 0;
        int maxFreq = 0;
        int maxLen = 0;

        for (int right = 0; right < s.Length; right++) {

            int index = s[right] - 'A';
            freq[index]++;

            // Track the highest frequency character in the window
            maxFreq = Math.Max(maxFreq, freq[index]);

            // If replacements needed exceed k, shrink window
            while ((right - left + 1) - maxFreq > k) {
                freq[s[left] - 'A']--;
                left++;
            }

            // Update maximum valid window length
            maxLen = Math.Max(maxLen, right - left + 1);
        }

        return maxLen;
    }
}
