public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        IList<IList<string>> output = new List<IList<string>>();
        Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

        foreach(string s in strs){
            int[] charCounts = new int[26];

            foreach(char c in s){
                charCounts[c - 'a']++;
            }

            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < 26; i++){
                sb.Append(charCounts[i]).Append('#');
            }

            string key = sb.ToString();

            if(!map.ContainsKey(key)){
                map.Add(key, new List<string>());
            }

            map[key].Add(s);
        }

        foreach(List<string> group in map.Values){
            output.Add(group);
        }

        return output;
    }
}

/*

Time complexity: O(n * w)
Space complexity: O(n)

*/