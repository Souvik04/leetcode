public class Solution {
    public int[] ShortestDistanceColor(int[] colors, int[][] queries) {
        int n = colors.Length;
        int maxColor = 3; // Given: colors are 1, 2, and 3.
        int[] result = new int[queries.Length];

        // Initialize distances as a 2D jagged array
        int[][] distances = new int[n][];
        for (int i = 0; i < n; i++) {
            distances[i] = new int[maxColor + 1];
            Array.Fill(distances[i], int.MaxValue); // Set all distances to unreachable
        }

        // Compute distances (Left-to-Right)
        int[] lastSeen = new int[maxColor + 1]; // Tracks last seen index of each color
        Array.Fill(lastSeen, -1); // Initialize to -1 (not seen)

        for (int i = 0; i < n; i++) {
            int color = colors[i];
            lastSeen[color] = i; // Update last seen index for this color
            for (int c = 1; c <= maxColor; c++) {
                if (lastSeen[c] != -1) {
                    distances[i][c] = i - lastSeen[c]; // Distance from left
                }
            }
        }

        // Compute distances (Right-to-Left)
        Array.Fill(lastSeen, -1); // Reset last seen
        for (int i = n - 1; i >= 0; i--) {
            int color = colors[i];
            lastSeen[color] = i; // Update last seen index for this color
            for (int c = 1; c <= maxColor; c++) {
                if (lastSeen[c] != -1) {
                    distances[i][c] = Math.Min(distances[i][c], lastSeen[c] - i); // Distance from right
                }
            }
        }

        // Resolve queries using precomputed distances
        for (int q = 0; q < queries.Length; q++) {
            int index = queries[q][0];
            int targetColor = queries[q][1];
            result[q] = distances[index][targetColor] == int.MaxValue ? -1 : distances[index][targetColor];
        }

        return result;
    }

}