public class Solution {
    public int MaxIncreasingCells(int[][] mat) {
        int m  = mat.Length;
        int n = mat[0].Length;
        SortedDictionary<int, IList<int[]>> map = new SortedDictionary<int, IList<int[]>>();

        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(!map.ContainsKey(mat[i][j])){
                    map[mat[i][j]] = new List<int[]>();
                }

                map[mat[i][j]].Add(new int[]{i, j});
            }
        }

        int[][] dp = new int[m][];
        for(int i = 0; i < m; i++){
            dp[i] = new int[n];
        }

        int[] maxVals = new int[m + n];
        
        foreach(var kv in map){
            foreach(var rowCol in kv.Value){
                int i = rowCol[0];
                int j = rowCol[1];
                dp[i][j] = Math.Max(maxVals[i], maxVals[m + j]) + 1;
            }

            foreach(var rowCol in kv.Value){
                int i = rowCol[0];
                int j = rowCol[1];
                maxVals[i] = Math.Max(maxVals[i], dp[i][j]);
                maxVals[m + j] = Math.Max(maxVals[m + j], dp[i][j]);
            }
        }

        int maxCells = 0;
        foreach(var max in maxVals){
            maxCells = Math.Max(maxCells, max);
        }

        return maxCells;
    }
}

/*


1. Create a function named `MaxIncreasingCells` that takes a 2D integer array `mat` as input and returns an integer.

2. Retrieve the number of rows `m` and columns `n` from the input matrix `mat`.

3. Initialize a `SortedDictionary` named `map` to store a sorted list of cells with the same value. The keys in the dictionary will represent the unique values in the matrix, and the values will be lists of cell coordinates with that value.

4. Iterate through each cell in the matrix using two nested `for` loops. For each cell, check if its value exists as a key in the `map` dictionary. If it doesn't, add the key and initialize a list for that value.

5. Add the current cell's coordinates (i and j) as an integer array to the list associated with its value in the `map` dictionary.

6. Initialize a 2D array `dp` to store the maximum increasing sequence length that can end at each cell in the matrix. The dimensions of `dp` should match the dimensions of the input matrix.

7. Create an array `maxVals` to store the maximum increasing sequence length for each row and column. The size of this array should be `m + n`.

8. Iterate through the values in the `map` dictionary in ascending order.

9. For each value, iterate through the list of cell coordinates associated with that value in the `map`.

10. For each cell (i, j), update the `dp` array at position `dp[i][j]` with the maximum of the current maximum value in row `i` (stored in `maxVals[i]`) and the current maximum value in column `j` (stored in `maxVals[m + j]`) plus 1. This represents the maximum increasing sequence length ending at this cell.

11. After updating the `dp` array for all cells with the current value, update the `maxVals` array for row `i` and column `j` with the maximum value of `dp[i][j]`.

12. Once all values have been processed, iterate through the `maxVals` array to find the maximum value, which represents the maximum increasing sequence length in the entire matrix. Store this value in the `maxCells` variable.

13. Return the `maxCells` as the final result of the function.

*/