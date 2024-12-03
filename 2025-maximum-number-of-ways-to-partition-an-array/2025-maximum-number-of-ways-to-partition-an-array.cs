public class Solution {
    public int WaysToPartition(int[] nums, int k) {
        int n = nums.Length;
        int totalSum = 0, maxPartitions = 0;
        List<int> prefixSum = new List<int>();
        Dictionary<int, int> prefixCount = new Dictionary<int, int>();
        Dictionary<int, int> suffixCount = new Dictionary<int, int>();

        // Calculate the total sum of array and populate prefix sum and suffix count
        foreach (int num in nums) {
            totalSum += num;
            prefixSum.Add(totalSum);
            if (!suffixCount.ContainsKey(totalSum)) {
                suffixCount[totalSum] = 0;
            }
            suffixCount[totalSum]++;
        }

        // Decrease the count of the last sum in the suffix count
        suffixCount[totalSum]--;

        // If the total sum is even, check for valid partitions in the suffix count
        if (totalSum % 2 == 0) {
            maxPartitions += suffixCount.GetValueOrDefault(totalSum / 2, 0);
        }

        // Iterate over the array and adjust the partition count based on updates
        for (int i = 0; i < n; i++) {
            int currentPartitions = 0;

            // If the current element is not equal to k, calculate the new sum
            if (nums[i] != k) {
                int newSum = totalSum + k - nums[i];

                // If the new sum is even, check for valid partitions on both sides
                if (newSum % 2 == 0) {
                    if (i > 0) {
                        currentPartitions += prefixCount.GetValueOrDefault(newSum / 2, 0);
                    }
                    if (i < n - 1) {
                        currentPartitions += suffixCount.GetValueOrDefault(newSum / 2 + nums[i] - k, 0);
                    }
                }
            }

            // Update the maximum partitions found
            maxPartitions = Math.Max(maxPartitions, currentPartitions);

            // Update the suffix and prefix counts
            suffixCount[prefixSum[i]]--;
            if (!prefixCount.ContainsKey(prefixSum[i])) {
                prefixCount[prefixSum[i]] = 0;
            }
            prefixCount[prefixSum[i]]++;
        }

        return maxPartitions;
    }
}
