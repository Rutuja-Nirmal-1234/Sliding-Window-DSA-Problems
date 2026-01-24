// LeetCode 2799 - Count Complete Subarrays in an Array
// https://leetcode.com/problems/count-complete-subarrays-in-an-array/

// Problem:
// A subarray is called complete if it contains all the distinct elements
// present in the entire array. Return the number of complete subarrays.

// Approach: Sliding Window + Hashing
// 1️⃣ First, find the total number of distinct elements in the array.
// 2️⃣ Use a sliding window with a frequency map.
// 3️⃣ Expand the window using the right pointer.
// 4️⃣ When the window becomes "complete" (freq.Count == totalDistinct),
//     count all subarrays starting at left and ending at right or beyond.
// 5️⃣ Shrink the window from the left to find more valid subarrays.

// Time Complexity: O(n)
// Space Complexity: O(n)

public class Solution {
    public int CountCompleteSubarrays(int[] nums) {
        int n = nums.Length;

        // Step 1: Count total distinct elements
        HashSet<int> set = new HashSet<int>(nums);
        int totalDistinct = set.Count;

        // Step 2: Sliding window
        Dictionary<int, int> freq = new Dictionary<int, int>();
        int left = 0;
        int ans = 0;

        for (int right = 0; right < n; right++) {

            if (!freq.ContainsKey(nums[right]))
                freq[nums[right]] = 0;

            freq[nums[right]]++;

            // Shrink window while it is complete
            while (freq.Count == totalDistinct) {
                ans += (n - right);

                freq[nums[left]]--;
                if (freq[nums[left]] == 0)
                    freq.Remove(nums[left]);

                left++;
            }
        }

        return ans;
    }
}
