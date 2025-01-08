public class Solution {
    public int CountHillValley(int[] nums) {
        int count = 0;
        int n = nums.Length;
        int j = 0;

        for(int i = 1; i < n - 1; i++){
            if((nums[j] < nums[i] && nums[i] > nums[i + 1]) ||
            nums[j] > nums[i] && nums[i] < nums[i + 1]){
                count++;
                j = i;
            }
        }

        return count;
    }
}