public class Solution {
    public string[] Expand(string s) {
        List<string> output = new List<string>();
        List<List<string>> segments = ParseInput(s);
        GenerateCombinations(segments, "", 0, output);
        output.Sort();
        
        return output.ToArray();
    }
    
    private List<List<string>> ParseInput(string s){
        List<List<string>> segments = new List<List<string>>();
        int i = 0;
        
        while(i < s.Length){
            if(s[i] == '{'){
                int j = i + 1;
                
                while(j < s.Length && s[j] != '}'){
                    j++;
                }
                
                string group = s.Substring(i + 1, j - i - 1);
                segments.Add(new List<string>(group.Split(',')));
                
                // move i
                i = j + 1;
            }
            else{
                int j = i;
                
                while(j < s.Length && s[j] != '{'){
                    j++;
                }
                
                string group = s.Substring(i, j - i);
                segments.Add(new List<string>(){group});
                
                // move i
                i = j;
            }
        }
        
        return segments;
    }
    
    private void GenerateCombinations(List<List<string>> segments, string current, int index, List<string> result){
        if(index == segments.Count){
            result.Add(current);
            return;
        }
        
        foreach(string option in segments[index]){
            GenerateCombinations(segments, current + option, index + 1, result);
        }
    }
}