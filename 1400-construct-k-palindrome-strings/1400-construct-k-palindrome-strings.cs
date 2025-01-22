public class Solution {
    public bool CanConstruct(string s, int k) {
        if(s.Length < k){
            return false;
        }

        if(s.Length == k){
            return true;
        }
        
        Dictionary<char, int> map = new Dictionary<char, int>();
        int oddCount = 0;
        int evenCount = 0;

        foreach(char c in s){
            if(!map.ContainsKey(c)){
                map[c] = 0;
            }

            map[c]++;
        }

        foreach(var kv in map){
            if(kv.Value % 2 == 0){
                evenCount++;
            }
            else{
                oddCount++;
            }
        }

        return oddCount > 1 ? false : evenCount % 2 == 0;
    }
}