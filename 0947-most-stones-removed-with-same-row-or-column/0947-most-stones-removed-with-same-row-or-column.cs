public class Solution {
    Node[] nodes = null;

    public int RemoveStones(int[][] stones) {
        int n = stones.Length;
        int componentCount = n;
        nodes = new Node[n];

        for (int i = 0; i < n; i++) {
            nodes[i] = new Node(i);
        }

        for(int i = 0; i < n; i++) {
            for(int j = i + 1; j < n; j++){
                // unify if stones are in same row or col
                if(stones[i][0] == stones[j][0] || stones[i][1] == stones[j][1]){
                    if(Union(i, j)){
                        componentCount--;
                    }
                }
            }
        }

        return n - componentCount;
    }

    private int Find(int n) {
        if (nodes[n].parent != n) {
            nodes[n].parent = Find(nodes[n].parent);
        }
        return nodes[n].parent;
    }

    private bool Union(int x, int y) {
        int rootX = Find(x);
        int rootY = Find(y);

        if (rootX == rootY) {
            return false;
        }

        // Union by rank
        if (nodes[rootX].rank < nodes[rootY].rank) {
            nodes[rootX].parent = rootY;
        } 
        else if (nodes[rootX].rank > nodes[rootY].rank) {
            nodes[rootY].parent = rootX;
        } 
        else {
            nodes[rootY].parent = rootX;
            nodes[rootX].rank++;
        }

        return true;
    }
}

public class Node {
    public int parent { get; set; }
    public int rank { get; set; }

    public Node(int parent) {
        this.parent = parent;
        this.rank = 0;
    }
}
