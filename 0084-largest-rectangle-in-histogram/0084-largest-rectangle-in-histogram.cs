public class Solution {
    public int LargestRectangleArea(int[] heights) {
        int maxArea = 0;
        Stack<int> stack = new Stack<int>();

        for(int i = 0; i <= heights.Length; i++){
            int currentHeight = i == heights.Length ? 0 : heights[i];

            while(stack.Count > 0 && heights[stack.Peek()] > currentHeight){
                int height = heights[stack.Pop()];
                int width = stack.Count == 0 ? i : i - stack.Peek() - 1;
                maxArea = Math.Max(maxArea, height * width);
            }

            stack.Push(i);
        }

        return maxArea;
    }
}