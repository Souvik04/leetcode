public class Solution {
    public int OrangesRotting(int[][] grid) {
        int minMinutes = 0;
        int m = grid.Length;
        int n = grid[0].Length;
        int freshOranges = 0;
        Queue<(int x, int y)> queue = new Queue<(int, int)>();

        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(grid[i][j] == 2){
                    queue.Enqueue((i, j));
                }
                else if(grid[i][j] == 1){
                    freshOranges++;
                }
            }
        }

        if(freshOranges == 0){
            return 0;
        }

        int[] dr = new int[]{1, 0, -1, 0};
        int[] dc = new int[]{0, -1, 0, 1};

        while(queue.Count > 0){
            int count = queue.Count;
            minMinutes++;         

            for(int i = 0; i < count; i++){
                var cur = queue.Dequeue();                

                for(int d = 0; d < 4; d++){
                    int newX = dr[d] + cur.x;
                    int newY = dc[d] + cur.y;

                    // check conditions
                    if(newX >= 0 && newX < m && newY >= 0 && newY < n && grid[newX][newY] == 1){
                        grid[newX][newY] = 2;

                        // mark the orange as rotten
                        freshOranges--;
                        queue.Enqueue((newX, newY));
                    }
                }
            }
        }

        return freshOranges == 0 ? minMinutes - 1 : -1;
    }
}

/*
        
    1. iterate over the matrix to get initial count of fresh oranges
    2. pick the rotten oranges and enqueue the coordinates into queue
    3. Dequeue from queue and perform BFS and increment the minute counter
    4. return the minute if no fresh oranges left or return -1

    Time complexity: O(m * n)
    Space complexity: O(m * n)

*/