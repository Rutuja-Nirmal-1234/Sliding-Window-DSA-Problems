// Problem: Print Subarray with Given Sum

// Description:
// Given an array of positive integers and a target sum k,
// find and print the first continuous subarray whose sum equals k.
// If no such subarray exists, print "No subarray found".

// Approach:
// Use the Sliding Window technique (Two Pointers).
// - Expand the window by moving the right pointer.
// - Shrink the window from the left if the sum exceeds k.
// This approach works only when all elements are positive.

// Example:
// Input:  nums = [1, 4, 20, 3, 10, 5], k = 33
// Output: Subarray found: 20 3 10

// Time Complexity: O(n)
// Space Complexity: O(1)

using System;

public class Program
{
    public static void FindSubarray(int[] nums, int k)
    {
        int left = 0;
        int sum = 0;

        for (int right = 0; right < nums.Length; right++)
        {
            sum += nums[right];

            while (sum > k && left <= right)
            {
                sum -= nums[left];
                left++;
            }

            if (sum == k)
            {
                Console.Write("Subarray found: ");
                for (int i = left; i <= right; i++)
                    Console.Write(nums[i] + " ");
                return;
            }
        }

        Console.WriteLine("No subarray found");
    }

    public static void Main()
    {
        int[] nums = {1, 4, 20, 3, 10, 5};
        int k = 33;

        FindSubarray(nums, k);
    }
}
