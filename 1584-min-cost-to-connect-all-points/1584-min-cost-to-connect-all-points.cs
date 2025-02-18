public class Solution {
    Node[] nodes = null;
    public int MinCostConnectPoints(int[][] points) {
        int minCost = 0;
        int n = points.Length;
        List<(int p1, int p2, int w)> pointsWithWeights = new List<(int, int, int)>();
        nodes = new Node[n];

        // calculate weights (distance) between each points and add to list
        for(int i = 0; i < n; i++){
            for(int j = i + 1; j < n; j++){
                // manhattan distance
                int dist = Math.Abs(points[i][0] - points[j][0]) + Math.Abs(points[i][1] - points[j][1]);
                pointsWithWeights.Add((i, j, dist));
            }
        }

        // sort points by weight (distance)
        pointsWithWeights.Sort((a, b) => a.w.CompareTo(b.w));

        // initialize Union-Find
        for(int i = 0; i < n; i++){
            nodes[i] = new Node(i);
        }

        // apply Kruskal's algorithm to get min cost
        foreach(var point in pointsWithWeights){
            if(Find(point.p1) != Find(point.p2)){
                // add weight for each points covered
                minCost += point.w;
                Union(point.p1, point.p2);
            }
        }

        return minCost;
    }

    private int Find(int n){
        if(nodes[n].parent != n){
            nodes[n].parent = Find(nodes[n].parent);
        }

        return nodes[n].parent;
    }

    private bool Union(int x, int y){
        int rootX = Find(x);
        int rootY = Find(y);

        if(rootX == rootY){
            return true;
        }
        else{
            if(nodes[rootX].rank > nodes[rootY].rank){
                nodes[rootY].parent = rootX;
            }
            else if(nodes[rootX].parent < nodes[rootY].rank){
                nodes[rootX].parent = rootY;
            }
            else{
                nodes[rootX].parent = rootY;
                nodes[rootY].rank++;
            }

            return false;
        }
    }
}

public class Node{
    public int parent {get; set;}
    public int rank {get; set;}

    public Node(int parent){
        this.parent = parent;
        this.rank = 0;
    }
}

/*

1. create a List<(int x, int y), int w> to store all points and weights
2. iterate over all points in a nested loop and calculate the manhattan distance between each points and add them in the list
3. sort the list by w (weight)
4. initalize Union-Find datastructure and perform Union Find for each points in the sorted list
5. apply Kruskal's algorithm to get MST (Minimum Spanning Tree)
6. Sum the MST to get the min cost

Time complexity: O(n^2 * logn)
Space complexity: O(n^2)

*/