public class Solution {
    public bool CanJump(int[] nums) {
        int max = nums.Length - 1;

        for(int i = nums.Length - 1; i >= 0; i--){
            if(i + nums[i] >= max){
                max = i;
            }
        }
        
        return max == 0;
    }
}

/*

greedy approach:

1. set goal as n - 1;
2. iterate over nums and check if i + nums[i] >= goal then set goal to i
3. return goal == 0

Time complexity: O(n)
Space complexity: O(1)

*/