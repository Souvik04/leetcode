public class Solution {
    public bool IsValid(string s) {
        Stack<char> stack = new Stack<char>();
        Dictionary<char, char> map = new Dictionary<char, char>();        
        map[')'] = '(';
        map['}'] = '{';
        map[']'] = '[';
        
        foreach(char c in s){
            if(stack.Count > 0 && stack.Peek() == map.GetValueOrDefault(c, '.')){
                stack.Pop();
            }
            else{
                stack.Push(c);
            }
        }

        return stack.Count == 0;
    }
}