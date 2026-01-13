// LeetCode 438 - Find All Anagrams in a String
// https://leetcode.com/problems/find-all-anagrams-in-a-string/

// Problem:
// Given two strings s and p, return all the start indices of p's anagrams in s.

// Approach: Sliding Window + Frequency Count
// - Maintain frequency array for string p
// - Use a sliding window of size p.Length on string s
// - Compare window frequency with p frequency
// - If same, store the starting index

// Time Complexity: O(n * 26) ≈ O(n)
// Space Complexity: O(26) ≈ O(1)

public class Solution {
    public IList<int> FindAnagrams(string s, string p) {

        List<int> result = new List<int>();
        if (s.Length < p.Length) return result;

        int[] pFreq = new int[26];
        int[] winFreq = new int[26];

        // Frequency of pattern string p
        foreach (char ch in p) {
            pFreq[ch - 'a']++;
        }

        int left = 0;

        for (int right = 0; right < s.Length; right++) {

            // Add current character to window
            winFreq[s[right] - 'a']++;

            // Shrink window if size exceeds p length
            if (right - left + 1 > p.Length) {
                winFreq[s[left] - 'a']--;
                left++;
            }

            // Check for anagram
            if (right - left + 1 == p.Length) {
                if (IsSame(pFreq, winFreq)) {
                    result.Add(left);
                }
            }
        }

        return result;
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
