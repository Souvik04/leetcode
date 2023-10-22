public class Solution {
    public bool BackspaceCompare(string s, string t) {
        int sCount = 0;
        int tCount = 0;
        int i = s.Length - 1;
        int j = t.Length - 1;

        while(i >= 0 || j >= 0){
            while( i >= 0){
                if(s[i] == '#'){
                    sCount++;
                    i--;
                }
                else if(sCount > 0){
                    sCount--;
                    i--;
                }
                else{
                    break;
                }
            }

            while( j >= 0){
                if(t[j] == '#'){
                    tCount++;
                    j--;
                }
                else if(tCount > 0){
                    tCount--;
                    j--;
                }
                else{
                    break;
                }
            } 

            if(i >= 0 && j >= 0 && s[i] != t[j]){
                return false;
            }

            if((i >= 0) != (j >= 0)){
                return false;
            }

            i--;
            j--;
        }

        return true;
    }
}