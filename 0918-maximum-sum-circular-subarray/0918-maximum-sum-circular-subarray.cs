public class Solution {
    public int MaxSubarraySumCircular(int[] nums) {
        int maxEndingHere = nums[0];
        int maxSoFar = nums[0];
        int totalSum = nums[0];

        for(int i = 1; i < nums.Length; i++){
            maxEndingHere = Math.Max(nums[i], maxEndingHere + nums[i]);
            maxSoFar = Math.Max(maxSoFar, maxEndingHere);
            totalSum += nums[i];
        }

        int minEndingHere = nums[0];
        int minSoFar = nums[0];

        for(int i = 1; i < nums.Length; i++){
            minEndingHere = Math.Min(nums[i], minEndingHere + nums[i]);
            minSoFar = Math.Min(minSoFar, minEndingHere);
        }

        int maxCircularSum = totalSum - minSoFar;

        return maxCircularSum == 0 ? maxSoFar : Math.Max(maxSoFar, maxCircularSum);
    }
}