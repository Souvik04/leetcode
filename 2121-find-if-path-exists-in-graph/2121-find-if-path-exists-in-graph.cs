public class Solution {
    Node[] nodes;
    public bool ValidPath(int n, int[][] edges, int source, int destination) {
        nodes = new Node[n];

        for(int i = 0; i < n; i++){
            nodes[i] = new Node();
            nodes[i].parent = i;
        }

        foreach(var e in edges){
            Union(e[0], e[1]);
        }

        return Find(source) == Find(destination);
    }

    private bool Union(int x, int y){
        int rootX = Find(x);
        int rootY = Find(y);

        if(rootX == rootY){
            return false;
        }

        if(nodes[rootX].rank < nodes[rootY].rank){
            nodes[rootX].parent = rootY;
        }
        else if(nodes[rootX].rank > nodes[rootY].rank){
            nodes[rootY].parent = rootX;
        }
        else{
            nodes[rootX].parent = rootY;
            nodes[rootY].rank++;
        }

        return true;
    }

    private int Find(int n){
        if(nodes[n].parent != n){
            nodes[n].parent = Find(nodes[n].parent);
        }

        return nodes[n].parent;
    }

    public class Node{
        public int parent;
        public int rank;
    }
}