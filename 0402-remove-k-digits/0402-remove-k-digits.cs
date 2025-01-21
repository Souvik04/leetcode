public class Solution {
    public string RemoveKdigits(string num, int k) {
        if((num.Length == 1 && k == 1) || k > num.Length){
            return "0";
        }

        if(k == 0){
            return num;
        }

        StringBuilder sb = new StringBuilder();
        Stack<int> stack = new Stack<int>();

        foreach(char c in num){
            int n = Convert.ToInt32(c);

            while(stack.Count > 0 && stack.Peek() > n && k > 0){
                stack.Pop();
                k--;
            }

            stack.Push(n);
        }

        if(k > 0 && stack.Count > 0){
            stack.Pop();
        }

        while(stack.Count > 0){
            sb.Append(Convert.ToChar(stack.Pop()));
        }

        while(sb.Length > 1 && sb[sb.Length - 1] == '0'){
            sb.Length--;
        }

        return sb.Length == 0 ? "0" : new string(sb.ToString().Reverse().ToArray());
    }
}

/*

1. initialize a stringbuilder for output
2. initialize a stack to maintain elements in increasing order (large elements at top)
3. iterate over the input num and pop from stack while k > 0 and stack.peek() > num[i]
4. push num[i] to stack
5. while stack is not empty, pop and append to output stringbuilder
6. remove trailing zeroes and reverse and convert to string and return

----

Time complexity: O(n)
Space complexity: O(n)

*/