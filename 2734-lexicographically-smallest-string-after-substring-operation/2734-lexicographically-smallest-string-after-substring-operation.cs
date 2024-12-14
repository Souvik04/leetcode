public class Solution {
    public string SmallestString(string s) {
        char[] chars = s.ToCharArray();
        bool changed = false;

        for(int i = 0; i < chars.Length; i++){
            if(chars[i] != 'a'){
                while(i < chars.Length && chars[i] != 'a'){
                    chars[i] = (char)(chars[i] - 1);
                    i++;
                    changed = true;
                }

                break;
            }            
        }

        if (!changed) {
            chars[chars.Length - 1] = 'z';
        }

        return new string(chars);
    }
}