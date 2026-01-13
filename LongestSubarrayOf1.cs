// LeetCode 1493 - Longest Subarray of 1's After Deleting One Element
// https://leetcode.com/problems/longest-subarray-of-1s-after-deleting-one-element/

// Problem:
// Given a binary array nums, you must delete exactly one element.
// Return the size of the longest non-empty subarray containing only 1's.

// Approach (Sliding Window):
// - Use a sliding window that allows at most one zero inside the window.
// - `zeros` counts how many 0s are currently in the window.
// - Expand the window using `right`.
// - If zeros > 1, shrink the window from the left.
// - Since one element must be deleted, the window length is (right - left).

// Time Complexity: O(n)
// Space Complexity: O(1)

public class Solution {
    public int LongestSubarray(int[] nums) {

        int zeros = 0;
        int left = 0;
        int maxLen = 0;

        for (int right = 0; right < nums.Length; right++) {

            if (nums[right] == 0) {
                zeros++;
            }

            while (zeros > 1) {
                if (nums[left] == 0) {
                    zeros--;
                }
                left++;
            }

            // right - left because one element must be deleted
            maxLen = Math.Max(maxLen, right - left);
        }

        return maxLen;
    }
}
