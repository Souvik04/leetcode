public class MinStack {
    Stack<(int val, int min)> stack = null;
    public MinStack() {
        stack = new Stack<(int, int)>();
    }
    
    public void Push(int val) {
        if(stack.Count == 0){
            stack.Push((val, val));
        }
        else{
            stack.Push((val, Math.Min(val, stack.Peek().min)));
        }
    }
    
    public void Pop() {
        stack.Pop();
    }
    
    public int Top() {
        return stack.Peek().val;
    }
    
    public int GetMin() {
        return stack.Peek().min;
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */