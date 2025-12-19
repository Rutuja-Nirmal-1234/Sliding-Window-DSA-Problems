// Problem: Largest Subarray with Zero Sum

// Description:
// Given an integer array arr, find the length of the
// longest subarray whose sum is equal to 0.

// Approach (Prefix Sum + HashMap):
// 1. Maintain a running prefix sum.
// 2. If prefix sum becomes 0 at index i,
//    then subarray [0..i] has sum 0.
// 3. If the same prefix sum is seen again,
//    the elements between those indices sum to 0.
// 4. Store only the first occurrence of each prefix sum
//    to maximize the subarray length.

// Example:
// Input: arr = [15, -2, 2, -8, 1, 7, 10, 23]
// Output: 5   (subarray: [-2, 2, -8, 1, 7])

// Time Complexity: O(n)
// Space Complexity: O(n)

using System;
using System.Collections.Generic;

public class Solution
{
    public int LargestZeroSumSubarray(int[] arr)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();
        int sum = 0;
        int maxLen = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];

            // Case 1: Subarray from index 0 to i
            if (sum == 0)
            {
                maxLen = i + 1;
            }

            // Case 2: Prefix sum already seen
            if (map.ContainsKey(sum))
            {
                maxLen = Math.Max(maxLen, i - map[sum]);
            }
            else
            {
                // Store first occurrence of sum
                map[sum] = i;
            }
        }

        return maxLen;
    }
}
