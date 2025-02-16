public class Solution {
    public int NumIslands(char[][] grid) {
        int islandCount = 0;
        
        for(int i = 0; i < grid.Length; i++){
            for(int j = 0; j < grid[0].Length; j++){
                if(grid[i][j] == '1'){
                    DFS(grid, i, j);
                    islandCount++;
                }
            }
        }
        
        return islandCount;
    }
    
    private void DFS(char[][] grid, int i, int j){
        // boundary conditions
        if(i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] == '0'){
            return;
        }
        
        grid[i][j] = '0';
        
        int[] dr = new int[4]{1, 0, -1, 0};
        int[] dc = new int[4]{0, -1, 0, 1};
        
        for(int d = 0; d < 4; d++){
            int newR = dr[d] + i;
            int newC = dc[d] + j;
            
            DFS(grid, newR, newC);
        }
    }
}