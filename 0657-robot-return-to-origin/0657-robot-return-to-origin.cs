public class Solution {
    public bool JudgeCircle(string moves) {
        int x = 0;
        int y = 0;
        
        foreach(char c in moves){
            if(c == 'U'){
                y++;
            }
            else if(c == 'D'){
                y--;
            }
            else if(c == 'R'){
                x++;
            }
            else if(c == 'L'){
                x--;
            }
        }
        
        return x == 0 && y == 0;
    }
}