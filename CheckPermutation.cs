// LeetCode 567 - Permutation in String
// https://leetcode.com/problems/permutation-in-string/

// Problem:
// Given two strings s1 and s2, return true if s2 contains a permutation of s1.

// Approach: Sliding Window + Frequency Array
// - Count frequency of characters in s1
// - Use a sliding window of size s1.Length on s2
// - Maintain frequency of current window
// - If both frequency arrays match, permutation exists

// Time Complexity: O(n * 26) ≈ O(n)
// Space Complexity: O(26) ≈ O(1)

public class Solution {
    public bool CheckInclusion(string s1, string s2) {

        if (s1.Length > s2.Length) return false;

        int[] s1Freq = new int[26];
        int[] winFreq = new int[26];

        // Frequency of s1
        foreach (char ch in s1) {
            s1Freq[ch - 'a']++;
        }

        int left = 0;

        for (int right = 0; right < s2.Length; right++) {

            // Add current character to window
            winFreq[s2[right] - 'a']++;

            // Shrink window if size exceeds s1 length
            if (right - left + 1 > s1.Length) {
                winFreq[s2[left] - 'a']--;
                left++;
            }

            // Check permutation
            if (right - left + 1 == s1.Length) {
                if (IsSame(s1Freq, winFreq)) {
                    return true;
                }
            }
        }

        return false;
    }

    private bool IsSame(int[] a, int[] b) {
        for (int i = 0; i < 26; i++) {
            if (a[i] != b[i]) {
                return false;
            }
        }
        return true;
    }
}
