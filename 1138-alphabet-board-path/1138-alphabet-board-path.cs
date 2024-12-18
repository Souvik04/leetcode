public class Solution {
    public string AlphabetBoardPath(string target) {
        StringBuilder output = new StringBuilder();
        int currentRow = 0, currentCol = 0;

        foreach (char c in target) {
            int targetRow = (c - 'a') / 5;
            int targetCol = (c - 'a') % 5;

            // Use the utility function to calculate the path
            string path = GetTargetPath(currentRow, currentCol, targetRow, targetCol);
            output.Append(path);

            // Update currentRow and currentCol
            currentRow = targetRow;
            currentCol = targetCol;
        }

        return output.ToString();
    }

    private string GetTargetPath(int currentRow, int currentCol, int targetRow, int targetCol) {
        StringBuilder sb = new StringBuilder();

        // Handle vertical movement first for 'z' to avoid invalid positions
        if (targetRow == 5) {
            Move(sb, currentCol, targetCol, 'L', 'R');
            Move(sb, currentRow, targetRow, 'U', 'D');
        } else {
            Move(sb, currentRow, targetRow, 'U', 'D');
            Move(sb, currentCol, targetCol, 'L', 'R');
        }

        // Select the character
        sb.Append('!');
        return sb.ToString();
    }

    private void Move(StringBuilder sb, int current, int target, char negative, char positive) {
        while (current > target) {
            sb.Append(negative);
            current--;
        }
        while (current < target) {
            sb.Append(positive);
            current++;
        }
    }
}

/*

Time complexity: O(n)
Space complexity: O(n)

*/