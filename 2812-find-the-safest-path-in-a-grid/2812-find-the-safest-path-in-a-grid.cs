public class Solution {
    public int MaximumSafenessFactor(IList<IList<int>> grid) {
        int n = grid.Count;
        
        // Step 1: Multi-source BFS to calculate minimum distance from any thief
        Queue<(int x, int y)> thieves = new Queue<(int, int)>();

        // Initialize grid and enqueue all thieves' positions
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 1) {
                    thieves.Enqueue((i, j)); // Enqueue thieves
                    grid[i][j] = 0; // Thieves are at distance 0
                } else {
                    grid[i][j] = int.MaxValue; // Non-thieves start with max distance
                }
            }
        }

        // Directions for BFS (Up, Right, Down, Left)
        int[] dr = { -1, 0, 1, 0 };
        int[] dc = { 0, 1, 0, -1 };

        // Perform BFS to compute distances from nearest thief
        while (thieves.Count > 0) {
            var (x, y) = thieves.Dequeue();
            for (int i = 0; i < 4; i++) {
                int newX = x + dr[i], newY = y + dc[i];
                if (newX >= 0 && newX < n && newY >= 0 && newY < n && grid[newX][newY] == int.MaxValue) {
                    grid[newX][newY] = grid[x][y] + 1;
                    thieves.Enqueue((newX, newY));
                }
            }
        }

        // Step 2: Dijkstra's algorithm to compute the maximum safeness factor
        int[][] safeness = new int[n][];
        for (int i = 0; i < n; i++) {
            safeness[i] = new int[n];
            Array.Fill(safeness[i], -1); // Initialize safeness factor with -1 (unvisited)
        }
        safeness[0][0] = grid[0][0]; // Start with the top-left cell

        // Max-heap priority queue for Dijkstra's algorithm (max safeness factor)
        var maxHeap = new PriorityQueue<(int x, int y), int>();
        maxHeap.Enqueue((0, 0), -safeness[0][0]); // Enqueue the top-left corner

        // Directions for propagating the safeness factor
        while (maxHeap.Count > 0) {
            var (curX, curY) = maxHeap.Dequeue();
            int curSafeFactor = safeness[curX][curY];

            // If we reached the bottom-right corner, return its safeness factor
            if (curX == n - 1 && curY == n - 1) return curSafeFactor;

            for (int i = 0; i < 4; i++) {
                int newX = curX + dr[i], newY = curY + dc[i];
                if (newX >= 0 && newX < n && newY >= 0 && newY < n) {
                    int newSafeFactor = Math.Min(curSafeFactor, grid[newX][newY]);
                    if (newSafeFactor > safeness[newX][newY]) {
                        safeness[newX][newY] = newSafeFactor;
                        maxHeap.Enqueue((newX, newY), -newSafeFactor); // Enqueue with negative safeness factor
                    }
                }
            }
        }

        return -1; // In case we can't reach the bottom-right corner (which should not happen in valid input)
    }
}
