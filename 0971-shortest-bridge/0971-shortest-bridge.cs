public class Solution {
    public int ShortestBridge(int[][] grid) {
        int rows = grid.Length;
        int cols = grid[0].Length;

        // Find the first island and mark it as visited.
        bool found = false;
        Queue<(int, int)> queue = new Queue<(int, int)>();
        HashSet<(int, int)> visited = new HashSet<(int, int)>();

        for (int i = 0; i < rows && !found; i++) {
            for (int j = 0; j < cols && !found; j++) {
                if (grid[i][j] == 1) {
                    DFS(grid, i, j, queue, visited);
                    found = true;
                }
            }
        }

        // Use BFS to expand the first island and find the shortest path to the second island.
        int[] dr = { -1, 1, 0, 0 };
        int[] dc = { 0, 0, -1, 1 };
        int steps = 0;

        while (queue.Count > 0) {
            int size = queue.Count;
            for (int i = 0; i < size; i++) {
                var (r, c) = queue.Dequeue();

                for (int d = 0; d < 4; d++) {
                    int nr = r + dr[d];
                    int nc = c + dc[d];

                    if (nr >= 0 && nr < rows && nc >= 0 && nc < cols && !visited.Contains((nr, nc))) {
                        if (grid[nr][nc] == 1) {
                            return steps;
                        } else if (grid[nr][nc] == 0) {
                            visited.Add((nr, nc));
                            queue.Enqueue((nr, nc));
                        }
                    }
                }
            }
            steps++;
        }

        return -1; // This should not happen in this problem.
    }

    private void DFS(int[][] grid, int r, int c, Queue<(int, int)> queue, HashSet<(int, int)> visited) {
        if (r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length || visited.Contains((r, c)) || grid[r][c] != 1) {
            return;
        }

        visited.Add((r, c));
        queue.Enqueue((r, c));

        int[] dr = { -1, 1, 0, 0 };
        int[] dc = { 0, 0, -1, 1 };

        for (int i = 0; i < 4; i++) {
            int nr = r + dr[i];
            int nc = c + dc[i];
            DFS(grid, nr, nc, queue, visited);
        }
    }
}

/*
1. Iterate through the grid and check if a cell is a land (1)
2. Initialize a queue for enqueing elements from visited set within DFS
3. Perform DFS on that cell and mark those cells as visited in a visited set (row, col)
4. Simultaneously enqueue all elements from visited set to the queue in DFS
5. Perform BFS (using directions array) on the elements after the grid iteration and DFS is completed
    - at each iteration within each layer (queue count) check if cel 1 or 0
    - if its 0 then mark the cell as visited and enqueue it in queue
    - increment a step count by 1 after each layer iteration, while queue not empty
    - if its 1, then return the step count as answer
7. At the end of BFS use that count and keep adding it into final result
*/