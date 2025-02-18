public class Solution {
    public bool CheckValidString(string s) {
        int open = 0;
        int close = 0;

        // first pass: iterate start to end
        for(int i = 0; i < s.Length; i++){
            if(s[i] == '(' || s[i] == '*'){
                open++;
            }
            else if(s[i] == ')'){
                close++;
            }
        }

        if(close > open){
            return false;
        }

        open = 0;
        close = 0;

        for(int i = s.Length - 1; i >= 0; i--){
            if(s[i] == ')' || s[i] == '*'){
                close++;
            }
            else{
                open++;
            }
        }

        if(open > close){
            return false;
        }

        return true;
    }
}

/*

1. initialize 2 integer variables- open and close
2. in first pass iterate over s from start to end and count open and close
    - treat * as open
    - if close > open, return false
3. reset counts 
4. in second pass iterate over s from end to start and count open and close
    - treat * as close
    - if open > close, return false
5. return true at end

----

Time complexity: O(n)
Space complexity: O(1)

*/