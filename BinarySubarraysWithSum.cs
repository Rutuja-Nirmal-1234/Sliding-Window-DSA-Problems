// LeetCode 930 - Binary Subarrays With Sum
// https://leetcode.com/problems/binary-subarrays-with-sum/

// Approach:
// Use the "At Most" sliding window technique.
// Exactly(goal) = AtMost(goal) - AtMost(goal - 1)
//
// Works because the array contains only 0s and 1s.

// Time Complexity: O(n)
// Space Complexity: O(1)

public class Solution {
    public int NumSubarraysWithSum(int[] nums, int goal) {
        return AtMost(nums, goal) - AtMost(nums, goal - 1);
    }

    private int AtMost(int[] nums, int k) {
        if (k < 0) return 0;

        int left = 0;
        int sum = 0;
        int count = 0;

        for (int right = 0; right < nums.Length; right++) {
            sum += nums[right];

            while (sum > k) {
                sum -= nums[left];
                left++;
            }

            // number of valid subarrays ending at 'right'
            count += right - left + 1;
        }

        return count;
    }
}
