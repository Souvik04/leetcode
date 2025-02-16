public class Solution {
    public bool IsPalindrome(string s) {
        int l = 0;
        int r = s.Length - 1;

        while(l < r){
            if(!Char.IsLetterOrDigit(s[l])){
                l++;
                continue;
            }

            if(!Char.IsLetterOrDigit(s[r])){
                r--;
                continue;
            }

            if(Char.ToLower(s[l]) != Char.ToLower(s[r])){
                return false;
            }

            l++;
            r--;
        }

        return true;
    }
}