public class Solution {
    public int MinimumDistance(string word) {
        // Precompute distances
        Dictionary<(char, char), int> distances = new Dictionary<(char, char), int>();

        for (char a = 'A'; a <= 'Z'; a++) {
            for (char b = 'A'; b <= 'Z'; b++) {
                var posA = GetCoordinate(a);
                var posB = GetCoordinate(b);
                distances[(a, b)] = Math.Abs(posA.Item1 - posB.Item1) + Math.Abs(posA.Item2 - posB.Item2);
            }
        }

        // Memoization dictionary to store subproblem results
        Dictionary<(int, int, int), int> memo = new Dictionary<(int, int, int), int>();

        // Start recursion with no fingers placed (use -1 for unplaced fingers)
        return GetDistance(0, -1, -1, word, distances, memo);
    }

    private int GetDistance(int i, int leftFingerPos, int rightFingerPos, string word, 
                            Dictionary<(char, char), int> distances, 
                            Dictionary<(int, int, int), int> memo) {
        // Base case: if we've processed all characters
        if (i >= word.Length) {
            return 0;
        }

        // Check if result is already computed
        if (memo.ContainsKey((i, leftFingerPos, rightFingerPos))) {
            return memo[(i, leftFingerPos, rightFingerPos)];
        }

        char curChar = word[i];

        // Option 1: Move the left finger
        int leftFingerMove = (leftFingerPos == -1)
            ? 0 // If left finger is not placed, no cost to place it
            : distances[((char)(leftFingerPos + 'A'), curChar)];
        int option1 = leftFingerMove + GetDistance(i + 1, curChar - 'A', rightFingerPos, word, distances, memo);

        // Option 2: Move the right finger
        int rightFingerMove = (rightFingerPos == -1)
            ? 0 // If right finger is not placed, no cost to place it
            : distances[((char)(rightFingerPos + 'A'), curChar)];
        int option2 = rightFingerMove + GetDistance(i + 1, leftFingerPos, curChar - 'A', word, distances, memo);

        // Take the minimum of the two options
        int result = Math.Min(option1, option2);

        // Memoize the result
        memo[(i, leftFingerPos, rightFingerPos)] = result;
        return result;
    }

    private (int, int) GetCoordinate(char ch) {
        int n = 6;        
        int row = (ch - 'A') / n;
        int col = (ch - 'A') % n;
        return (row, col);
    }
}
