public class Solution {
    public int MaxAreaOfIsland(int[][] grid) {
        int maxArea = 0;

        for(int i = 0; i < grid.Length; i++){
            for(int j = 0; j < grid[0].Length; j++){
                if(grid[i][j] == 1){
                    maxArea = Math.Max(maxArea, GetArea(grid, i, j));
                }
            }
        }

        return maxArea;
    }

    private int GetArea(int[][] grid, int row, int col){
        if(row < 0 || row >= grid.Length || col < 0 || col >= grid[0].Length || grid[row][col] == 0){
            return 0;
        }

        grid[row][col] = 0;

        int count = 1;
        int[] dr = new int[4]{1, 0, -1 ,0};
        int[] dc = new int[4]{0, 1, 0 , -1};

        for(int i = 0; i < 4; i++){
            int newR = dr[i] + row;
            int newC = dc[i] + col;
            count += GetArea(grid, newR, newC);
        }

        return count;
    }
}