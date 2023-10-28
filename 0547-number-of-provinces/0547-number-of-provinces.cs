public class Solution {
    public int FindCircleNum(int[][] isConnected) {
        int n = isConnected.Length;
        Node[] nodes = new Node[n];
        int provinces = n;

        for (int i = 0; i < n; i++) {
            nodes[i] = new Node(i);
        }

        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                if (isConnected[i][j] == 1) {
                    if (Union(nodes[i], nodes[j])) {
                        provinces--;
                    }
                }
            }
        }

        return provinces;
    }

    private bool Union(Node x, Node y) {
        Node rootX = Find(x);
        Node rootY = Find(y);

        if (rootX == rootY) {
            return false;
        }

        if (rootX.rank > rootY.rank) {
            rootY.parent = rootX;
        } else if (rootX.rank < rootY.rank) {
            rootX.parent = rootY;
        } else {
            rootY.parent = rootX;
            rootX.rank++;
        }

        return true;
    }

    private Node Find(Node node) {
        if (node != node.parent) {
            node.parent = Find(node.parent); // Path compression.
        }
        return node.parent;
    }

    private class Node {
        public int val;
        public Node parent;
        public int rank;

        public Node(int val) {
            this.val = val;
            this.parent = this;
            this.rank = 0;
        }
    }
}


/*

1 1 0
1 1 0
0 0 1

1 0 0 
0 1 0
0 0 1

1 0 0 0 0 
0 1 0 0 0
0 0 1 0 0
0 0 0 1 0
0 0 0 0 1

*/