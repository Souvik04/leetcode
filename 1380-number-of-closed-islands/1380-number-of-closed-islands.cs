public class Solution {
    public int ClosedIsland(int[][] grid) {
        int closedIslandCount = 0;

        for(int i = 0; i < grid.Length; i++){
            for(int j = 0; j < grid[0].Length; j++){
                if(grid[i][j] == 0 && (i == 0 || i == grid.Length - 1 || j == 0 || j == grid[0].Length - 1)){
                    DFS(grid, i, j);
                }
            }
        }

        for(int i = 0; i < grid.Length; i++){
            for(int j = 0; j < grid[0].Length; j++){
                if(grid[i][j] == 0){
                    DFS(grid, i, j);
                    closedIslandCount++;
                }
            }
        }

        return closedIslandCount;
    }

    private void DFS(int[][] grid, int r, int c){
        if(r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length || grid[r][c] == 1){
            return;
        }

        grid[r][c] = 1;

        int[] dr = new int[4]{1, 0, -1, 0};
        int[] dc = new int[4]{0, 1, 0, -1};

        for(int i = 0; i < 4; i++){
            DFS(grid, r + dr[i], c);
            DFS(grid, r, c + dc[i]);
        }
    }
}

/*

1. Create a class named `Solution` to implement the solution for finding the number of closed islands in a grid.

2. Define a method `ClosedIsland` that takes a 2D grid `grid` as input and returns an integer representing the number of closed islands.

3. Initialize an integer variable `closedIslandCount` to keep track of the number of closed islands.

4. Start two nested loops, one for iterating through rows (`i`) and the other for iterating through columns (`j`) in the grid.

5. For each grid cell at position `(i, j)`, check if it's a land cell (grid[i][j] == 0) and whether it's located on the boundary of the grid (i.e., it's on the first or last row or the first or last column). If both conditions are met, call the `DFS` (Depth-First Search) method to mark all connected land cells as visited. This is because land cells on the boundary are not considered part of a closed island.

6. After completing the first pass, iterate through the entire grid once more using two nested loops. This time, check for land cells (grid[i][j] == 0) and call the `DFS` method to mark all connected land cells as visited. Increment the `closedIslandCount` by 1 after completing the DFS traversal for each closed island.

7. Once both iterations are complete, the `closedIslandCount` will store the total number of closed islands.

8. Return the `closedIslandCount` as the result of the `ClosedIsland` function.

9. Define a private method named `DFS` that performs depth-first search to traverse and mark all connected land cells as visited.

10. In the `DFS` method, check if the current cell is out of bounds (i.e., it's outside the grid boundaries) or if it's a water cell (grid[r][c] == 1). If either condition is met, return from the DFS to stop the traversal.

11. Mark the current cell as visited by setting `grid[r][c]` to 1.

12. Define two arrays `dr` and `dc` to represent the four possible directions (up, right, down, and left) for moving to adjacent cells.

13. Use a loop to traverse in all four directions. In each direction, recursively call the `DFS` method for the adjacent cell by updating the row (`r`) and column (`c`) coordinates with `r + dr[i]` and `c + dc[i]`, respectively.

14. This recursive DFS traversal will continue until all connected land cells have been marked as visited.

*/