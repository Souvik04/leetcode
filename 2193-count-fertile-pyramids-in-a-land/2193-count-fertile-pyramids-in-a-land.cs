public class Solution {
    public int CountPyramids(int[][] grid) {
        int[][] invertedGrid = InvertGrid(grid);
        return CountPyramidsHelper(grid) + CountPyramidsHelper(invertedGrid);
    }

    public int CountPyramidsHelper(int[][] grid) {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int totalPyramids = 0;

        for (int row = 1; row < rows; row++) {
            for (int col = 1; col < cols - 1; col++) {
                if (grid[row][col] > 0) {
                    int up = grid[row - 1][col];
                    int upLeft = grid[row - 1][col - 1];
                    int upRight = grid[row - 1][col + 1];

                    int minNeighbor = Math.Min(up, Math.Min(upLeft, upRight));
                    grid[row][col] = minNeighbor + 1;
                    totalPyramids += minNeighbor;
                }
            }
        }

        return totalPyramids;
    }

    public int[][] InvertGrid(int[][] grid) {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int[][] invertedGrid = new int[rows][];

        for (int row = 0; row < rows; row++) {
            invertedGrid[row] = new int[cols];

            for (int col = 0; col < cols; col++) {
                invertedGrid[row][col] = grid[rows - row - 1][col];
            }
        }

        return invertedGrid;
    }
}

/*

1. Define a function `CountPyramids` that takes a 2D grid as input.

2. Create an inverted grid by reversing the order of rows in the input grid. This allows us to count pyramids in both orientations.

3. Call a helper function `CountPyramidsHelper` for both the original and inverted grids and sum the results. This covers all possible pyramid orientations.

4. In the `CountPyramidsHelper` function:

   a. Initialize variables to store the number of rows, columns, and a counter for total pyramids.

   b. Loop through each cell in the grid, starting from the second row and second column.

   c. For each cell, check if it might be the top of a pyramid (cell value > 0).

   d. If it's the top of a potential pyramid:

      i. Examine the heights of its neighboring cells directly above, above-left, and above-right to determine the minimum height among them.

      ii. Update the height of the current cell to be one more than the minimum height, indicating the height of the pyramid it's part of.

      iii. Add the difference between the current height and the minimum height to the total pyramids count. This counts the layers of the pyramid.

5. Return the total pyramids count obtained in step 3.
*/