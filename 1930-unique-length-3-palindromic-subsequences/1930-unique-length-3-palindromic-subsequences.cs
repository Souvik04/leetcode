public class Solution {
    public int CountPalindromicSubsequence(string s) {
        int count = 0;
        int n = s.Length;
        int[] firstOccurrences = new int[26];
        int[] lastOccurrences = new int[26];
        Array.Fill(firstOccurrences, int.MaxValue);

        for(int i = 0; i < n; i++){
            int index = s[i] - 'a';

            if (firstOccurrences[index] == int.MaxValue) {
                firstOccurrences[index] = i;
            }

            lastOccurrences[index] = i;
        }

        for(int i = 0; i < 26; i++){
            if(firstOccurrences[i] != int.MaxValue){
                HashSet<char> set = new HashSet<char>();

                for(int j = firstOccurrences[i] + 1; j < lastOccurrences[i]; j++){
                    set.Add(s[j]);
                }

                count += set.Count;
            }
        }

        return count;
    }
}