public class Solution {
    public int Trap(int[] height) {
        int output = 0;
        int n = height.Length;
        int left = 0;
        int right = n - 1;
        int leftMax = height[left];
        int rightMax = height[right];

        while(left < right){
            if(leftMax < rightMax){
                left++;
                leftMax = Math.Max(leftMax, height[left]);
                output += leftMax - height[left];
            }
            else{
                right--;
                rightMax = Math.Max(rightMax, height[right]);
                output += rightMax - height[right];
            }
        }

        return output;
    }
}