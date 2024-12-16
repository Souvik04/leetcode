public class Solution {
    public long MaxSubarraySum(int[] nums, int k) {
        // Create prefix sum array
        List<long> ps = new List<long> { 0 };
        foreach (int n in nums) {
            ps.Add(ps.Last() + n);
        }

        long res = long.MinValue; // Initialize to the smallest possible value

        // Outer loop to consider starting points for the subarrays
        for (int p = 0; p < k; ++p) {
            long sum = 0;
            // Inner loop to check subarrays starting from `p`
            for (int i = p; i + k <= nums.Length; i += k) {
                long n = ps[i + k] - ps[i]; // Get the sum of the subarray of length `k`
                sum = Math.Max(n, sum + n);  // Kadane's algorithm: max of current subarray sum and new subarray sum
                res = Math.Max(res, sum);    // Update the maximum result
            }
        }

        return res;
    }
}



/*

1. calculate prefix sum
2. iterate over 0 to k on outer loop
3. apply Kadane's algorithm on inner loop for eack k length values from prefix sum
4. update the result based on each 
5. return the answer

Time complexity:
O(n2) when k is 1
O(n) when k is large

Space complexity: O(n)

*/