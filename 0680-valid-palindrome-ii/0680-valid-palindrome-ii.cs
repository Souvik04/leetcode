public class Solution {
    public bool ValidPalindrome(string s) {
        int i = 0;
        int j = s.Length - 1;

        while(i < j){
            if(s[i] != s[j]){
                return IsPalindrome(s, i, j - 1) || IsPalindrome(s, i + 1, j);
            }

            i++;
            j--;            
        }

        return true;
    }

    private bool IsPalindrome(string str, int i, int j){
        while(i < j){
            if(str[i] != str[j]){
                return false;
            }

            i++;
            j--;
        }

        return true;
    }
}

/*

Time complexity: O(n)
Time complexity: O(1)

*/