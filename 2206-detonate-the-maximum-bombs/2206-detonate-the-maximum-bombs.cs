public class Solution {
    public int MaximumDetonation(int[][] bombs) {
        int maxDetonation = 0;
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        HashSet<int> visited = new HashSet<int>();

        for(int i = 0; i < bombs.Length; i++){
            for(int j = 0; j < bombs.Length; j++){
                if(i == j){
                    continue;
                }

                int x1 = bombs[i][0];
                int y1 = bombs[i][1];
                int x2 = bombs[j][0];
                int y2 = bombs[j][1];
                int r = bombs[i][2];

                double eucDist = (double)(x1 - x2) * (x1 - x2) + (double)(y1 - y2) * (y1 - y2);

                if(eucDist <= (double)r * r){
                    if(!graph.ContainsKey(i)){
                        graph.Add(i, new List<int>());
                    }

                    graph[i].Add(j);
                }
            }
        }

        for(int i = 0; i < bombs.Length; i++){
            int count = DFS(graph, i, new HashSet<int>());
            maxDetonation = Math.Max(count, maxDetonation);
        }

        return maxDetonation;
    }

    private int DFS(Dictionary<int, List<int>> graph, int source, HashSet<int> visited){
        int count = 1;
        visited.Add(source);

        if(graph.ContainsKey(source)){
            foreach(int n in graph[source]){
                if(!visited.Contains(n)){
                    count += DFS(graph, n, visited);
                }
            }
        }

        return count;
    }
}

/*


1. Create a function named `MaximumDetonation` that takes a 2D array `bombs` as input.

2. Initialize an integer variable `maxDetonation` to 0, a dictionary `graph` to represent the graph, and a set `visited` to keep track of visited nodes.

3. Iterate through each pair of bomb coordinates in the `bombs` array using two nested `for` loops.

4. For each pair of bombs (i, j), calculate the Euclidean distance `eucDist` between their coordinates and the radius `r` of the first bomb.

5. If `eucDist` is less than or equal to the square of `r`, create an edge in the `graph` by adding `j` to the list of neighbors of `i` if `i` is not already in the graph.

6. After processing all bomb pairs, you will have constructed a graph where each bomb is a node, and there is an edge between two bombs if they can detonate each other.

7. Initialize a variable `maxDetonation` to 0 to keep track of the maximum detonation count.

8. Iterate through each bomb `i` in the `bombs` array.

9. Call the `DFS` function with the `graph`, current bomb `i`, and an empty `visited` set.

10. The `DFS` function is a depth-first search (DFS) that starts from a source node and explores connected nodes. It returns the count of nodes visited in the current connected component.

11. In the `DFS` function, add the current source node to the `visited` set and initialize a `count` variable to 1.

12. Check if the current source node has neighbors in the `graph`.

13. If there are neighbors, iterate through them and recursively call the `DFS` function for unvisited neighbors. Update the `count` with the result of the recursive call.

14. Return the `count` from the `DFS` function.

15. In the `MaximumDetonation` function, update `maxDetonation` by taking the maximum of the current `count` and the previous `maxDetonation` for each bomb `i`.

16. After processing all bombs, return the final `maxDetonation` value as the maximum detonation count.


*/