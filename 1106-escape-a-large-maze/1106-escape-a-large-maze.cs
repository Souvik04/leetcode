public class Solution{
	public bool IsEscapePossible(int[][] blocked, int[] source, int[] target){
		HashSet<long> visitedSource = new HashSet<long>();
		HashSet<long> visitedTarget = new HashSet<long>();
		
		foreach(var b in blocked){
			if(Math.Abs(b[0] - source[0]) + Math.Abs(b[1] - source[1]) < 400){
				visitedSource.Add(((long)b[0] << 32) + b[1]);
            }

	        if(Math.Abs(b[0] - target[0]) + Math.Abs(b[1] - target[1]) < 400){
		        visitedTarget.Add(((long)b[0] << 32) + b[1]);
            }
        }

        return (BFS(visitedSource, source, target, blocked.Length) && BFS(visitedTarget, target, source, blocked.Length));
    }

    private bool BFS(HashSet<long> visited, int[] source, int[] target, int maxBlocks){
        int[] dr = new int[]{1, 0, -1, 0};
        int[] dc = new int[]{0, 1, 0, -1};

        Queue<(int, int)> queue = new Queue<(int, int)>();
        queue.Enqueue((source[0], source[1]));

        while(queue.Count > 0 && queue.Count <= maxBlocks){
            int count = queue.Count;

            for(int i = 0; i < count; i++){
                var cur = queue.Dequeue();

                for(int d = 0; d < 4; d++){
                    int x = dr[d] + cur.Item1;
                    int y = dc[d] + cur.Item2;

                    if(x < 0 || x > 999999 || y < 0 || y > 999999){
                        continue;
                    }

                    if(x == target[0] && y == target[1]){
                        return true;
                    }

                    long key = ((long)x << 32) + y;
                    
                    if(visited.Add(key)){
                        queue.Enqueue((x, y));
                    }
                }
            }
        }

        return queue.Count > 0;
    }
}