public class Solution {
    public IList<IList<int>> PacificAtlantic(int[][] heights) {
        IList<IList<int>> output = new List<IList<int>>();
        HashSet<(int, int)> pacific = new HashSet<(int, int)>();
        HashSet<(int, int)> atlantic = new HashSet<(int, int)>();
        int m = heights.Length;
        int n = heights[0].Length;

        for(int r = 0; r < m; r++){
            // left column: pacific
            DFS(heights, r, 0, pacific, heights[r][0]);

            // right column: atlantic
            DFS(heights, r, n - 1, atlantic, heights[r][n - 1]);
        }

        for(int c = 0; c < n; c++){
            // top row: pacific
            DFS(heights, 0, c, pacific, heights[0][c]);

            // bottom row: atlantic
            DFS(heights, m - 1, c, atlantic, heights[m - 1][c]);
        }
        
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(pacific.Contains((i, j)) && atlantic.Contains((i, j))){
                    output.Add(new List<int>(){i, j});
                }
            }
        }

        return output;
    }

    private void DFS(int[][] heights, int r, int c, HashSet<(int, int)> visited, int prev){
        if(r < 0 || r >= heights.Length || c < 0 || c >= heights[0].Length || visited.Contains((r, c)) || heights[r][c] < prev){
            return;
        }

        visited.Add((r, c));

        int[] dr = new int[]{1, 0, -1, 0};
        int[] dc = new int[]{0, -1, 0, 1};

        for(int d = 0; d < 4; d++){
            int newR = dr[d] + r;
            int newC = dc[d] + c;
            DFS(heights, newR, newC, visited, heights[r][c]);
        }
    }
}

/*

1. create two hashsets to store coordinates of pacific and atlantic oceans
2. iterate over the grid in 2  phases covering pacific and atlantic from the boundary cells
3. perform DFS and add the coordinates into respective hashsets for pacific and atlantic
4. iterate over the m * n and check if coordinate is present in both hashsets then add that to output
5. return output

----


*/