public class Solution {
    public int LengthOfLongestSubstring(string s) {
        int longest = 0;
        Dictionary<char, int> map = new Dictionary<char, int>();
        int left = 0;

        for(int right = 0; right < s.Length; right++){
            if(map.ContainsKey(s[right])){
                left = Math.Max(left, map[s[right]]);
            }

            longest = Math.Max(longest, right - left + 1);
            map[s[right]] = right + 1;
        }

        return longest;
    }
}