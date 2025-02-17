public class Solution {
    public int MaxArea(int[] height) {
        int maxArea = 0;
        int left = 0;
        int right = height.Length - 1;

        while(left < right){
            int width = Math.Min(height[left], height[right]);
            int length = right - left;
            maxArea = Math.Max(maxArea, (length * width));

            if(height[left] < height[right]){
                left++;
            }
            else{
                right--;
            }
        }

        return maxArea;
    }
}

/*

Time complexity: O(n)
Space complexity: (1)

*/