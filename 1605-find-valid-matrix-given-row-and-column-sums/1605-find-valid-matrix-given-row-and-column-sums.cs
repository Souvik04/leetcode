public class Solution {
    public int[][] RestoreMatrix(int[] rowSum, int[] colSum) {
        int m = rowSum.Length;
        int n = colSum.Length;
        int[][] matrix = new int[m][];
        
        for(int i = 0; i < m; i++){
            matrix[i] = new int[n];
        }
        
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                matrix[i][j] = Math.Min(rowSum[i], colSum[j]);
                rowSum[i] -= matrix[i][j];
                colSum[j] -= matrix[i][j];
            }
        }
        
        return matrix;
    }
}
