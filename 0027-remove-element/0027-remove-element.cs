public class Solution {
    public int RemoveElement(int[] nums, int val) {
        int n = nums.Length;
        int left = 0;

        for(int right = 0; right < n; right++){
            if(nums[right] != val){
                nums[left] = nums[right];
                left++;
            }
        }

        return left;
    }
}