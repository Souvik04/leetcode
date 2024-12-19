public class Solution {
    public IList<IList<string>> GroupStrings(string[] strings) {
        IList<IList<string>> output = new List<IList<string>>();
        Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
        
        foreach(string s in strings){
            char startChar = s[0];
            StringBuilder key = new StringBuilder();            
            
            for(int i = 1; i < s.Length; i++){
                int diff = s[i] - s[i - 1];
                
                if(diff < 0){
                    diff += 26;
                }
                
                key.Append(diff).Append(',');
            }
            
            string strKey = key.ToString();
            
            if(!map.ContainsKey(strKey)){
                map[strKey] = new List<string>();
            }
            
            map[strKey].Add(s);
        }
        
        foreach(var kv in map){
            output.Add(kv.Value);
        }
        
        return output;
    }
}

/*

0 % 26 = 0
1 % 26 = 1

acg
bdh



*/