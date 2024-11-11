public class Solution {
    public int MaximalRectangle(char[][] matrix) {
        int maxArea = 0;
        int m = matrix.Length;
        int n = matrix[0].Length;
        int[] heights = new int[n];

        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                // update height
                heights[j] = matrix[i][j] == '1' ? heights[j] + 1 : 0;
            }

            maxArea = Math.Max(maxArea, GetArea(heights));
        }

        return maxArea;
    }

    private int GetArea(int[] heights){
        int area = 0;
        int n = heights.Length;
        Stack<int> stack = new Stack<int>();

        for(int i = 0; i <= n; i++){
            int currentHeight = i == n ? 0 : heights[i];

            // monotonically increasing
            while(stack.Count > 0 && heights[stack.Peek()] > currentHeight){
                int height = heights[stack.Pop()];
                int width = stack.Count == 0 ? i : i - stack.Peek() - 1;
                area = Math.Max(area, height * width);
            }

            stack.Push(i);
        }

        return area;
    }
}

/*

1. iterate over the matrix and calculate the heights for each row
2. check if a cell (i, j) is '1' then set the height[j] of that row to height[j] + 1.
this way if previous row had a specific height at any given position- j, that height gets
incremented and it forms a column height. if cell (i, j) is 0, reset height[j] to 0 
2. once we process the height of a row, calculate the maxArea using a monotonic stack
3. add a utility function- GetArea(heights[]) to calculate the height using monotonically 
increasing stack. its monotonically increasing because we need to find the smallest bar of height
which consequtively forms the rectangle
4. perform this for all the rows and update the maxArea = max(maxArea, GetArea(heights[]))
5. return the maxArea

Time complexity: O(m * n)
Space complexity: O(n)

*/