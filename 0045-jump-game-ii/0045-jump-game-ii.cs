public class Solution {
    public int Jump(int[] nums) {
        int jumps = 0;
        int currentMax = 0;
        int goal = 0;

        for(int i = 0; i < nums.Length - 1; i++){
            currentMax = Math.Max(currentMax, i + nums[i]);

            if(i == goal){
                jumps++;
                goal = currentMax;            
            }

            if(goal >= nums.Length - 1){
                break;
            }                
        }

        return jumps;
    }
}

/*

1. initialize jumps = 0, goal = 0, currentMax = 0
2. iterate over nums and set currentMax = max(currentMax, i + nums[i]) as farthest jump from 0 to n - 1
3. check if i == goal, increment jumps by 1 and set goal = currentMax
4. if goal >= n - 1, break as we reach end
4. return jumps as output

Time complexity: O(n)
Space complexity: O(1)

*/