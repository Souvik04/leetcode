public class Solution {
    Node[] nodes;
    public IList<int> NumIslands2(int m, int n, int[][] positions) {
        // Initialize nodes and result
        nodes = new Node[m * n];
        for (int i = 0; i < m * n; i++) {
            nodes[i] = new Node(i);
        }

        HashSet<int> landCells = new HashSet<int>();
        IList<int> result = new List<int>();
        int count = 0;

        // Directions for neighbors (up, down, left, right)
        int[] dr = new int[4]{1, 0, -1, 0};
        int[] dc = new int[4]{0, -1, 0, 1};

        foreach (int[] position in positions) {
            int r = position[0];
            int c = position[1];
            int index = r * n + c;

            // If cell is already land, skip
            if (landCells.Contains(index)) {
                result.Add(count);
                continue;
            }

            // Mark cell as land and increment count
            landCells.Add(index);
            count++;

            // Check and union with neighbors
            for(int d = 0; d < 4; d++){
                int newR = r + dr[d];
                int newC = c + dc[d];
                int neighborIndex = newR * n + newC;

                if (newR >= 0 && newR < m && newC >= 0 && newC < n && landCells.Contains(neighborIndex)) {
                    if (Union(index, neighborIndex)) {
                        count--; // Merge reduces the number of islands
                    }
                }
            }

            // Add the current count to the result
            result.Add(count);
        }

        return result;
    }

    private int Find(int x) {
        if (nodes[x].parent != x) {
            nodes[x].parent = Find(nodes[x].parent); // Path compression
        }
        return nodes[x].parent;
    }

    private bool Union(int x, int y) {
        int rootX = Find(x);
        int rootY = Find(y);

        if (rootX == rootY) {
            return false; // Already in the same set
        }

        // Union by rank
        if (nodes[rootX].rank > nodes[rootY].rank) {
            nodes[rootY].parent = rootX;
        } else if (nodes[rootX].rank < nodes[rootY].rank) {
            nodes[rootX].parent = rootY;
        } else {
            nodes[rootX].parent = rootY;
            nodes[rootY].rank++;
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
