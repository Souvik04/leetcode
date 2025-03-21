public class Solution {
    public int MinSubArrayLen(int target, int[] nums) {
        int minSubArrSum = int.MaxValue;
        int left = 0;
        int right = 0;
        int curSum = 0;

        while(right < nums.Length){
            curSum += nums[right];

            while(curSum >= target){
                minSubArrSum = Math.Min(minSubArrSum, right - left + 1);
                curSum -= nums[left];
                left++;
            }

            right++;
        }

        return minSubArrSum == int.MaxValue ? 0 : minSubArrSum;
    }
}