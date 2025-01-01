public class Solution {
    public IList<IList<string>> SolveNQueens(int n) {
        char[][] board = new char[n][];
        IList<IList<string>> output = new List<IList<string>>();
        InitBoard(board, n);
        Backtrack(n, board, output, new HashSet<int>(), new HashSet<int>(), new HashSet<int>(), 0);

        return output;
    }

    private void Backtrack(int n, char[][] board, IList<IList<string>> output, HashSet<int> col, HashSet<int> posDiag, HashSet<int> negDiag, int r){
        // if all rows processed, add board to output
        if(r == n){
            List<string> rowsToAdd = new List<string>();
            
            foreach(char[] row in board){
                rowsToAdd.Add(new string(row));
            }

            output.Add(rowsToAdd);
        }

        // iterate over each column and perform Backtrack
        for(int c = 0; c < n; c++){
            if(col.Contains(c) || posDiag.Contains(r + c) || negDiag.Contains(r - c)){
                continue;
            }

            col.Add(c);
            posDiag.Add(r + c);
            negDiag.Add(r - c);
            board[r][c] = 'Q';

            Backtrack(n, board, output, col, posDiag, negDiag, r + 1);

            col.Remove(c);
            posDiag.Remove(r + c);
            negDiag.Remove(r - c);
            board[r][c] = '.';
        }
    }

    private void InitBoard(char[][] board, int n){
        for(int i = 0; i < n; i++){
            board[i] = new char[n];

            for(int j = 0; j < n; j++){
                board[i][j] = '.';
            }
        }
    }
}