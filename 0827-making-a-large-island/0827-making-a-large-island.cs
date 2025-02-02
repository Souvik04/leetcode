// Approach 1: DFS
public class Solution {
    public int LargestIsland(int[][] grid) {
        int maxIsland = 0;
        int m = grid.Length;
        int n = grid[0].Length;
        Dictionary<int, int> islandSizes = new Dictionary<int, int>();
        int islandId = 2;

        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(grid[i][j] == 1){
                    int currentIslandSize = GetIslandSize(grid, i, j, islandId);
                    islandSizes.Add(islandId, currentIslandSize);
                    islandId++;
                }
            }
        }

        if(islandSizes.Count == 0){
            return 1;
        }

        if(islandSizes.Count == 1){
            islandId--;

            return islandSizes[islandId] == m * n ? islandSizes[islandId] : islandSizes[islandId] + 1;
        }

        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(grid[i][j] == 0){
                    int currentIslandSize = 1;
                    HashSet<int> islandIds = new HashSet<int>();

                    // check right
                    if(j + 1 < n && grid[i][j + 1] > 1){
                        islandIds.Add(grid[i][j + 1]);
                    }

                    // check down
                    if(i + 1 < m && grid[i + 1][j] > 1){
                        islandIds.Add(grid[i + 1][j]);
                    }

                    // check left
                    if(j - 1 >= 0 && grid[i][j - 1] > 1){
                        islandIds.Add(grid[i][j - 1]);
                    }
                    
                    // check up
                    if(i - 1 >= 0 && grid[i - 1][j] > 1){
                        islandIds.Add(grid[i - 1][j]);
                    }

                    foreach(int id in islandIds){
                        currentIslandSize += islandSizes[id];
                    }
                    
                    maxIsland = Math.Max(maxIsland, currentIslandSize);
                }
            }
        }

        return maxIsland;
    }

    private int GetIslandSize(int[][] grid, int r, int c, int islandId){
        if(r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length || grid[r][c] != 1){
            return 0;
        }

        grid[r][c] = islandId;

        return 1 + GetIslandSize(grid, r + 1, c, islandId) +
                GetIslandSize(grid, r, c + 1, islandId) +
                GetIslandSize(grid, r - 1, c, islandId) +
                GetIslandSize(grid, r, c - 1, islandId);
    }
}

/*

1. explore the grid and calculate size of every islands and add them in a map with some id
2. handle edge cases
    - if map count is 0 return 1
    - if map count == 1, id--
        - if map[id] == grid.length * grid[0].length return grid.length * grid[0].length
        - else return map[id] + 1
3. explore the grid again and calculate the max size based on previously stored island sizes
    - look for cells with 0 (land)
    - explore all directions and check adjacent cells are > 1 (some island)
    - add the neighbouring cell (island id) value in a set
    - after exploring all neighbours, iterate over the set and calculate currentMax from the map
    based on the ids added
    - set maxIsland = max(maxIsland, currentMax)
4. return maxIsland

----

Time complexity: O(m * n)
Space complexity: O(m * n)

*/