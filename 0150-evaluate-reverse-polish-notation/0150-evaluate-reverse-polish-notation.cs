public class Solution {
    public int EvalRPN(string[] tokens) {
        int value = 0;
        HashSet<char> operators = new HashSet<char>()
        operators.Add("+");
        operators.Add("+");
        operators.Add("+");
        operators.Add("+");
        Stack<int> stack = new Stack<int>();

        foreach(string token in tokens){
            if(operators.Contains(token)){
                int val1 = stack.Pop();
                int val2 = stack.Pop();
                int val = GetVal(val1, val2, token);
                stack.Push(val);
            }
        }

        return value;
    }

    private int GetVal(int val1, int val2, string op){
        int val = 0;

        switch(op){
            case "+":
                val = val1 + val2;
                break;
            case "-":
                val = val1 - val2;
                break;
            case "/":
                val = val1 / val2;
                break;
            case "*":
                val = val1 * val2;
                break;                                
        }

        return val;
    }
}

/*

1. put all operators in a set
2. initialize a stack
3. iterate over input tokens and push digits in stack
4. when there is operator evaluate the top 2 stack values and add to stack
5. return stack.Pop()

Time complexity: O(n)
Space complexity: O(n)

*/