public class Codec {

    // Encodes a list of strings to a single string.
    public string encode(IList<string> strs) {
        StringBuilder sb = new StringBuilder();

        foreach(string str in strs){
            sb.Append(str.Replace("/", "//")).Append("/:");
        }

        return sb.ToString();
    }

    // Decodes a single string to a list of strings.
    public IList<string> decode(string s) {
        IList<string> output = new List<string>();
        StringBuilder current = new StringBuilder();
        
        for(int i = 0; i < s.Length; i++){
            // handle delimiter: /:
            if(i + 1 < s.Length && s[i] == '/' && s[i + 1] == ':'){
                output.Add(current.ToString());
                i++;
                current.Clear();
            }
            // handle slashes: / and //
            else if(i + 1 < s.Length && s[i] == '/' && s[i + 1] == '/'){
                current.Append('/');
                i++;
            }
            // handle remaining characters
            else{
                current.Append(s[i]);
            }
        }

        return output;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.decode(codec.encode(strs));