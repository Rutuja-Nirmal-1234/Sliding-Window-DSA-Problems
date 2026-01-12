// LeetCode 904 - Fruit Into Baskets
// https://leetcode.com/problems/fruit-into-baskets/

// Problem:
// You are given an array fruits where fruits[i] is the type of fruit at position i.
// You have two baskets, and each basket can hold only one type of fruit.
// You can pick fruits from consecutive trees only.
// Return the maximum number of fruits you can pick.

// Approach (Sliding Window + HashMap):
// - Use a sliding window with two pointers (left, right).
// - Maintain a dictionary to count fruit types in the current window.
// - Expand the window by moving `right`.
// - If the number of distinct fruits exceeds 2, shrink the window from `left`.
// - Track the maximum window size where at most 2 fruit types exist.

// Time Complexity: O(n)
// Space Complexity: O(1) (at most 2 keys in the dictionary)

public class Solution {
    public int TotalFruit(int[] fruits) {

        Dictionary<int, int> map = new Dictionary<int, int>();
        int left = 0;
        int maxLen = 0;

        for (int right = 0; right < fruits.Length; right++) {

            if (!map.ContainsKey(fruits[right])) {
                map[fruits[right]] = 0;
            }
            map[fruits[right]]++;

            while (map.Count > 2) {
                map[fruits[left]]--;
                if (map[fruits[left]] == 0) {
                    map.Remove(fruits[left]);
                }
                left++;
            }

            maxLen = Math.Max(maxLen, right - left + 1);
        }

        return maxLen;
    }
}
