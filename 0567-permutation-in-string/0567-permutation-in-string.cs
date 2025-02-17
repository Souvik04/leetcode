public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        if(s1.Length > s2.Length){
            return false;
        }

        int[] s1Freq = new int[26];
        int[] s2Freq = new int[26];
        int left = 0;
        int right = 0;

        for(int i = 0; i < s1.Length; i++){
            s1Freq[s1[i] - 'a']++;
        }

        while(right < s2.Length){
            s2Freq[s2[right] - 'a']++;

            if(right - left + 1 == s1.Length){
                if(CompareMap(s1Freq, s2Freq)){
                    return true;
                }
            }
            
            if(right - left + 1 < s1.Length){
                right++;
            }
            else{
                s2Freq[s2[left] - 'a']--;
                left++;
                right++;
            }
        }

        return false;
    }

    private bool CompareMap(int[] s1Freq, int[] s2Freq){
        for(int i = 0; i < 26; i++){
            if(s1Freq[i] != s2Freq[i]){
                return false;
            }
        }

        return true;        
    }
}

/*

1. initialize 2 maps to store frequencies of s1 and s2
2. iterate over s1 and store its frequencies
3. initialize 2 pointers left = 0 and right = 0
4. iterate over s2 while right < s2.Length
5. update frequency of s2 in map
6. check if window (right - left + 1 == s1.length) then compare both the maps and return true if all match
7. if window < s1.length, increment right
8. else decrement left: s2freq[s2[left]]--, increment right and left
8. return false at end

Time complexity: O(n * m)
Space complexity: O(n + m)

*/