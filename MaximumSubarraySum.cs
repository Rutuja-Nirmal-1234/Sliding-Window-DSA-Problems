// LeetCode 2461 - Maximum Sum of Distinct Subarrays With Length K
// https://leetcode.com/problems/maximum-sum-of-distinct-subarrays-with-length-k/

// Problem:
// Given an integer array nums and an integer k,
// find the maximum sum of a subarray of length k
// such that all elements in the subarray are distinct.
// If no such subarray exists, return 0.

// Approach (Sliding Window + HashSet):
// - Use a sliding window with two pointers (left, right).
// - Maintain a HashSet to ensure all elements in the window are distinct.
// - Maintain the current window sum.
// - If a duplicate is found, shrink the window from the left
//   until the duplicate is removed.
// - When window size becomes exactly k, update maxSum
//   and slide the window forward.

// Time Complexity: O(n)
// Space Complexity: O(k)

public class Solution {
    public long MaximumSubarraySum(int[] nums, int k) {

        if (k > nums.Length) return 0;

        HashSet<int> set = new HashSet<int>();
        int left = 0;
        long sum = 0;
        long maxSum = 0;

        for (int right = 0; right < nums.Length; right++) {

            // Remove elements until current element is unique
            while (set.Contains(nums[right])) {
                set.Remove(nums[left]);
                sum -= nums[left];
                left++;
            }

            // Add current element
            set.Add(nums[right]);
            sum += nums[right];

            // If window size is exactly k
            if (right - left + 1 == k) {
                maxSum = Math.Max(maxSum, sum);

                // Slide the window
                set.Remove(nums[left]);
                sum -= nums[left];
                left++;
            }
        }

        return maxSum;
    }
}
