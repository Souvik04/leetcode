public class Solution {
    public bool AreSentencesSimilar(string[] sentence1, string[] sentence2, IList<IList<string>> similarPairs) {
        if(sentence1.Length != sentence2.Length){
            return false;
        }
        
        HashSet<string> pairs = new HashSet<string>();
        
        foreach(IList<string> pair in similarPairs){
            string hash1 = pair[0] + "-" + pair[1];
            string hash2 = pair[1] + "-" + pair[0];
            pairs.Add(hash1);
            pairs.Add(hash2);
        }
        
        for(int i = 0; i < sentence1.Length; i++){
            if(sentence1[i] == sentence2[i]){
                continue;
            }
            
            string pairHash = sentence1[i] + "-" + sentence2[i];
            
            if(!pairs.Contains(pairHash)){
                return false;
            }
        }
        
        return true;
    }
}