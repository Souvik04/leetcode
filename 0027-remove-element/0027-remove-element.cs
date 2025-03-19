public class Solution {
    public int RemoveElement(int[] nums, int val) {
        int count = 0;

        Array.Sort(nums);
        
        for(int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == val)
            {
                count++;
                nums[i] = nums[nums.Length - count];
            }
        }

        return nums.Length - count;
    }
}