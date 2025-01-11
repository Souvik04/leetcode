public class TicTacToe {
    int n;
    int[] rows;
    int[] cols;
    int diagonal;
    int antiDiagonal;
    public TicTacToe(int n) {
        this.n = n;
        this.rows = new int[n];
        this.cols = new int[n];
    }
    
    public int Move(int row, int col, int player) {
        int curPlayer = player == 1 ? 1 : -1;
        rows[row] += curPlayer;
        cols[col] += curPlayer;

        if(row == col){
            diagonal += curPlayer;
        }

        if(col == (n - row - 1)){
            antiDiagonal += curPlayer;
        }

        if(Math.Abs(rows[row]) == n ||
            Math.Abs(cols[col]) == n ||
            diagonal == n ||
            antiDiagonal == n){
                return player;
            }

        return 0;
    }
}

/**
 * Your TicTacToe object will be instantiated and called as such:
 * TicTacToe obj = new TicTacToe(n);
 * int param_1 = obj.Move(row,col,player);
 */