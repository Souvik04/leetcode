public class Solution {
    public bool IsEscapePossible(int[][] blocked, int[] source, int[] target) {
        int maxBlocks = blocked.Length;
        HashSet<long> visitedSource = new HashSet<long>();
        HashSet<long> visitedTarget = new HashSet<long>();

        foreach (var b in blocked) {
            if (Math.Abs(b[0] - source[0]) + Math.Abs(b[1] - source[1]) < 400)
                visitedSource.Add(((long)b[0] << 32) + b[1]);
            if (Math.Abs(b[0] - target[0]) + Math.Abs(b[1] - target[1]) < 400)
                visitedTarget.Add(((long)b[0] << 32) + b[1]);
        }

        return BFS(visitedSource, source, target, maxBlocks) && BFS(visitedTarget, target, source, maxBlocks);
    }

    private bool BFS(HashSet<long> visited, int[] source, int[] target, int maxBlocks) {
        int[][] dirs = { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };
        Queue<int[]> queue = new Queue<int[]>();
        queue.Enqueue(source);

        while (queue.Count > 0 && queue.Count <= maxBlocks) {
            Queue<int[]> newQueue = new Queue<int[]>();
            foreach (var p in queue) {
                foreach (var d in dirs) {
                    int x = p[0] + d[0];
                    int y = p[1] + d[1];
                    if (x < 0 || x > 999999 || y < 0 || y > 999999) continue;
                    if (x == target[0] && y == target[1]) return true;
                    long key = ((long)x << 32) + y;
                    if (visited.Add(key)) newQueue.Enqueue(new int[] { x, y });
                }
            }
            queue = newQueue;
        }

        return queue.Count > 0;
    }
}




/*
. # . . .
# . . . .
. . . . .
. . . . .
. . . . .

*/