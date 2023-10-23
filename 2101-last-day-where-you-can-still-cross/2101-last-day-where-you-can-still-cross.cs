public class Solution {
    public int LatestDayToCross(int row, int col, int[][] cells) {
        int left = 1;
        int right = row * col;

        while (left < right) {
            int mid = left + (right - left) / 2; // Corrected the calculation of mid

            if (CanCross(row, col, cells, mid)) {
                left = mid + 1; // Adjusted left for binary search
            }
            else {
                right = mid; // Adjusted right for binary search
            }
        }

        return left - 1; // Returned left - 1 as the result
    }

    private bool CanCross(int row, int col, int[][] cells, int day) {
        int[][] grid = new int[row][];

        for (int i = 0; i < grid.Length; i++) {
            grid[i] = new int[col];
        }

        // Mark grid cells with water for each day
        for (int i = 0; i < day; i++) {
            grid[cells[i][0] - 1][cells[i][1] - 1] = 1;
        }

        // Enqueue all land cell positions into a queue
        Queue<(int, int)> queue = new Queue<(int, int)>();
        for (int i = 0; i < col; i++) {
            if (grid[0][i] == 0) {
                queue.Enqueue((0, i));
                grid[0][i] = -1;
            }
        }

        // Process elements from the queue
        int[][] directions = new int[4][] { new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };

        while (queue.Count > 0) {
            var cur = queue.Dequeue();

            if (cur.Item1 == row - 1) {
                return true;
            }

            foreach (var dir in directions) {
                int newRow = cur.Item1 + dir[0]; // Corrected the calculation of newRow
                int newCol = cur.Item2 + dir[1]; // Corrected the calculation of newCol

                if (newRow >= 0 && newRow < row && newCol >= 0 && newCol < col && grid[newRow][newCol] == 0) {
                    grid[newRow][newCol] = -1;
                    queue.Enqueue((newRow, newCol));
                }
            }
        }

        return false;
    }
}


/*

1. create a search space of 1 to n (r * c)
2. perform binary search on the search space by checking if we can traverse from top row t bottom row using a helper function- CanCross(int r, int c, int[][] cells, int day)
3. if we can cross then reduce search space by left = mid + 1, else reduce search space by right = mid
4. return left - 1 as the answer

helper function: CanCross(int row, int col, int[][] cells, int day)

1. create a grid row * col matrix of 0 values
2. fill it with 1 based on the cells[day]
    - for d 0 to day
        - grid[cells[i][0] - 1]grid[cells[i][1] - 1] = 1;
3. iterate over the top row and enqueue all land (0) cell positions in a queue
4. while queue is not empty
    - dequeue cur(r, c) and check if r == row - 1, return true (reached bottom)
    - else traverse in all 4 directions in BFS
    - mark each new unvisited land cell as -1 and enqueue the (newRow, newCol) into the queue
5. return false at the end

*/