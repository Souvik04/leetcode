public class MinStack {
    Stack<(int val, int min)> _stack = null;
    public MinStack() {
        _stack = new Stack<(int val, int min)>();
    }
    
    public void Push(int val) {
        if(_stack.Count == 0){
            _stack.Push((val, val));
        }
        else{
            _stack.Push((val, Math.Min(_stack.Peek().min, val)));
        }
    }
    
    public void Pop() {
        _stack.Pop();
    }
    
    public int Top() {
        return _stack.Peek().val;
    }
    
    public int GetMin() {
        return _stack.Peek().min;
    }
}


/*

// Linked list based

public class MinStack {
    private Node _head;

    public MinStack() {

    }
    
    public void Push(int val) {
        if(_head == null){
            _head = new Node(val, val, null);
        }
        else{
            _head = new Node(val, Math.Min(val, _head.min), _head);
        }
    }
    
    public void Pop() {
        _head = _head.next;
    }
    
    public int Top() {
        return _head.val;
    }
    
    public int GetMin() {
        return _head.min;
    }

    private class Node{
        public int val;
        public int min;
        public Node next;

        public Node(int val, int min, Node next){
            this.val = val;
            this.min = min;
            this.next = next;
        }
    }
}

*/

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */