public class Solution {
    public int MaxWidthRamp(int[] nums) {
        int maxWidth = 0;
        Stack<int> stack = new Stack<int>();
        int n = nums.Length;

        // first pass- store inndices in stack in monotonically decreasing order
        for(int i = 0; i < n; i++){
            if(stack.Count == 0 || nums[stack.Peek()] > nums[i]){
                stack.Push(i);
            }
        }

        // second pass: iterate backwards and check if criteria satisfies, update max
        for(int i = n - 1; i >= 0; i--){
            while(stack.Count > 0 && nums[stack.Peek()] <= nums[i]){
                maxWidth = Math.Max(maxWidth, i - stack.Pop());
            }
        }

        return maxWidth;
    }
}

/*

1. first pass- create a monotonically decreasing (nums[stack.Peek() >= nums[i]]) stack of indices
2. second pass- iterate from backwards and check if nums[stack.Peek()] <= nums[i], update maxWidth

Time complexity: O(n)
Space complexity: O(n)

*/