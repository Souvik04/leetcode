public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        int minDelay = 0;
        int[] distances = new int[n + 1];
        Array.Fill(distances, int.MaxValue);
        PriorityQueue<(int targetNode, int weight), int> minHeap = new PriorityQueue<(int, int), int>();
        List<(int targetNode, int weight)>[] graph = new List<(int, int)>[n + 1];

        for(int i = 0; i <= n; i++){
            graph[i] = new List<(int targetNode, int weight)>();
        }

        foreach(int[] time in times){
            graph[time[0]].Add((time[1], time[2]));
        }

        distances[k] = 0;
        minHeap.Enqueue((k, 0), 0);

        while(minHeap.Count > 0){
            var cur = minHeap.Dequeue();

            foreach(var neighbour in graph[cur.targetNode]){
                // du + w < dv, dv = du + w
                int newWeight = cur.weight + neighbour.weight;

                if(newWeight < distances[neighbour.targetNode]){
                    distances[neighbour.targetNode] = newWeight;
                    minHeap.Enqueue((neighbour.targetNode, newWeight), newWeight);
                }
            }
        }

        for(int i = 1; i <= n; i++){
            if(distances[i] == int.MaxValue){
                return -1;
            }

            minDelay = Math.Max(minDelay, distances[i]);
        }

        return minDelay;
    }
}

/*

1. create graph from the input times
2. initialize distances to infinity
3. initialize a PriorityQueue<(int, int), int> (min heap) to store (targetNode, weight) sorted by weight
4. perform Dijkstra's algorithm and update the distances
5. check: du + w < dv, then update dv
6. after that iterate over distances and update output = max(distances)
7. if any distances[i] is infinity return -1 else return output 

*/