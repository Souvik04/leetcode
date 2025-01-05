public class Solution {
    public int StrStr(string haystack, string needle) {
        int left = 0;
        int right = 0;

        while(left < haystack.Length && right < needle.Length){
            if(haystack[left] == needle[right]){
                right++;
            }
            else{
                right = 0;
            }

            left++;
        }

        return right == needle.Length ? left - right : -1;
    }
}