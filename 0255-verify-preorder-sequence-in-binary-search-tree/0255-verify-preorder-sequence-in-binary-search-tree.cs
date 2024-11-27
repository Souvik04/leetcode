public class Solution {
    public bool VerifyPreorder(int[] preorder) {
        int minVal = int.MinValue;
        Stack<int> stack = new Stack<int>();

        foreach(int num in preorder){
            while(stack.Count > 0 && stack.Peek() < num){
                minVal = stack.Pop();
            }

            if(num <= minVal){
                return false;
            }

            stack.Push(num);
        }

        return true;
    }
}

/*

1. create a minVal variable and a stack to store elements in monotonically increasing order
2. pop elements if top stack element is less than current and update minVal
3. check if current element <= minVal return false
4. push current into stack
5. return true at end

*/