public class Solution {
    private class Node {
        public int rank;
        public int parent;
    }

    public int EarliestAcq(int[][] logs, int n) {
        Node[] nodes = new Node[n];
        Array.Sort(logs, (a, b) => a[0].CompareTo(b[0]));

        // create initial sets with parent as self and rank 0
        for (int i = 0; i < n; i++) {
            nodes[i] = new Node();
            nodes[i].parent = i;
        }

        // initially everyone in own groups, n
        int groups = n;
        int minTime = -1;

        foreach (var log in logs) {
            int timeStamp = log[0];
            int a = log[1];
            int b = log[2];

            // find parents of a and b and check if they are in same set
            int rootA = Find(a, nodes);
            int rootB = Find(b, nodes);

            // unify them if they are in different sets and reduce the group coutn by 1
            if (rootA != rootB) {
                Union(rootA, rootB, nodes);
                groups--;

                // if group count becomes 1 it indicates everyone is friends with each other now
                if (groups == 1) {
                    minTime = timeStamp;
                    break;
                }
            }
        }

        return (groups == 1) ? minTime : -1;
    }

    private int Find(int x, Node[] nodes) {
        if (nodes[x].parent != x) {
            nodes[x].parent = Find(nodes[x].parent, nodes);
        }
        return nodes[x].parent;
    }

    private void Union(int x, int y, Node[] nodes) {
        int rootX = Find(x, nodes);
        int rootY = Find(y, nodes);

        if (nodes[rootX].rank < nodes[rootY].rank) {
            nodes[rootX].parent = rootY;
        } else if (nodes[rootX].rank > nodes[rootY].rank) {
            nodes[rootY].parent = rootX;
        } else {
            nodes[rootY].parent = rootX;
            nodes[rootX].rank++;
        }
    }
}
