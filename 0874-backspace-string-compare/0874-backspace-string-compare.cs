public class Solution {
    public bool BackspaceCompare(string s, string t) {
        string sNew = GetString(s);
        string tNew= GetString(t);

        if(sNew.Length == tNew.Length){
            return sNew.Equals(tNew);
        }
        
        return false;
    }

    private string GetString(string str){
        Stack<char> stack = new Stack<char>();
        for(int i = 0; i < str.Length; i++){
            if(str[i] != '#'){
                stack.Push(str[i]);
            }
            else{
                if(stack.Count > 0){
                    stack.Pop();
                }
            }
        }        

        StringBuilder sb = new StringBuilder();

        while(stack.Count > 0){
            sb.Append(stack.Pop());
        }

        return sb.ToString();        
    }
}