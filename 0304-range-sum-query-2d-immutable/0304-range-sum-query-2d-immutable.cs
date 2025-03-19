public class NumMatrix {
    private int[][] prefixMatrix;

    public NumMatrix(int[][] matrix) {
        int m = matrix.Length;
        int n = matrix[0].Length;
        prefixMatrix = new int[m + 1][];

        for (int i = 0; i <= m; i++) {
            prefixMatrix[i] = new int[n + 1];
        }

        for (int i = 1; i <= m; i++) {
            for (int j = 1; j <= n; j++) {
                prefixMatrix[i][j] = matrix[i - 1][j - 1] + prefixMatrix[i - 1][j] + prefixMatrix[i][j - 1] - prefixMatrix[i - 1][j - 1];
            }
        }
    }

    public int SumRegion(int row1, int col1, int row2, int col2) {
        return prefixMatrix[row2 + 1][col2 + 1] 
             - prefixMatrix[row1][col2 + 1] 
             - prefixMatrix[row2 + 1][col1] 
             + prefixMatrix[row1][col1];
    }
}


/**
 * Your NumMatrix object will be instantiated and called as such:
 * NumMatrix obj = new NumMatrix(matrix);
 * int param_1 = obj.SumRegion(row1,col1,row2,col2);
 */